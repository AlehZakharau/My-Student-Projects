using System;
using Pool.Factory;
using UnityEngine;

namespace Pool
{
    public abstract class ComponentPoolSO<T> : Pool<T> where T : Component
    {
        private Transform poolRoot;

        public Transform PoolRoot
        {
            get
            {
                if (poolRoot == null)
                {
                    poolRoot = new GameObject(name).transform;
                    poolRoot.SetParent(parent);
                }
                return poolRoot;
            }
        }

        private Transform parent;


        /// <summary>
        /// Parents the pool root transform to <paramref name="t"/>.
        /// </summary>
        /// <param name="t">The Transform to which this pool should become a child.</param>
        /// <remarks>NOTE: Setting the parent to an object marked DontDestroyOnLoad will effectively make this pool DontDestroyOnLoad.<br/>
        /// This can only be circumvented by manually destroying the object or its parent or by setting the parent to an object not marked DontDestroyOnLoad.</remarks>
        public void SetParent(Transform t)
        {
            parent = t;
            PoolRoot.SetParent(parent);
        }

        public override T Request()
        {
            var member = base.Request();
            member.gameObject.SetActive(true);
            return member;
        }

        public override void Return(T member)
        {
            member.transform.SetParent(PoolRoot.transform);
            member.gameObject.SetActive(false);
            base.Return(member);
        }

        protected override T Create()
        {
            var newMember = base.Create();
            newMember.transform.SetParent(PoolRoot.transform);
            newMember.gameObject.SetActive(false);
            return newMember;
        }

        public override void OnDisable()
        {
            base.OnDisable();
            if (poolRoot != null)
            {
                Destroy(poolRoot.gameObject);
            }
        }

        public override void DestroyPool()
        {
            base.DestroyPool();
            if (poolRoot != null)
            {
                Destroy(poolRoot.gameObject);
            }
        }
    }
}