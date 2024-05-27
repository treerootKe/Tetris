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
        public int shapeType;                      //形状的类型
        public int shapeInsideCount;               //形状的内部区域总长度(3×3或4×4)
        public int[] blockPos;                     //方块在整个下落区域的坐标集合
        public int[] shapeInsideArea;              //形状当前内部位置集合
        public List<int[]> shapeChangeInsideArea;  //形状改变后内部坐标集合
        public Transform[] fourBlock; 
        private void Awake()
        {
            shapeInsideCount = shapeType switch
            {
                0 => 16,
                6 => 4,
                _ => 9
            };
            shapeInsideArea = CommonMenbers.ShapeInitInsideArea[shapeType];
            shapeChangeInsideArea = CommonMenbers.ShapeChangeInsideArea[shapeType];
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
                fourBlock[i] = CommonMenbers.blockPool.Get(transform);
            }
            SetBlockPos();
        }
        public void SetBlockPos()
        {
            var pos = transform.localPosition;
            var posTrans = (int)(pos.y * 10 + pos.x) / 45;
            for (int i = 0; i < fourBlock.Length; i++)
            {
                blockPos[i] = posTrans + shapeInsideArea[i];
            }
        }
    }
}
