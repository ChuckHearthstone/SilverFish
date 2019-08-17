using System;

namespace SilverFish.ai
{
    public class CustomEventManager
    {
        private CustomEventManager()
        {

        }

        public static CustomEventManager Instance { get; } = new CustomEventManager();

        public EventHandler MulliganStarted { get; set; }

        public void OnMulliganStarted()
        {
            MulliganStarted?.Invoke(this, EventArgs.Empty);
        }
    }
}
