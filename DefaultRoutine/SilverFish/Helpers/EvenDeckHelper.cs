using System.Collections.Generic;
using System.Linq;
using HREngine.Bots;

namespace SilverFish.Helpers
{
    public class EvenDeckHelper
    {
        public static bool EvenDeckChecked { get; set; }

        public static bool IsEvenDeck { get; set; }

        public static void Reset()
        {
            EvenDeckChecked = false;
            IsEvenDeck = false;
        }

        public static void EvenShamanCheck(Dictionary<CardDB.CardIdEnum, int> dictionary)
        {
            if (EvenDeckChecked)
            {
                return;
            }

            if (dictionary.Keys.Contains(CardDB.CardIdEnum.GIL_692))
            {
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
                    IsEvenDeck = true;
                }
            }

            EvenDeckChecked = true;
        }

        public static int GetOwnHeroPowerCost()
        {
            if (EvenDeckChecked && IsEvenDeck)
            {
                return 1;
            }

            return 2;
        }
    }
}
