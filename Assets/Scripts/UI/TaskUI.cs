using Gameplay.Training;
using TMPro;
using UnityEngine;
using Zenject;

namespace Gameplay.UI
{
    public class TaskUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _taskText;

        [Inject] private readonly TrainingManager _trainingManager;

        private void OnEnable()
        {
            _trainingManager.StateChanged += UpdateTask;

            UpdateTask(_trainingManager.State);
        }

        private void OnDisable()
        {
            _trainingManager.StateChanged -= UpdateTask;
        }

        private void UpdateTask(TrainingState state)
        {
            _taskText.text = state switch
            {
                TrainingState.FindKey => "Find the key",
                TrainingState.InsertKey => "Insert the key",
                TrainingState.PressButton => "Press the button",
                TrainingState.PullLever => "Pull the lever",
                TrainingState.Completed => "Training Completed!",
                _ => string.Empty
            };
        }
    }
}