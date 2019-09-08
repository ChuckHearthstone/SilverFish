using HREngine.Bots;

namespace SilverFish.cards._04Expansion._002AT
{
    class Sim_AT_046 : SimTemplate //* Tuskarr Totemic
    {
        //Battlecry: Summon a random basic Totem.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_050);//Searing Totem

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}