using Mine.ToolClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mine.ObjectPoolItem
{
    public class ItemShape:MonoBehaviour
    {
        public int mShapeType;                  //形状的类型
        public List<Vector2> mShapeArea;        //形状的内部区域坐标集合
        public List<Vector2> mBlockArea;        //方块在整个下落区域的坐标集合
        public List<Vector2> mInitShapeArea;    //形状初始内部坐标集合
        public List<Vector2> mChangeShapeArea;  //形状改变后内部坐标集合
        private void Awake()
        {
            ObjectPool<ItemShape> f;
        }
        public void InitValues()
        {

        }
    }
}
