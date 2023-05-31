using UnityEngine;

namespace PadawanPlayPit.Utility
{
    public class ParticlePlayer : MonoBehaviour
    {
        [SerializeField] private ParticleSystem[] _allParticleSystems;

        private void Awake()
        {
            _allParticleSystems = GetComponentsInChildren<ParticleSystem>();
        }

        private void Start()
        {
            PlayParticles();
        }

        public void PlayParticles()
        {
            foreach (var particle in _allParticleSystems)
            {
                particle.Stop();
                particle.Play();
            }
        }
    }
}
