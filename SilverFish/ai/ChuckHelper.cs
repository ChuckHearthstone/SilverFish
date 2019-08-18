using System.Collections.Generic;

namespace HREngine.Bots.SilverFish.AI
{
    public class ChuckHelper
    {
        public static bool EvenShamanChecked { get; set; }

        public static bool IsEvenShaman { get; set; }

        public static void Reset()
        {
            EvenShamanChecked = false;
            IsEvenShaman = false;
        }

        public static void EvenShamanCheck(Dictionary<CardDB.cardIDEnum, int> dictionary)
        {
            if (EvenShamanChecked)
            {
                return;
            }

            bool isEvenShaman = true;
            foreach (var item in dictionary.Keys)
            {
                var card = CardDB.Instance.getCardDataFromID(item);
                if (card.cost % 2 != 0)
                {
                    isEvenShaman = false;
                    break;
                }
            }

            if (isEvenShaman)
            {
                IsEvenShaman = true;
            }

            EvenShamanChecked = true;
        }
    }
}
