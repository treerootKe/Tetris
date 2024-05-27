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
        public int[] blockInsidePos;                   //方块在内部位置坐标集合
        public List<Vector2[]> blockChangeInsidePos;   //形状改变后，方块在内部位置坐标集合
        public Transform[] fourBlock; 
        private void Awake()
        {
            blockInsidePos = CommonMembers.blockInitInsidePos[shapeType];
            blockChangeInsidePos = CommonMembers.blockChangeInsidePos[shapeType];
            fourBlock = new Transform[4];
        }
        private void OnEnable()
        {
            if (shapeType == 6)
            {
                //O形
                transform.localPosition = new Vector2(180, 810);
            }
            else
            {
                transform.localPosition = new Vector2(135, 765);
            }
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
                blockPos[i] = posTrans + blockInsidePos[i];
            }
        }
    }
}
