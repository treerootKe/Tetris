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
        public static List<int[]> blockInitInsidePos = new List<int[]>();              //形状初始内部位置集合
        public static List<List<Vector2[]>> blockChangeInsidePos = new List<List<Vector2[]>>();//形状改变后内部位置集合 
        //public void InitValues()
        //{
        //    blockInitInsidePos.Add(new int[4] { 8, 9, 10, 11 });
        //    blockInitInsidePos.Add(new int[4] { 4, 6, 7, 8 });
        //    blockInitInsidePos.Add(new int[4] { 3, 6, 7, 8 });
        //    blockInitInsidePos.Add(new int[4] { 5, 6, 7, 8 });
        //    blockInitInsidePos.Add(new int[4] { 3, 4, 7, 8 });
        //    blockInitInsidePos.Add(new int[4] { 4, 5, 6, 7 });
        //    blockInitInsidePos.Add(new int[4] { 0, 1, 2, 3});

        //    var ShapeArea = new List<int[]>();
        //    ShapeArea.Add(new int[4] { 8, 9, 10, 11 });
        //    ShapeArea.Add(new int[4] { 3, 7, 11, 15 });
        //    ShapeArea.Add(new int[4] { 4, 5, 6, 7 });
        //    ShapeArea.Add(new int[4] { 1, 4, 7, 10 });
        //    blockChangeInsidePos.Add(ShapeArea);
        //    var oneShapeArea = new List<int[]>();
        //    oneShapeArea.Add(new int[4] { 4, 6, 7, 8 });
        //    oneShapeArea.Add(new int[4] { 2, 4, 5, 8 });
        //    oneShapeArea.Add(new int[4] { 0, 1, 2, 4 });
        //    oneShapeArea.Add(new int[4] { 0, 3, 4, 6 });
        //    blockChangeInsidePos.Add(oneShapeArea);
        //    var twoShapeArea = new List<int[]>();
        //    twoShapeArea.Add(new int[4] { 3, 6, 7, 8 });
        //    twoShapeArea.Add(new int[4] { 2, 5, 7, 8 });
        //    twoShapeArea.Add(new int[4] { 0, 1, 2, 5 });
        //    twoShapeArea.Add(new int[4] { 0, 1, 3, 6 });
        //    blockChangeInsidePos.Add(twoShapeArea);
        //    var threeShapeArea = new List<int[]>();
        //    threeShapeArea.Add(new int[4] { 5, 6, 7, 8 });
        //    threeShapeArea.Add(new int[4] { 1, 2, 5, 8 });
        //    threeShapeArea.Add(new int[4] { 0, 1, 2, 3 });
        //    threeShapeArea.Add(new int[4] { 0, 3, 6, 7 });
        //    blockChangeInsidePos.Add(threeShapeArea);
        //    var fourShapeArea = new List<int[]>();
        //    fourShapeArea.Add(new int[4] { 3, 4, 7, 8 });
        //    fourShapeArea.Add(new int[4] { 2, 4, 5, 7 });
        //    fourShapeArea.Add(new int[4] { 0, 1, 4, 5 });
        //    fourShapeArea.Add(new int[4] { 1, 3, 4, 6 });
        //    blockChangeInsidePos.Add(fourShapeArea);
        //    var fiveShapeArea = new List<int[]>();
        //    fiveShapeArea.Add(new int[4] { 4, 5, 6, 7 });
        //    fiveShapeArea.Add(new int[4] { 1, 4, 5, 8 });
        //    fiveShapeArea.Add(new int[4] { 1, 2, 3, 4 });
        //    fiveShapeArea.Add(new int[4] { 0, 3, 4, 7 });
        //    blockChangeInsidePos.Add(fiveShapeArea);
        //    var sixShapeArea = new List<int[]>();
        //    sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
        //    sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
        //    sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
        //    sixShapeArea.Add(new int[4] { 0, 1, 2, 3 });
        //    blockChangeInsidePos.Add(sixShapeArea);
        //}
        public void InitValue()
        {
            var ShapeArea = new List<Vector2[]>();
            ShapeArea.Add(new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) });
            ShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) });
            ShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) });
            ShapeArea.Add(new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) });
            blockChangeInsidePos.Add(ShapeArea);
            var oneShapeArea = new List<Vector2[]>();
            oneShapeArea.Add(new Vector2[4] { new Vector2(45, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) });
            oneShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(90, 90) });
            oneShapeArea.Add(new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(45, 45) });
            oneShapeArea.Add(new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(45, 45), new Vector2(0, 90) });
            blockChangeInsidePos.Add(oneShapeArea);
            var twoShapeArea = new List<Vector2[]>();
            twoShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) });
            twoShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(45, 90), new Vector2(90, 90) });
            twoShapeArea.Add(new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(90, 45) });
            twoShapeArea.Add(new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(0, 90) });
            blockChangeInsidePos.Add(twoShapeArea);
            var threeShapeArea = new List<Vector2[]>();
            threeShapeArea.Add(new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) });
            threeShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) });
            threeShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) });
            threeShapeArea.Add(new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) });
            blockChangeInsidePos.Add(threeShapeArea);
            var fourShapeArea = new List<Vector2[]>();
            fourShapeArea.Add(new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) });
            fourShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) });
            fourShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) });
            fourShapeArea.Add(new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) });
            blockChangeInsidePos.Add(fourShapeArea);
            var fiveShapeArea = new List<Vector2[]>();
            fiveShapeArea.Add(new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) });
            fiveShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) });
            fiveShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) });
            fiveShapeArea.Add(new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) });
            blockChangeInsidePos.Add(fiveShapeArea);
            var sixShapeArea = new List<Vector2[]>();
            sixShapeArea.Add(new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) });
            sixShapeArea.Add(new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) });
            sixShapeArea.Add(new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) });
            sixShapeArea.Add(new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) });
            blockChangeInsidePos.Add(sixShapeArea);
        }
    }
}
