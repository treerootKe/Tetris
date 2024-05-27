using UnityEngine;
using Mine.ObjectPoolItem;
using System.Collections.Generic;

namespace Mine.Control
{
    public class PlayerControl:MonoBehaviour
    {
        public List<Transform> panelAllPos;     //200¸ö·½¿é
        void Awake()
        {
            for (int i = 0; i < 200; i++)
            {
                panelAllPos.Add(null);
            }
        }
        private void OnEnable()
        {
            
        }
    }
}