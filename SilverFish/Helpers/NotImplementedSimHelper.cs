using System.Collections.Concurrent;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class NotImplementedSimHelper
    {
        public static ConcurrentDictionary<CardDB.cardIDEnum, int> Dictionary =
            new ConcurrentDictionary<CardDB.cardIDEnum, int>();
    }
}
