using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._003OG
{
    class Sim_OG_006b : SimTemplate //* The Tidal Hand
    {
        //Hero Power Summon a 1/1 Silver Hand Murloc.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.OG_006a);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }
    }
}