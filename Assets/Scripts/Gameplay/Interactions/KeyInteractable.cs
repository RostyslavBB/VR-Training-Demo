using Gameplay.Core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Gameplay.Interactions
{
    [RequireComponent(typeof(XRGrabInteractable))]
    public class KeyInteractable : MonoBehaviour
    {
        private XRGrabInteractable _grabInteractable;

        private void Awake()
        {
            _grabInteractable = GetComponent<XRGrabInteractable>();

            _grabInteractable.selectEntered.AddListener(OnGrabbed);
        }

        private void OnGrabbed(SelectEnterEventArgs args)
        {
            GameEvents.RaiseKeyPicked();
        }

        private void OnDestroy()
        {
            _grabInteractable.selectEntered.RemoveListener(OnGrabbed);
        }
    }
}