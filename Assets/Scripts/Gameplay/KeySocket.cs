using Gameplay.Training;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

namespace Gameplay.Interactions
{
    [RequireComponent(typeof(XRSocketInteractor))]
    public class KeySocket : MonoBehaviour
    {
        [SerializeField] private Door _door;
        [SerializeField] private TrainingManager _trainingManager;

        private XRSocketInteractor _socketInteractor;

        private void Awake()
        {
            _socketInteractor = GetComponent<XRSocketInteractor>();

            _socketInteractor.selectEntered.AddListener(OnInserted);
        }

        private void OnDestroy()
        {
            _socketInteractor.selectEntered.RemoveListener(OnInserted);
        }

        private void OnInserted(SelectEnterEventArgs args)
        {
            Debug.Log("Key inserted");

            _door.Open();

            _trainingManager.KeyInserted();
        }
    }
}