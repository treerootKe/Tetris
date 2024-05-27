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
    public abstract class CommonMembers
    {
        public static readonly ObjectPool<ItemShape>[] ShapePool = new ObjectPool<ItemShape>[7];
        public static ObjectPool<Transform> blockPool;
        public static readonly List<List<Vector2[]>> BlockChangeInsidePos = new List<List<Vector2[]>>();//形状改变后内部位置集合 
        
        public static void InitValue()
        {
            //I
            var shapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90), new Vector2(135, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90), new Vector2(90, 135) },
                new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(90, 45), new Vector2(135, 45) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(45, 90), new Vector2(45, 135) }
            };
            BlockChangeInsidePos.Add(shapeArea);
            //T
            var oneShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(45, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(45, 45), new Vector2(0, 90) }
            };
            BlockChangeInsidePos.Add(oneShapeArea);
            //L
            var twoShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(90, 45), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(90, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(0, 90) }
            };
            BlockChangeInsidePos.Add(twoShapeArea);
            //J
            var threeShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(90, 45), new Vector2(0, 90), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(90, 0), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(90, 0), new Vector2(0, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(0, 45), new Vector2(0, 90), new Vector2(45, 90) }
            };
            BlockChangeInsidePos.Add(threeShapeArea);
            //Z
            var fourShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0, 45), new Vector2(45, 45), new Vector2(45, 90), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(90, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(45, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(90, 0), new Vector2(0, 45), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45), new Vector2(0, 90) }
            };
            BlockChangeInsidePos.Add(fourShapeArea);
            //S
            var fiveShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(45, 45), new Vector2(90, 45), new Vector2(0, 90), new Vector2(45, 90) },
                new Vector2[4] { new Vector2(45, 0), new Vector2(45, 45), new Vector2(90, 45), new Vector2(90, 90) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(45, 0), new Vector2(45, 45), new Vector2(90, 45) },
                new Vector2[4] { new Vector2(0, 0), new Vector2(0, 45), new Vector2(45, 45), new Vector2(45, 90) }
            };
            BlockChangeInsidePos.Add(fiveShapeArea);
            //O
            var sixShapeArea = new List<Vector2[]>
            {
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45) },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45)  },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45)  },
                new Vector2[4] { new Vector2(0 , 0), new Vector2(45, 0), new Vector2(0, 45), new Vector2(45, 45) }
            };
            BlockChangeInsidePos.Add(sixShapeArea);
        }
    }
}
