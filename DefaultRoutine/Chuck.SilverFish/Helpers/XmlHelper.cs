using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using SilverFish.Enums;
using Card = Chuck.SilverFish.CardDB.Card;

namespace SilverFish.Helpers
{
    public class XmlHelper
    {
        private static XElement _cardDatabase;

        private static string culture = "en-US";

        private static CultureInfo defaultCultureInfo = new CultureInfo(culture, false);

        public static XElement GetTagElementByName(XElement element, string tagName)
        {
            var targetElement = element?.Elements("Tag")
                .FirstOrDefault(x => x.Attribute("name")?.Value.ToLower(defaultCultureInfo) == tagName);
            return targetElement;
        }

        public static string GetAttributeByXElement(XElement element, string attributeName)
        {
            var attribute = element.Attributes()
                .FirstOrDefault(x => x.Name.LocalName.ToLower(defaultCultureInfo) == attributeName);
            var value = attribute?.Value;
            if (string.IsNullOrEmpty(value))
            {
                throw new Exception($"Can not find value by attribute name [{attributeName}] through {element}");
            }

            return value;
        }

        public static string GetLocStringByXElement(XElement element, string propertyName,CultureInfo tempCultureInfo)
        {
            var tempTargetElement2 = element?.Elements("Tag")
                .FirstOrDefault(x => x.Attribute("name")?.Value == propertyName);
            var cultureName = tempCultureInfo.Name.Replace("-", string.Empty);
            XElement targetElement = tempTargetElement2?.Element(cultureName);
            if (targetElement == null)
            {
                //ART_BOT_Bundle_001
                //throw new Exception($"Can not find LocString for card property [{propertyName}] through {element}");
            }

            return targetElement?.Value;
        }

        public static Dictionary<CardIdEnum, Card> GetCards(string filePath)
        {
            Dictionary<CardIdEnum, Card> cards = new Dictionary<CardIdEnum, Card>();
            if (_cardDatabase == null)
            {
                _cardDatabase = XElement.Load(filePath);
            }

            var entityList = _cardDatabase.Elements("Entity").ToList();
            foreach (var entity in entityList)
            {
                var card = GetCardFromXElement(entity);
                if (card.name != CardName.unknown)
                {
                    cards.Add(card.cardIDenum, card);
                }
            }

            return cards;
        }

        private static string GetLowString(object obj)
        {
            return obj.ToString().ToLower(defaultCultureInfo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public static Card GetCardFromXElement(XElement element)
        {
            CultureInfo cultureInfoChinese = new CultureInfo("zh-CN");

            Card card = new Card();

            string cardId = GetAttributeByXElement(element, GetLowString(CardPropertyType.CardId));
            card.cardIDenum = ConvertHelper.cardIdstringToEnum(cardId);

            string tempCardName = GetLocStringByXElement(element, "CARDNAME", defaultCultureInfo);
            card.EnglishName = tempCardName;
            string trimCardName = tempCardName.TrimCardName(defaultCultureInfo);
            card.name = ConvertHelper.cardNamestringToEnum(trimCardName);
            if (card.name == CardName.unknown)
            {
                //Golden Legendary
                //throw new Exception($"Can not find card name in {element}");
            }

            string tempChineseName = GetLocStringByXElement(element, "CARDNAME", cultureInfoChinese);
            card.ChineseName = tempChineseName;

            string cardText = GetLocStringByXElement(element, "CARDTEXT", defaultCultureInfo);
            if (!string.IsNullOrEmpty(cardText))
            {
                cardText = cardText.ToLower(defaultCultureInfo);
                if (cardText.Contains("choose one"))
                {
                    card.choice = true;
                }
            }

            var costElement = GetTagElementByName(element, GetLowString(CardPropertyType.Cost));
            if (costElement != null)
            {
                string costString = GetAttributeByXElement(costElement, "value");
                card.cost = Convert.ToInt32(costString);
            }

            var healthElement = GetTagElementByName(element, GetLowString(CardPropertyType.Health));
            if (healthElement != null)
            {
                string costString = GetAttributeByXElement(healthElement, "value");
                card.cost = Convert.ToInt32(costString);
            }
            //Console.WriteLine(cardId);
            return card;
        }

    }
}
