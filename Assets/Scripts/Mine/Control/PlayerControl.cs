using System.Collections;
using UnityEngine;
using Mine.ObjectPoolItem;
using System.Collections.Generic;
using DG.Tweening;
using Mine.ToolClasses;

namespace Mine.Control
{
    public class PlayerControl:MonoBehaviour
    {
        public Transform transformDropPanel;
        public Transform transformPrefab;
        
        public List<Transform> panelAllPos;

        private void Awake()
        {
            FindComponent();
            CommonMembers.InitValue();
            for (int i = 0; i < 200; i++)
            {
                panelAllPos.Add(null);
            }
            
            //初始化对象池
            for (int i = 0; i < 7; i++)
            {
                CommonMembers.ShapePool[i] = new ObjectPool<ItemShape>(transformPrefab.GetChild(i).GetComponent<ItemShape>());
            }
            CommonMembers.blockPool = new ObjectPool<Transform>(transformPrefab.Find("block"));
        }

        private void FindComponent()
        {
            transformDropPanel = transform.Find("BlockDropArea/DropPanel");
            transformPrefab = transform.Find("Prefab");
        }
        private void OnEnable()
        {
            StartTetris();
        }

        private void StartTetris()
        {
            var item = CommonMembers.ShapePool[0].Get(transformDropPanel);
            StartCoroutine(BlockDrop(item));
        }

        IEnumerator BlockDrop(ItemShape item)
        {
            for (int i = 0; i < 19; i++)
            {
                item.transform.DOLocalMoveY(item.transform.localPosition.y - 45, 0.05f);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}