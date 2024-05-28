using Mine.ToolClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Mine.Control;

namespace Mine.ObjectPoolItem
{
    public class ItemShape: MonoBehaviour
    {
        public int shapeType;                          //形状的类型
        public int shapeIndex;                         //形状当前变换的位置
        public int[] blockPos;                         //方块在整个下落区域的位置集合
        public Transform[] fourBlock;                  //形状内部的四个方块
        private List<Vector2[]> mBlockRotateInsidePos; //形状改变后，方块在内部位置坐标集合
        private void Awake()
        {
            blockPos = new int[4];
            fourBlock = new Transform[4];
            mBlockRotateInsidePos = CommonMembers.blockRotateInsidePos[shapeType];
        }
        private void OnEnable()
        {
            transform.localPosition = shapeType == 6 ? new Vector2(180, 810) : new Vector2(135, 765);
            for (int i = 0; i < fourBlock.Length; i++)
            {
                fourBlock[i] = CommonMembers.blockPool.Get(transform);
            }
            shapeIndex = 0;
            SetBlockPos();
        }

        //设置方块在整个下落区域的坐标
        public void SetBlockPos()
        {
            if (shapeIndex < 0)
            {
                shapeIndex = 3;
            }
            if (shapeIndex > 3)
            {
                shapeIndex = 0;
            }
            var pos = transform.localPosition;
            var posTrans = (int)(pos.y * 10 + pos.x) / 45;
            for (int i = 0; i < fourBlock.Length; i++)
            {
                var posBlock = (int)(mBlockRotateInsidePos[shapeIndex % 4][i].y * 10 + mBlockRotateInsidePos[shapeIndex % 4][i].x) / 45;
                fourBlock[i].localPosition = mBlockRotateInsidePos[shapeIndex % 4][i];
                blockPos[i] = posTrans + posBlock;
            }
        }

        //判断是否可以逆时针旋转
        public bool JudgeIsPossibleRotateA(List<Transform> allPos)
        {
            if (transform.localPosition.x < 0 || transform.localPosition.y < 0)
            {
                return false;
            }
            var pos = transform.localPosition;
            var posTrans = (int)(pos.y * 10 + pos.x) / 45;
            var nextBlockPos = new int[4];
            var nextShapeIndex = shapeIndex - 1;
            if (nextShapeIndex < 0)
            {
                nextShapeIndex = 3;
            }
            for (int i = 0; i < 4; i++)
            {
                var posBlock = (int)(mBlockRotateInsidePos[nextShapeIndex][i].y * 10 + mBlockRotateInsidePos[nextShapeIndex][i].x) / 45;
                nextBlockPos[i] = posTrans + posBlock;
                if (allPos[nextBlockPos[i]] != null)
                {
                    return false;
                }
            }
            return true;
        }
        //判断是否可以顺时针旋转
        public bool JudgeIsPossibleRotateB(List<Transform> allPos)
        {
            if (transform.localPosition.x < 0 || transform.localPosition.y < 0)
            {
                return false;
            }
            var pos = transform.localPosition;
            var posTrans = (int)(pos.y * 10 + pos.x) / 45;
            var nextBlockPos = new int[4];
            var nextShapeIndex = shapeIndex + 1;
            if (nextShapeIndex > 3)
            {
                nextShapeIndex = 0;
            }
            for (int i = 0; i < 4; i++)
            {
                var posBlock = (int)(mBlockRotateInsidePos[nextShapeIndex][i].y * 10 + mBlockRotateInsidePos[nextShapeIndex][i].x) / 45;
                nextBlockPos[i] = posTrans + posBlock;
                if (allPos[nextBlockPos[i]] != null)
                {
                    return false;
                }
            }
            return true;
        }

        public bool JudgeIsPossibleMoveX(List<Transform> allPos,bool direction)
        {
            var nextBlockPos = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (blockPos[i] % 10 == 0 && !direction)
                {
                    return false;
                }

                if (this.blockPos[i] % 10 == 9 && direction)
                {
                    return false;
                }
                nextBlockPos[i] = direction ? this.blockPos[i] + 1 : this.blockPos[i] - 1;
                if (allPos[nextBlockPos[i]] != null)
                {
                    return false;
                }
            }
            return true;
        }
        public bool JudgeIsPossibleMoveY(List<Transform> allPos)
        {
            var nextBlockPos = new int[4];
            for (int i = 0; i < 4; i++)
            {
                if (this.blockPos[i] < 10)
                {
                    return false;
                }
                nextBlockPos[i] = this.blockPos[i] - 10;
                if (allPos[nextBlockPos[i]] != null)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
