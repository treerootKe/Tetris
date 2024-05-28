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

        public float[] fDropSpeed;
        public int nDropSpeedLevel;
        private void Awake()
        {
            FindComponent();
            CommonMembers.InitValue();
            for (int i = 0; i < 200; i++)
            {
                panelAllPos.Add(null);
            }

            //初始化对象池
            CommonMembers.ShapePool = new ObjectPool<ItemShape>[7];
            for (int i = 0; i < 7; i++)
            {
                CommonMembers.ShapePool[i] = new ObjectPool<ItemShape>(transformPrefab.GetChild(i).GetComponent<ItemShape>());
            }
            CommonMembers.blockPool = new ObjectPool<Transform>(transformPrefab.Find("block"));
            fDropSpeed = new float[3] { 1, 0.5f, 0.25f };
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
                globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x - 45, 0.001f).OnComplete(() =>
                {
                    globalItemShape.SetBlockPos();
                });
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) && globalItemShape.JudgeIsPossibleMoveX(panelAllPos, true))
            {
                globalItemShape.transform.DOLocalMoveX(globalItemShape.transform.localPosition.x + 45, 0.001f).OnComplete(() =>
                {
                    globalItemShape.SetBlockPos();
                });
            }
        }
        private void StartTetris()
        {
            globalItemShape = CommonMembers.ShapePool[0].Get(transformDropPanel);
            StartCoroutine(BlockDrop(globalItemShape));
        }

        IEnumerator BlockDrop(ItemShape item)
        {
            while (item.JudgeIsPossibleMoveY(panelAllPos))
            {
                item.transform.DOLocalMoveY(item.transform.localPosition.y - 45, 0.001f).OnComplete(()=>
                {
                    item.SetBlockPos();
                });
                yield return new WaitForSeconds(fDropSpeed[nDropSpeedLevel]);
            }
            for (int i = 0; i < 4; i++)
            {
                panelAllPos[item.blockPos[i]] = item.fourBlock[i];
            }
            StartTetris();
        }
    }
}