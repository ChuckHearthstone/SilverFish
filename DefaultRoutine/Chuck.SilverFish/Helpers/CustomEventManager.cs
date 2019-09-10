using System;

namespace SilverFish.Helpers
{
    public class MulliganStartedEventArgs
    {
        public bool ConcedeSuccessfully { get; set; }
    }

    public class CustomEventManager
    {
        private CustomEventManager()
        {

        }

        public static CustomEventManager Instance { get; } = new CustomEventManager();

        public event EventHandler<MulliganStartedEventArgs> MulliganStarted;

        public bool OnMulliganStarted()
        {
            MulliganStartedEventArgs eventArgs = new MulliganStartedEventArgs();
            MulliganStarted?.Invoke(this, eventArgs);
            return eventArgs.ConcedeSuccessfully;
        }
    }
}
