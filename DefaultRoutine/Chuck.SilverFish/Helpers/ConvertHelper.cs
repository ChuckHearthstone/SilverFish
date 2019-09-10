using System;
using SilverFish.Enums;

namespace SilverFish.Helpers
{
    class ConvertHelper
    {
        public static CardName cardNamestringToEnum(string s)
        {
            if (Enum.TryParse<CardName>(s, false, out var nameEnum))
            {
                return nameEnum;
            }
            else
            {
                return CardName.unknown;
            }
        }

        public static CardIdEnum cardIdstringToEnum(string s)
        {
            if (Enum.TryParse<CardIdEnum>(s, false, out var cardEnum))
            {
                return cardEnum;
            }
            else
            {
                Triton.Common.LogUtilities.Logger.GetLoggerInstanceForType().ErrorFormat("[Unidentified card ID :" + s + "]");
                return CardIdEnum.None;
            }
        }
    }
}
