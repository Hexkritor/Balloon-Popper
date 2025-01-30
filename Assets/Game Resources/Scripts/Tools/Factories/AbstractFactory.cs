using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.Tools.Factories
{
    public abstract class AbstractFactory<T>: MonoBehaviour where T:MonoBehaviour
    {
        public abstract T Create();

        public abstract T Create(Transform parent);

        public abstract void ResetObject(T target);
    }
}
