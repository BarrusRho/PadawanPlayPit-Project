using System.Collections;
using System.Collections.Generic;
using PadawanPlayPit.PooledObjects;
using UnityEngine;
using UnityEngine.Pool;

namespace PadawanPlayPit.Management
{
    public class SpawnManager : MonoBehaviour
    {
        private static SpawnManager _instance;
        public static SpawnManager Instance => _instance;

        [Header("Basic Explosions Particles")]
        [SerializeField] private BasicExplosionsParticles _basicExplosionsParticlesPrefab;
        [SerializeField] private Transform _basicExplosionsParticlesSpawnPoint;
        [SerializeField] private int _basicExplosionsParticlesSpawnAmount = 30;
        [SerializeField] private float _basicExplosionsParticlesSphereRadiusSize = 5f;

        [Header("Basic Explosions VFX Graph")]
        [SerializeField] private BasicExplosionsVFXGraph _basicExplosionsVFXGraphPrefab;
        [SerializeField] private Transform _basicExplosionsVFXGraphSpawnPoint;
        [SerializeField] private int _basicExplosionsVFXGraphSpawnAmount = 30;
        [SerializeField] private float _basicExplosionsVFXGraphSphereRadiusSize = 5f;

        [SerializeField] private float _staggerIntervalTimeMinimum = 0.1f;
        [SerializeField] private float _staggerIntervalTimeMaximum = 0.5f;

        private ObjectPool<BasicExplosionsParticles> _basicExplosionsParticlesPool;
        private ObjectPool<BasicExplosionsVFXGraph> _basicExplosionsVFXGraphPool;

        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else if (_instance != null)
            {
                Destroy(this.gameObject);
            }
        }

        private void Start()
        {
            CreateBasicExplosionsParticlesPool();
            CreateBasicExplosionsVFXGraphPool();
        }

        private void CreateBasicExplosionsParticlesPool()
        {
            _basicExplosionsParticlesPool = new ObjectPool<BasicExplosionsParticles>(
                () => { return Instantiate(_basicExplosionsParticlesPrefab); },
                pooledBasicExplosionsParticles => { pooledBasicExplosionsParticles.gameObject.SetActive(true); },
                pooledBasicExplosionsParticles => { pooledBasicExplosionsParticles.gameObject.SetActive(false); },
                pooledBasicExplosionsParticles => { Destroy(pooledBasicExplosionsParticles.gameObject); }, false, 50, 100);
        }

        public void SpawnBasicExplosionsParticlesFromPool()
        {
            for (int i = 0; i < _basicExplosionsParticlesSpawnAmount; i++)
            {
                var basicExplosionsParticle = _basicExplosionsParticlesPool.Get();
                basicExplosionsParticle.transform.position = _basicExplosionsParticlesSpawnPoint.transform.position +
                                                      Random.insideUnitSphere * _basicExplosionsParticlesSphereRadiusSize;
                basicExplosionsParticle.InitialiseBasicExplosionsParticlesForPool(ReturnBasicExplosionsParticlesToPool);
            }
        }

        public void SpawnBasicExplosionsParticlesFromPoolWithRandomInterval()
        {
            StartCoroutine(SpawnBasicExplosionsParticlesRoutine());
        }

        private IEnumerator SpawnBasicExplosionsParticlesRoutine()
        {
            for (int i = 0; i < _basicExplosionsParticlesSpawnAmount; i++)
            {
                yield return new WaitForSeconds(Random.Range(_staggerIntervalTimeMinimum, _staggerIntervalTimeMaximum));

                var basicExplosionsParticles = _basicExplosionsParticlesPool.Get();
                basicExplosionsParticles.transform.position = _basicExplosionsVFXGraphSpawnPoint.transform.position +
                                                            Random.insideUnitSphere * _basicExplosionsVFXGraphSphereRadiusSize;
                basicExplosionsParticles.InitialiseBasicExplosionsParticlesForPool(ReturnBasicExplosionsParticlesToPool);
            }
        }

        public void ReturnBasicExplosionsParticlesToPool(BasicExplosionsParticles basicExplosionsParticles)
        {
            _basicExplosionsParticlesPool.Release(basicExplosionsParticles);
        }

        private void CreateBasicExplosionsVFXGraphPool()
        {
            _basicExplosionsVFXGraphPool = new ObjectPool<BasicExplosionsVFXGraph>(
                () => { return Instantiate(_basicExplosionsVFXGraphPrefab); },
                pooledBasicExplosionsVFXGraph => { pooledBasicExplosionsVFXGraph.gameObject.SetActive(true); },
                pooledBasicExplosionsVFXGraph => { pooledBasicExplosionsVFXGraph.gameObject.SetActive(false); },
                pooledBasicExplosionsVFXGraph => { Destroy(pooledBasicExplosionsVFXGraph.gameObject); }, false, 50, 100);
        }

        public void SpawnBasicExplosionsVFXGraphFromPool()
        {
            for (int i = 0; i < _basicExplosionsVFXGraphSpawnAmount; i++)
            {
                var basicExplosionsVFXGraph = _basicExplosionsVFXGraphPool.Get();
                basicExplosionsVFXGraph.transform.position = _basicExplosionsVFXGraphSpawnPoint.transform.position +
                                                      Random.insideUnitSphere * _basicExplosionsVFXGraphSphereRadiusSize;
                basicExplosionsVFXGraph.InitialiseBasicExplosionsVFXGraphForPool(ReturnBasicExplosionsVFXGraphToPool);
            }
        }

        public void SpawnBasicExplosionsVFXGraphFromPoolWithRandomInterval()
        {
            StartCoroutine(SpawnBasicExplosionsVFXGraphRoutine());
        }

        private IEnumerator SpawnBasicExplosionsVFXGraphRoutine()
        {
            for (int i = 0; i < _basicExplosionsVFXGraphSpawnAmount; i++)
            {
                yield return new WaitForSeconds(Random.Range(_staggerIntervalTimeMinimum, _staggerIntervalTimeMaximum));

                var basicExplosionsVFXGraph = _basicExplosionsVFXGraphPool.Get();
                basicExplosionsVFXGraph.transform.position = _basicExplosionsVFXGraphSpawnPoint.transform.position +
                                                            Random.insideUnitSphere * _basicExplosionsVFXGraphSphereRadiusSize;
                basicExplosionsVFXGraph.InitialiseBasicExplosionsVFXGraphForPool(ReturnBasicExplosionsVFXGraphToPool);
            }
        }

        public void ReturnBasicExplosionsVFXGraphToPool(BasicExplosionsVFXGraph basicExplosionsVFXGraph)
        {
            _basicExplosionsVFXGraphPool.Release(basicExplosionsVFXGraph);
        }
    }
}

