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
        public static List<int[]> shapeInitInsideArea = new List<int[]>();              //形状初始内部位置集合
        public static List<List<int[]>> shapeChangeInsideArea = new List<List<int[]>>();//形状改变后内部位置集合 
        public void InitValues()
        {
            shapeInitInsideArea.Add(new int[4] { 8, 9, 10, 11 });
            shapeInitInsideArea.Add(new int[4] { 4, 6, 7, 8 });
            shapeInitInsideArea.Add(new int[4] { 3, 6, 7, 8 });
            shapeInitInsideArea.Add(new int[4] { 5, 6, 7, 8 });
            shapeInitInsideArea.Add(new int[4] { 3, 4, 7, 8 });
            shapeInitInsideArea.Add(new int[4] { 4, 5, 6, 7 });
            shapeInitInsideArea.Add(new int[4] { 0, 1, 2, 3});

            var ShapeArea = new List<int[]>();
            ShapeArea.Add(new int[4] { 8, 9, 10, 11 });
            ShapeArea.Add(new int[4] { 3, 7, 11, 15 });
            ShapeArea.Add(new int[4] { 4, 5, 6, 7 });
            ShapeArea.Add(new int[4] { 1, 4, 7, 10 });
            shapeChangeInsideArea.Add(ShapeArea);
            var oneShapeArea = new List<int[]>();
            oneShapeArea.Add(new int[4] { 4, 6, 7, 8 });
            oneShapeArea.Add(new int[4] { 2, 4, 5, 8 });
            oneShapeArea.Add(new int[4] { 0, 1, 2, 4 });
            oneShapeArea.Add(new int[4] { 0, 3, 4, 6 });
            shapeChangeInsideArea.Add(oneShapeArea);
            var twoShapeArea = new List<int[]>();
            twoShapeArea.Add(new int[4] { 3, 6, 7, 8 });
            twoShapeArea.Add(new int[4] { 2, 5, 7, 8 });
            twoShapeArea.Add(new int[4] { 0, 1, 2, 5 });
            twoShapeArea.Add(new int[4] { 0, 1, 3, 6 });
            shapeChangeInsideArea.Add(twoShapeArea);
            var threeShapeArea = new List<int[]>();
            threeShapeArea.Add(new int[4] { 5, 6, 7, 8 });
            threeShapeArea.Add(new int[4] { 1, 2, 5, 8 });
            threeShapeArea.Add(new int[4] { 0, 1, 2, 3 });
            threeShapeArea.Add(new int[4] { 0, 3, 6, 7 });
            shapeChangeInsideArea.Add(threeShapeArea);
            var fourShapeArea = new List<int[]>();
            fourShapeArea.Add(new int[4] { 3, 4, 7, 8 });
            fourShapeArea.Add(new int[4] { 2, 4, 5, 7 });
            fourShapeArea.Add(new int[4] { 0, 1, 4, 5 });
            fourShapeArea.Add(new int[4] { 1, 3, 4, 6 });
            shapeChangeInsideArea.Add(fourShapeArea);
            var fiveShapeArea = new List<int[]>();
            fiveShapeArea.Add(new int[4] { 4, 5, 6, 7 });
            fiveShapeArea.Add(new int[4] { 1, 4, 5, 8 });
            fiveShapeArea.Add(new int[4] { 1, 2, 3, 4 });
            fiveShapeArea.Add(new int[4] { 0, 3, 4, 7 });
            shapeChangeInsideArea.Add(fiveShapeArea);
            var sixShapeArea = new List<int[]>();
            sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
            sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
            sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
            sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
            shapeChangeInsideArea.Add(sixShapeArea);
        }
    }
}
