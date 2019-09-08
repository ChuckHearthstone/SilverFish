using HREngine.Bots;

namespace SilverFish.cards._04Expansion._001GvG
{
    class Sim_GVG_110 : SimTemplate //Dr. Boom
    {

        //  Battlecry: Summon two 1/1 Boom Bots. WARNING: Bots may explode. 

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.GVG_110t);//chillwind

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos, own.own);
            p.CallKid(kid, own.zonepos - 1, own.own);
        }


    }

}