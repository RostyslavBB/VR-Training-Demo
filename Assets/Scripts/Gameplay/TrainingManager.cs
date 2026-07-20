using UnityEngine;

namespace Gameplay.Training
{
    public class TrainingManager : MonoBehaviour
    {
        public TrainingState State { get; private set; } = TrainingState.FindKey;

        public bool HasKey { get; private set; }

        public void PickUpKey()
        {
            if (State != TrainingState.FindKey)
                return;

            HasKey = true;
            State = TrainingState.InsertKey;

            Debug.Log("FindKey");
        }

        public void KeyInserted()
        {
            if (State != TrainingState.InsertKey)
                return;

            State = TrainingState.PressButton;

            Debug.Log("InsertKey");
        }
    }
}