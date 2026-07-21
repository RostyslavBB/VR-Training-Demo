using Gameplay.Core;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace Gameplay.Interactions
{
    [RequireComponent(typeof(XRSimpleInteractable))]
    public class PowerButton : MonoBehaviour
    {
        private XRSimpleInteractable _interactable;

        private void Awake()
        {
            _interactable = GetComponent<XRSimpleInteractable>();

            _interactable.selectEntered.AddListener(OnPressed);
        }

        private void OnDestroy()
        {
            _interactable.selectEntered.RemoveListener(OnPressed);
        }

        private void OnPressed(SelectEnterEventArgs args)
        {
            GameEvents.RaiseButtonPressed();
        }
    }
}