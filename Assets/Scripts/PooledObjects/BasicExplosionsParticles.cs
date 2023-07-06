using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PadawanPlayPit.PooledObjects
{
    public class BasicExplosionsParticles : MonoBehaviour
    {
        [SerializeField] private float _returnToPoolDelayTime = 1f;

        private Action<BasicExplosionsParticles> _poolingAction;

        private void OnEnable()
        {
            StartCoroutine(ReturnToPoolDelayCoroutine());
        }

        public void InitialiseBasicExplosionsParticlesForPool(Action<BasicExplosionsParticles> poolingAction)
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
