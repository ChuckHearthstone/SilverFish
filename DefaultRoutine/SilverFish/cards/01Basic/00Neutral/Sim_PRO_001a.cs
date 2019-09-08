using HREngine.Bots;

namespace SilverFish.cards._01Basic._00Neutral
{
    class Sim_PRO_001a : SimTemplate//I Am Murloc
    {
        //Summon three, four, or five 1/1 Murlocs.
        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.PRO_001at);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int posi = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count ;

            p.CallKid(kid, posi, ownplay, false);
            p.CallKid(kid, posi, ownplay);
            p.CallKid(kid, posi, ownplay);
            p.CallKid(kid, posi, ownplay);
        }
    }
}
