using Mine.ObjectPoolItem;
using Mine.ToolClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Mine.Control
{
    public class CommonMenbers
    {
        public static ObjectPool<ItemShape> shapePool;
        public static ObjectPool<Transform> blockPool;
        public static List<List<Vector2>> shapeInitInsideArea = new List<List<Vector2>>();    //形状初始内部坐标集合
        public void InitValues()
        {

        }
    }
}
