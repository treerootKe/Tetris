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
        public Transform transformDropPanel;        //下落区域的父物体
        public Transform transformPrefab;           //单个方块预制体
        public List<Transform> panelAllPos;         //下落区域的200个位置
        public GameObject[] gameobjectsNextShape;   //下一个形状的游戏物体数组
        public ItemShape globalItemShape;           //当前正在下落的形状

        private int mScore;                         //当前总得分
        public bool isFastDrop;                     //形状是否处于快速下落的状态                  
        private int mNextShape;                     //下一个形状的索引(0--6，分别对应7种形状)
        public float fDropInterval;                 //形状当前下落间隔
        public float[] fDropIntervals;              //形状每下落一次，需要等待间隔的数组
        public int nDropIntervalLevel;              //形状下落间隔等级(0--2)
        public float fDropIntervalFastest;          //形状快速下落时的等待间隔

        public Button btnRestart;                   //重新开始按钮
        public Text txtScore;                       //分数显示文本
        public Text txtHistoryScore;                //历史分数显示文本
        public Text txtLevel;                       //形状下落间隔等级显示文本

        private IEnumerator mIEBlockDrop;           //控制形状下落的协程
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
            fDropIntervals = new float[3] { 1, 0.5f, 0.25f };
            fDropIntervalFastest = 0.05f;
            fDropInterval = fDropIntervals[nDropIntervalLevel];
            mNextShape = UnityEngine.Random.Range(0, 7);
        }

        //获取组件
        private void FindComponent()
        {
            transformDropPanel = transform.Find("BlockDropArea/DropPanel");
            transformPrefab = transform.Find("Prefab");
            btnRestart = transform.Find("imgRestart/btnRestart").GetComponent<Button>();
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
                if (Input.GetKeyDown(KeyCode.F) && globalItemShape.JudgeIsPossibleRotateB(panelAllPos))
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
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && globalItemShape.JudgeIsPossibleMoveX(panelAllPos, true))
                {
                    var transform1 = globalItemShape.transform;
                    var pos = transform1.localPosition;
                    transform1.localPosition = new Vector3(pos.x + 45, pos.y, pos.z);
                    globalItemShape.SetBlockPos();
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && isFastDrop)
                {
                    fDropInterval = fDropIntervalFastest;
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
            yield return new WaitForSeconds(fDropInterval);
            while (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                item.transform.DOLocalMoveY(item.transform.localPosition.y - 45, 0.001f).OnComplete(item.SetBlockPos);
                yield return new WaitForSeconds(fDropInterval);
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
            fDropInterval = fDropIntervals[nDropIntervalLevel];
            yield return BlockDisappear();
            StartTetris();
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