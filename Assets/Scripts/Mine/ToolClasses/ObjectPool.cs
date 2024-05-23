using System.Collections.Generic;
using UnityEngine;

namespace Mine.ToolClasses
{
    public class ObjectPool<T>where T : Component
    {
        private readonly T mInitElement;
        private readonly Stack<T> mStackElement;
        public ObjectPool(T initElement)
        {
            mStackElement = new Stack<T>();
            this.mInitElement = initElement;
        }

        public T Get()
        {
            var item = mStackElement.Count == 0 ? Object.Instantiate(mInitElement.gameObject).GetComponent<T>() : mStackElement.Pop();

            item.gameObject.SetActive(true);
            return item;
        }

        public T Get(Transform transformParent)
        {
            var item = mStackElement.Count == 0 ? Object.Instantiate(mInitElement.gameObject).GetComponent<T>() : mStackElement.Pop();
            
            Transform transform;
            (transform = item.transform).SetParent(transformParent);
            transform.localScale = Vector3.one;
            item.gameObject.SetActive(true);
            return item;
        }

        public void Recycle(T recycledElement)
        {
            recycledElement.gameObject.SetActive(false);
            mStackElement.Push(recycledElement);
        }
    }
}
