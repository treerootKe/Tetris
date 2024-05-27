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
        public static readonly List<int[]> ShapeInitInsideArea = new List<int[]>();              //形状初始内部位置集合
        public static readonly List<List<int[]>> ShapeChangeInsideArea = new List<List<int[]>>();//形状改变后内部位置集合 
        public void InitValues()
        {
            ShapeInitInsideArea.Add(new int[4] { 8, 9, 10, 11 });
            ShapeInitInsideArea.Add(new int[4] { 4, 6, 7, 8 });
            ShapeInitInsideArea.Add(new int[4] { 3, 6, 7, 8 });
            ShapeInitInsideArea.Add(new int[4] { 5, 6, 7, 8 });
            ShapeInitInsideArea.Add(new int[4] { 3, 4, 7, 8 });
            ShapeInitInsideArea.Add(new int[4] { 4, 5, 6, 7 });
            ShapeInitInsideArea.Add(new int[4] { 0, 1, 2, 3});

            var shapeArea = new List<int[]>
            {
                new int[4] { 8, 9, 10, 11 },
                new int[4] { 3, 7, 11, 15 },
                new int[4] { 4, 5, 6, 7 },
                new int[4] { 1, 4, 7, 10 }
            };
            ShapeChangeInsideArea.Add(shapeArea);
            var oneShapeArea = new List<int[]>
            {
                new int[4] { 4, 6, 7, 8 },
                new int[4] { 2, 4, 5, 8 },
                new int[4] { 0, 1, 2, 4 },
                new int[4] { 0, 3, 4, 6 }
            };
            ShapeChangeInsideArea.Add(oneShapeArea);
            var twoShapeArea = new List<int[]>
            {
                new int[4] { 3, 6, 7, 8 },
                new int[4] { 2, 5, 7, 8 },
                new int[4] { 0, 1, 2, 5 },
                new int[4] { 0, 1, 3, 6 }
            };
            ShapeChangeInsideArea.Add(twoShapeArea);
            var threeShapeArea = new List<int[]>
            {
                new int[4] { 5, 6, 7, 8 },
                new int[4] { 1, 2, 5, 8 },
                new int[4] { 0, 1, 2, 3 },
                new int[4] { 0, 3, 6, 7 }
            };
            ShapeChangeInsideArea.Add(threeShapeArea);
            var fourShapeArea = new List<int[]>
            {
                new int[4] { 3, 4, 7, 8 },
                new int[4] { 2, 4, 5, 7 },
                new int[4] { 0, 1, 4, 5 },
                new int[4] { 1, 3, 4, 6 }
            };
            ShapeChangeInsideArea.Add(fourShapeArea);
            var fiveShapeArea = new List<int[]>
            {
                new int[4] { 4, 5, 6, 7 },
                new int[4] { 1, 4, 5, 8 },
                new int[4] { 1, 2, 3, 4 },
                new int[4] { 0, 3, 4, 7 }
            };
            ShapeChangeInsideArea.Add(fiveShapeArea);
            var sixShapeArea = new List<int[]>
            {
                new int[4] { 0, 1, 2, 3 },
                new int[4] { 0, 1, 2, 3 },
                new int[4] { 0, 1, 2, 3 },
                new int[4] { 0, 1, 2, 3 }
            };
            ShapeChangeInsideArea.Add(sixShapeArea);
        }
    }
}
