using Gameplay.Core;
using Gameplay.Training;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using Zenject;

namespace Gameplay.Interactions
{
    [RequireComponent(typeof(XRSimpleInteractable))]
    public class Lever : MonoBehaviour
    {
        [SerializeField] private Light _indicatorLight;

        [Inject] private readonly TrainingManager _trainingManager;

        private bool _isOn;

        private XRSimpleInteractable _interactable;

        private void Awake()
        {
            _interactable = GetComponent<XRSimpleInteractable>();
            _interactable.selectEntered.AddListener(OnLeverPulled);
        }

        private void OnDestroy()
        {
            _interactable.selectEntered.RemoveListener(OnLeverPulled);
        }

        private void OnLeverPulled(SelectEnterEventArgs args)
        {
            Toggle();
        }

        public void Toggle()
        {
            if (_trainingManager.State != TrainingState.PullLever)
                return;

            if (_isOn)
                return;

            _isOn = true;

            transform.localRotation = Quaternion.Euler(-45, 0, 0);

            _indicatorLight.color = Color.green;
            _indicatorLight.enabled = true;

            GameEvents.RaiseLeverPulled();
        }
    }
}