using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
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
        private static readonly ConcurrentDictionary<CardDB.cardIDEnum, NotImplementedInfo> NotImplementedCards =
            new ConcurrentDictionary<CardDB.cardIDEnum, NotImplementedInfo>();

        private static readonly Dictionary<CardDB.cardIDEnum, CardDB.Card> SingleGameCards =
            new Dictionary<CardDB.cardIDEnum, CardDB.Card>();

        public static void Add(CardDB.Card card)
        {
            var key = card.cardIDenum;
            if (!SingleGameCards.ContainsKey(key))
            {
                SingleGameCards.Add(key, card);
            }
        }

        public static void GameOver()
        {
            var list = SingleGameCards.ToList();
            SingleGameCards.Clear();
            foreach (var item in list)
            {
                AddToSummary(item.Value);
            }
        }

        private static void AddToSummary(CardDB.Card card)
        {
            var key = card.cardIDenum;
            NotImplementedInfo info;

            if (NotImplementedCards.ContainsKey(key))
            {
                info = NotImplementedCards[key];
            }
            else
            {
                info = new NotImplementedInfo { Card = card };
            }
            info.Counter++;

            NotImplementedCards.AddOrUpdate(key, info, (k, v) => v);
        }

        public static void Save()
        {
            if (NotImplementedCards.Count == 0)
            {
                if (SingleGameCards.Count == 0)
                {
                    Helpfunctions.Instance.ErrorLog($"Didn't find cards that not implemented when stop bot.");
                }
                else
                {
                    var array1 = SingleGameCards.Values.Select(x => $"cardId = {x.cardIDenum}, cardName = {x.name}");
                    var result1 = string.Join(Environment.NewLine, array1);
                    LogHelper.WriteNotImplementedCardSimulationLog(result1);
                }

                return;
            }

            var list = NotImplementedCards.Values.OrderByDescending(x => x.Counter);
            var array = list.Select(x =>
                $"count = {x.Counter}, cardId = {x.Card.cardIDenum}, cardName = {x.Card.name}");
            var result = string.Join(Environment.NewLine, array);
            LogHelper.WriteNotImplementedCardSimulationLog(result);
        }

    }
}
