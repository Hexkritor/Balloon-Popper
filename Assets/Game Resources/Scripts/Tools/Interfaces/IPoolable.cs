using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Hexkritor.Tools.Interfaces
{
    public interface IPoolable<T> where T: MonoBehaviour
    {
        public ObjectPool<T> Pool { get; set; }


        public abstract void Get();

        public abstract void Release();
    }
}
