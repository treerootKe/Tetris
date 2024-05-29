using System.Collections.Generic;
using UnityEngine;

namespace Mine.ToolClasses
{
    public class ObjectPool<T>where T : Component
    {
        private readonly T mInitElement;
        private readonly Stack<T> mElementStack;
        public ObjectPool(T initElement)
        {
            mElementStack = new Stack<T>();
            mInitElement = initElement;
        }

        public T Get()
        {
            var item = mElementStack.Count == 0 ? Object.Instantiate(mInitElement.gameObject).GetComponent<T>() : mElementStack.Pop();

            item.gameObject.SetActive(true);
            return item;
        }

        public T Get(Transform transformParent)
        {
            var item = mElementStack.Count == 0 ? Object.Instantiate(mInitElement.gameObject).GetComponent<T>() : mElementStack.Pop();
            
            Transform transform;
            (transform = item.transform).SetParent(transformParent);
            transform.localScale = Vector3.one;
            item.gameObject.SetActive(true);
            return item;
        }

        public void Recycle(T recycledElement)
        {
            recycledElement.gameObject.SetActive(false);
            mElementStack.Push(recycledElement);
        }
    }
}
