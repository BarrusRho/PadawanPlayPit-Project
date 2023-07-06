using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PadawanPlayPit.PooledObjects
{
    public class BasicExplosionsVFXGraph : MonoBehaviour
    {
        [SerializeField] private float _returnToPoolDelayTime = 1f;

        private Action<BasicExplosionsVFXGraph> _poolingAction;

        private void OnEnable()
        {
            StartCoroutine(ReturnToPoolDelayCoroutine());
        }

        public void InitialiseBasicExplosionsVFXGraphForPool(Action<BasicExplosionsVFXGraph> poolingAction)
        {
            _poolingAction = poolingAction;
        }

        private IEnumerator ReturnToPoolDelayCoroutine()
        {
            yield return new WaitForSeconds(_returnToPoolDelayTime);
            _poolingAction(this);
        }
    }
}
