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
        public int[] blockPos;                         //方块在整个下落区域的坐标集合
        public Transform[] fourBlock;                  //形状内部的四个方块
        private List<Vector2[]> mBlockChangeInsidePos; //形状改变后，方块在内部位置坐标集合
        private void Awake()
        {
            blockPos = new int[4];
            fourBlock = new Transform[4];
            mBlockChangeInsidePos = CommonMembers.BlockChangeInsidePos[shapeType];
        }
        private void OnEnable()
        {
            transform.localPosition = shapeType == 6 ? new Vector2(180, 810) : new Vector2(135, 765);
            shapeIndex = 0;
            for (int i = 0; i < fourBlock.Length; i++)
            {
                fourBlock[i] = CommonMembers.blockPool.Get(transform);
            }
            SetBlockPos();
        }
        public void SetBlockPos()
        {
            var pos = transform.localPosition;
            var posTrans = (int)(pos.y * 10 + pos.x) / 45;
            for (int i = 0; i < fourBlock.Length; i++)
            {
                var posBlock = (int)(mBlockChangeInsidePos[shapeIndex][i].y * 10 + mBlockChangeInsidePos[shapeIndex][i].x) / 45;
                fourBlock[i].localPosition = mBlockChangeInsidePos[shapeIndex][i];
                blockPos[i] = posTrans + posBlock;
            }
        }
    }
}
