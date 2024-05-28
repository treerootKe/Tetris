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
    public class CommonMembers
    {
        public static ObjectPool<ItemShape>[] ShapePool;
        public static ObjectPool<Transform> blockPool;
        public static List<List<Vector2[]>> BlockRotateInsidePos;//形状旋转后内部位置集合 
        
        public static void InitValue()
        {
            BlockRotateInsidePos = new List<List<Vector2[]>>();
            //I
            var shapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) },
                new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) }
            };
            BlockRotateInsidePos.Add(shapeArea);
            //T
            var oneShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(45, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(45, 45), new Vector2(0, 90) }
            };
            BlockRotateInsidePos.Add(oneShapeArea);
            //L
            var twoShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(90, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(0, 90) }
            };
            BlockRotateInsidePos.Add(twoShapeArea);
            //J
            var threeShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(90, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(0, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(0, 45), new Vector2(0, 90), new Vector2(45, 90) }
            };
            BlockRotateInsidePos.Add(threeShapeArea);
            //Z
            var fourShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(45, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(90, 0), new Vector2(0, 45), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45), new Vector2(0, 90) }
            };
            BlockRotateInsidePos.Add(fourShapeArea);
            //S
            var fiveShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(45, 45), new Vector2(90, 45), new Vector2(0, 90), new Vector2(45, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(45, 45), new Vector2(90, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(0, 45), new Vector2(45, 45), new Vector2(45, 90) }
            };
            BlockRotateInsidePos.Add(fiveShapeArea);
            //O
            var sixShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45)  },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45)  },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45) }
            };
            BlockRotateInsidePos.Add(sixShapeArea);
        }
    }
}
