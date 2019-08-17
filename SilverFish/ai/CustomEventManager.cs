using System;

namespace SilverFish.ai
{
    public class CustomEventManager
    {
        private CustomEventManager()
        {

        }

        public static CustomEventManager Instance { get; } = new CustomEventManager();

        public event EventHandler MulliganStarted;

        public void OnMulliganStarted()
        {
            MulliganStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}
