using Gameplay.Training;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Gameplay.Interactions
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class KeyInteractable : MonoBehaviour
    {
        [SerializeField] private TrainingManager _trainingManager;

        private XRGrabInteractable _grabInteractable;

        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();

            _grabInteractable.selectEntered.AddListener(OnGrabbed);
        }

        private void OnGrabbed(SelectEnterEventArgs args)
        {
            _trainingManager.PickUpKey();
        }

        private void OnDestroy()
        {
            _grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}