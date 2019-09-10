using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_050: SimTemplate //* Webweave
    {
        // Summon two 1/2 Poisonous Spiders

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_051t); //Poisonous Spider

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;

            p.CallKid(kid, pos, ownplay, false);
            p.CallKid(kid, pos, ownplay);
        }
    }
}