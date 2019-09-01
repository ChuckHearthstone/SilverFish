using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class NotImplementedInfo
    {
        public CardDB.Card Card { get; set; }

        public int Counter { get; set; }
    }

    public class NotImplementedSimHelper
    {
        private static ConcurrentDictionary<CardDB.cardIDEnum, NotImplementedInfo> NotImplementedCards =
            new ConcurrentDictionary<CardDB.cardIDEnum, NotImplementedInfo>();

        public static void Add(CardDB.Card card)
        {
            var key = card.cardIDenum;
            NotImplementedInfo info;

            if (NotImplementedCards.ContainsKey(key))
            {
                info = NotImplementedCards[key];
            }
            else
            {
                info = new NotImplementedInfo();
            }
            info.Counter++;

            NotImplementedCards.AddOrUpdate(key, info, (k, v) => v);
        }

        public static void Save()
        {
            if (NotImplementedCards.Count == 0)
            {
                Helpfunctions.Instance.ErrorLog($"Didn't find cards that not implemented when stop bot.");
                return;
            }
            StringBuilder stringBuilder = new StringBuilder();
            var list = NotImplementedCards.Values.OrderByDescending(x => x.Counter);
            var array = list.Select(x => $"count = {x.Counter}, cardId = {x.Card.cardIDenum}, cardName = {x.Card.name}");
            var result = string.Join(Environment.NewLine, array);
            LogHelper.WriteNotImplementedCardSimulationLog(result);
        }

    }
}
