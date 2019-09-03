using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_838 : SimTemplate //* Sindragosa
    {
        // Battlecry: Summon two 0/1 Frozen Champions.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.ICC_838t); //Frozen Champion

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos - 1, own.own); //1st left
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}