using System;
using System.Collections.Generic;
using System.IO;
using SilverFish.Enums;
using SilverFish.Helpers;

namespace HREngine.Bots
{
    public partial class CardDB
    {
        public Dictionary<CardIdEnum,CardName> SpecialNames { get; set; }

        public void InitSpecialNames()
        {
            SpecialNames = new Dictionary<CardIdEnum, CardName>();
            string path = Settings.Instance.DataFolderPath;
			string specialCardNamePath = Path.Combine(path, "special_card_name.txt");
			string[] lines = File.ReadAllLines(specialCardNamePath);
            Helpfunctions.Instance.InfoLog("read special_card_name.txt " + lines.Length + " lines");
            foreach (var item in lines)
            {
                var array = item.Split('-');
                if (array.Length != 2)
                {
                    throw new Exception($"{item} can not be parsed for special name");
                }

                string key = array[0];
                string value = array[1];
                var tempCardIdEnum = (CardIdEnum) Enum.Parse(typeof(CardIdEnum), key);
                var tempCardNameEnum = (CardName) Enum.Parse(typeof(CardName), value);
                SpecialNames.Add(tempCardIdEnum, tempCardNameEnum);
            }
        }

        public CardName GetSpecialCardNameEnumFromCardIdEnum(CardIdEnum tempCardIdEnum)
        {
            if (SpecialNames.ContainsKey(tempCardIdEnum))
            {
                return SpecialNames[tempCardIdEnum];
            }
            else
            {
                return CardName.unknown;
            }
        }
    }
}
