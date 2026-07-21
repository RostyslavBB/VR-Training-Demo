using System;

namespace Gameplay.Core
{
    public static class GameEvents
    {
        public static event Action KeyPicked;
        public static event Action KeyInserted;
        public static event Action ButtonPressed;
        public static event Action LeverPulled;

        public static void RaiseKeyPicked()
        {
            KeyPicked?.Invoke();
        }

        public static void RaiseKeyInserted()
        {
            KeyInserted?.Invoke();
        }

        public static void RaiseButtonPressed()
        {
            ButtonPressed?.Invoke();
        }

        public static void RaiseLeverPulled()
        {
            LeverPulled?.Invoke();
        }
    }
}