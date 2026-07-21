using Gameplay.Core;
using System;
using UnityEngine;

namespace Gameplay.Training
{
    public class TrainingManager : MonoBehaviour
    {
        public event Action<TrainingState> StateChanged;

        public TrainingState State { get; private set; } = TrainingState.FindKey;
        public bool HasKey { get; private set; }

        private void OnEnable()
        {
            GameEvents.KeyPicked += PickUpKey;
            GameEvents.KeyInserted += KeyInserted;
            GameEvents.ButtonPressed += PressButton;
            GameEvents.LeverPulled += CompleteTraining;
        }

        private void OnDisable()
        {
            GameEvents.KeyPicked -= PickUpKey;
            GameEvents.KeyInserted -= KeyInserted;
            GameEvents.ButtonPressed -= PressButton;
            GameEvents.LeverPulled -= CompleteTraining;
        }

        private void PickUpKey()
        {
            if (State != TrainingState.FindKey)
                return;

            HasKey = true;
            SetState(TrainingState.InsertKey);

            Debug.Log("Key picked");
        }

        private void KeyInserted()
        {
            if (State != TrainingState.InsertKey)
                return;

            SetState(TrainingState.PressButton);

            Debug.Log("Key inserted");
        }

        private void PressButton()
        {
            if (State != TrainingState.PressButton)
                return;

            SetState(TrainingState.PullLever);

            Debug.Log("Button pressed");
        }

        private void CompleteTraining()
        {
            if (State != TrainingState.PullLever)
                return;

            SetState(TrainingState.Completed);

            Debug.Log("Training Completed");
        }

        private void SetState(TrainingState state)
        {
            State = state;
            StateChanged?.Invoke(state);
        }
    }
}