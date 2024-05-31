using System.Collections;
using UnityEngine;
using Mine.ObjectPoolItem;
using System.Collections.Generic;
using DG.Tweening;
using Mine.ToolClasses;
using System;
using UnityEngine.UI;

namespace Mine.Control
{
    public class PlayerControl:MonoBehaviour
    {
        public Transform transformDropPanel;
        public Transform transformPrefab;
        
        public List<Transform> panelAllPos;

        public ItemShape globalItemShape;

        public float[] fDropSpeedLevel;
        public int nDropSpeedLevel;
        public float fFastDropSpeed;
        public float fDropSpeed;
        public bool isFastDrop;
        public bool isRotating;
        public bool isMoveX;
        private int mScore;
        private int mNextShape;

        public Text txtScore;
        public Text txtHistoryScore;
        public Text txtLevel;
        public GameObject[] gameobjectsNextShape;

        public Button btnRestart;
        private IEnumerator mIEBlockDrop;
        private void Awake()
        {
            FindComponent();
            CommonMembers.InitValue();
            for (int i = 0; i < 210; i++)
            {
                panelAllPos.Add(null);
            }

            //初始化对象池
            CommonMembers.shapePool = new ObjectPool<ItemShape>[7];
            for (int i = 0; i < 7; i++)
            {
                CommonMembers.shapePool[i] = new ObjectPool<ItemShape>(transformPrefab.GetChild(i).GetComponent<ItemShape>());
            }
            CommonMembers.blockPool = new ObjectPool<Transform>(transformPrefab.Find("block"));
            fDropSpeedLevel = new float[3] { 1, 0.5f, 0.25f };
            fFastDropSpeed = 0.05f;
            fDropSpeed = fDropSpeedLevel[nDropSpeedLevel];
            mNextShape = UnityEngine.Random.Range(0, 7);
        }

        //获取组件
        private void FindComponent()
        {
            transformDropPanel = transform.Find("BlockDropArea/DropPanel");
            transformPrefab = transform.Find("Prefab");
            txtScore = transform.Find("ScoreArea/imgScore/txtScore").GetComponent<Text>();
            txtHistoryScore = transform.Find("ScoreArea/imgScore/txtScore").GetComponent<Text>();
            txtLevel = transform.Find("ScoreArea/imgScore/txtScore").GetComponent<Text>();
            gameobjectsNextShape = new GameObject[7];
            for (int i = 0; i < 7; i++)
            {
                gameobjectsNextShape[i] = transform.Find("ScoreArea/imgNextShape").GetChild(i).gameObject;
            }
        }
        private void OnEnable()
        {
            StartTetris();
        }

        private void Update()
        {
            if (globalItemShape != null)
            {
                if (Input.GetKeyDown(KeyCode.D) && globalItemShape.JudgeIsPossibleRotateA(panelAllPos))
                {
                    globalItemShape.shapeIndex--;
                    globalItemShape.SetBlockPos();
                }
                if (Input.GetKey(KeyCode.F) && globalItemShape.JudgeIsPossibleRotateB(panelAllPos))
                {
                    globalItemShape.shapeIndex++;
                    globalItemShape.SetBlockPos();
                }
                if (Input.GetKeyDown(KeyCode.LeftArrow) && globalItemShape.JudgeIsPossibleMoveX(panelAllPos, false))
                {
                    var transform1 = globalItemShape.transform;
                    var pos = transform1.localPosition;
                    transform1.localPosition = new Vector3(pos.x - 45, pos.y, pos.z);
                    globalItemShape.SetBlockPos();
                    // globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x - 45, 0.001f).OnComplete(globalItemShape.SetBlockPos);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && globalItemShape.JudgeIsPossibleMoveX(panelAllPos, true))
                {
                    var transform1 = globalItemShape.transform;
                    var pos = transform1.localPosition;
                    transform1.localPosition = new Vector3(pos.x + 45, pos.y, pos.z);
                    globalItemShape.SetBlockPos();
                    // globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x + 45, 0.001f).OnComplete(globalItemShape.SetBlockPos);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && isFastDrop)
                {
                    fDropSpeed = fFastDropSpeed;
                    StopCoroutine(mIEBlockDrop);
                    StartCoroutine(mIEBlockDrop);
                }
            }
        }
        private void StartTetris()
        {
            isFastDrop = true;
            gameobjectsNextShape[mNextShape].SetActive(false);
            globalItemShape = CommonMembers.shapePool[mNextShape].Get(transformDropPanel);
            mNextShape = UnityEngine.Random.Range(0, 7);
            gameobjectsNextShape[mNextShape].SetActive(true);
            mIEBlockDrop = BlockDrop(globalItemShape);
            if (!globalItemShape.JudgeIsPossibleMoveY(panelAllPos))
            {
                Debug.Log("gameover");
                globalItemShape = null;
                return;
            }
            StartCoroutine(mIEBlockDrop);
        }

        IEnumerator BlockDrop(ItemShape item,bool isRecursion = false)
        {
            yield return new WaitForSeconds(fDropSpeed);
            while (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                item.transform.DOLocalMoveY(item.transform.localPosition.y - 45, 0.001f).OnComplete(item.SetBlockPos);
                yield return new WaitForSeconds(fDropSpeed);
            }
            yield return new WaitForSeconds(0.1f);
            if (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                yield return BlockDrop(item, true);
            }
            if (isRecursion)
            {
                yield break;
            }
            globalItemShape = null;
            for (int i = 0; i < 4; i++)
            {
                panelAllPos[item.blockPos[i]] = item.fourBlock[i];
            }
            fDropSpeed = fDropSpeedLevel[nDropSpeedLevel];
            yield return BlockDisappear();
            StartTetris();
        }
        private void StartTetrisInMiddle()
        {
            StopCoroutine(mIEBlockDrop);
            StartCoroutine(mIEBlockDrop);
        }
        IEnumerator BlockDisappear()
        {
            List<int> disappearRow = new List<int>();
            for (int i = 0; i < 200; i+=10)
            {
                bool isNeedDisappear = true;
                for (int j = i; j < i + 10; j++)
                {
                    if (panelAllPos[j] == null)
                    {
                        isNeedDisappear = false;
                        break;
                    }
                }
                if (isNeedDisappear) 
                {
                    disappearRow.Add(i);
                    for (int j = i; j < i + 10; j++)
                    {
                        CommonMembers.blockPool.Recycle(panelAllPos[j]);
                        panelAllPos[j] = null;
                    }
                }
            }
            //加分
            if (disappearRow.Count != 0)
            {
                AddScore(disappearRow.Count);
                for (int i = disappearRow[disappearRow.Count - 1] + 10; i < 200; i++)
                {
                    if (panelAllPos[i] != null)
                    {
                        panelAllPos[i].DOLocalMoveY(panelAllPos[i].transform.localPosition.y - 45 * disappearRow.Count, 0.001f);
                        panelAllPos[i - disappearRow.Count * 10] = panelAllPos[i];
                        panelAllPos[i] = null;
                    }
                }
                yield return new WaitForSeconds(1f);
            }
        }
        private void AddScore(int nDisappearLine)
        {
            int nOnceScore = nDisappearLine * nDisappearLine * 100;
            DOTween.To(endvalue =>
            {
                txtScore.text = ((int)endvalue).ToString();
            }, mScore, mScore + nOnceScore, 1).OnComplete(() => mScore += nOnceScore);
        }
    }
}