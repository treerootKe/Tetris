using System.Collections;
using UnityEngine;
using Mine.ObjectPoolItem;
using System.Collections.Generic;
using DG.Tweening;
using Mine.ToolClasses;
using System;

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

        IEnumerator IEBlockDrop;
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
        }

        //获取组件
        private void FindComponent()
        {
            transformDropPanel = transform.Find("BlockDropArea/DropPanel");
            transformPrefab = transform.Find("Prefab");
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
                    globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x - 45, 0.001f).OnComplete(globalItemShape.SetBlockPos);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow) && globalItemShape.JudgeIsPossibleMoveX(panelAllPos, true))
                {
                    globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x + 45, 0.001f).OnComplete(globalItemShape.SetBlockPos);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow) && isFastDrop)
                {
                    fDropSpeed = fFastDropSpeed;
                    StopCoroutine(IEBlockDrop);
                    StartCoroutine(IEBlockDrop);
                }
            }
        }
        private void StartTetris()
        {
            isFastDrop = true;
            globalItemShape = CommonMembers.shapePool[UnityEngine.Random.Range(0,7)].Get(transformDropPanel);
            IEBlockDrop = BlockDrop(globalItemShape);
            StartCoroutine(IEBlockDrop);
        }

        IEnumerator BlockDrop(ItemShape item)
        {
            while (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                yield return new WaitForSeconds(fDropSpeed);
                item.transform.DOLocalMoveY(item.transform.localPosition.y - 45, 0.001f).OnComplete(item.SetBlockPos);
                yield return new WaitForSeconds(0.001f);
            }
            yield return new WaitForSeconds(0.1f);
            if (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                StartTerisInMiddle();
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
        private void StartTerisInMiddle()
        {
            StopCoroutine(IEBlockDrop);
            IEBlockDrop = BlockDrop(globalItemShape);
            StartCoroutine(IEBlockDrop);
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
            yield return new WaitForSeconds(1f);
            if (disappearRow.Count != 0)
            {
                for (int i = disappearRow[disappearRow.Count - 1] + 10; i < 200; i++)
                {
                    if (panelAllPos[i] != null)
                    {
                        panelAllPos[i].DOLocalMoveY(panelAllPos[i].transform.localPosition.y - 45 * disappearRow.Count, 0.001f);
                        panelAllPos[i - disappearRow.Count * 10] = panelAllPos[i];
                        panelAllPos[i] = null;
                    }
                }
            }
        }
    }
}