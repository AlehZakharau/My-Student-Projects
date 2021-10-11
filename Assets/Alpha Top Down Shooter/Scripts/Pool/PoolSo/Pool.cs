using System;
using System.Collections;
using System.Collections.Generic;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    public abstract class Pool<T> : ScriptableObject
    {
        protected readonly Stack<T> Available = new Stack<T>();
        
        /// <summary>
        /// The factory which will be used to create <typeparamref name="T"/> on demand.
        /// </summary>
        public abstract IFactory<T> Factory { get; set; }
        
        protected bool HasBeenPreWarmed { get; set; }

        protected virtual T Create()
        {
            return Factory.Create();
        }


        /// <summary>
        /// Prewarms the pool with a <paramref name="num"/> of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="num">The number of members to create as a part of this pool.</param>
        /// <remarks>NOTE: This method can be called at any time, but only once for the lifetime of the pool.</remarks>
        public virtual void PreWarm(int num)
        {
            if (HasBeenPreWarmed)
            {
                Debug.LogWarning($"Pool {name} has already been prewarmed");
                return;
            }

            for (int i = 0; i < num; i++)
            {
                Available.Push(Create());
            }
            HasBeenPreWarmed = true;
        }

        /// <summary>
        /// Requests a <typeparamref name="T"/> from this pool.
        /// </summary>
        /// <returns>The requested <typeparamref name="T"/>.</returns>
        public virtual T Request()
        {
            return Available.Count > 0 ? Available.Pop() : Create();
        }

        /// <summary>
        /// Returns a <typeparamref name="T"/> to the pool.
        /// </summary>
        /// <param name="member">The <typeparamref name="T"/> to return.</param>
        public virtual void Return(T member)
        {
            Available.Push(member);
        }

        public virtual void OnDisable()
        {
            Available.Clear();
            HasBeenPreWarmed = false;
        }

        public virtual void DestroyPool()
        {
            Available.Clear();
            HasBeenPreWarmed = false;
        }
    }
}