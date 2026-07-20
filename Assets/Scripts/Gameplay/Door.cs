using Gameplay.Training;
using UnityEngine;

namespace Gameplay.Interactions
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private TrainingManager _trainingManager;

        private bool _opened;

        public void Open()
        {
            if (_opened)
                return;

            if (!_trainingManager.HasKey)
            {
                Debug.Log("Door is locked");
                return;
            }

            _opened = true;

            transform.Rotate(0, 90, 0);

            Debug.Log("Door opened");
        }
    }
}