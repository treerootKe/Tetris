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
        public int mShapeType;                              //形状的类型
        public List<Vector2> mShapeInsideArea;              //形状的内部区域坐标集合(3×3或4×4)
        public List<Vector2> mBlockPos;                     //方块在整个下落区域的坐标集合
        public List<List<Vector2>> mChangeShapeInsideArea;        //形状改变后内部坐标集合
        private void Awake()
        {

        }
        public void InitValues()
        {

        }
    }
}
