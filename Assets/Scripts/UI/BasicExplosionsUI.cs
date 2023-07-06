using System.Collections;
using System.Collections.Generic;
using PadawanPlayPit.Management;
using UnityEngine;
using UnityEngine.UI;

namespace PadawanPlayPit.UI
{
    public class BasicExplosionsUI : MonoBehaviour
    {
        [SerializeField] private Button _basicExplosionsParticlesImmediateButton;
        [SerializeField] private Button _basicExplosionsParticlesIntervalsButton;
        [SerializeField] private Button _basicExplosionsVFXGraphImmediateButton;
        [SerializeField] private Button _basicExplosionsVFXGraphIntervalsButton;

        [SerializeField] private float _buttonDisableTime = 1.5f;

        private void Awake()
        {
            _basicExplosionsParticlesImmediateButton.onClick.AddListener(() => 
            {
                SpawnManager.Instance.SpawnBasicExplosionsParticlesFromPool();
                StartCoroutine(TemporarilyDisableButtonRoutine());
            });

            _basicExplosionsParticlesIntervalsButton.onClick.AddListener(() =>
            {
                SpawnManager.Instance.SpawnBasicExplosionsParticlesFromPoolWithRandomInterval();
                StartCoroutine(TemporarilyDisableButtonRoutine());
            });

            _basicExplosionsVFXGraphImmediateButton.onClick.AddListener(() =>
            {
                SpawnManager.Instance.SpawnBasicExplosionsVFXGraphFromPool();
                StartCoroutine(TemporarilyDisableButtonRoutine());
            });

            _basicExplosionsVFXGraphIntervalsButton.onClick.AddListener(() =>
            {
                SpawnManager.Instance.SpawnBasicExplosionsVFXGraphFromPoolWithRandomInterval();
                StartCoroutine(TemporarilyDisableButtonRoutine());
            });
        }

        private IEnumerator TemporarilyDisableButtonRoutine()
        {
            _basicExplosionsParticlesImmediateButton.interactable = false;
            _basicExplosionsParticlesIntervalsButton.interactable = false;
            _basicExplosionsVFXGraphImmediateButton.interactable = false;
            _basicExplosionsVFXGraphIntervalsButton.interactable = false;
            yield return new WaitForSeconds(_buttonDisableTime);
            _basicExplosionsParticlesImmediateButton.interactable = true;
            _basicExplosionsParticlesIntervalsButton.interactable = true;
            _basicExplosionsVFXGraphImmediateButton.interactable = true;
            _basicExplosionsVFXGraphIntervalsButton.interactable = true;
        }
    }
}
