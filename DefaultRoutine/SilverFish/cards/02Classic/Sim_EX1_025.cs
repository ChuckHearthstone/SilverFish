using HREngine.Bots;

namespace SilverFish.cards._02Classic
{
    class Sim_EX1_025 : SimTemplate//dragonling mechanic
    {
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_025t);//mechanicaldragonling

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos, own.own);
        }

    }
}
