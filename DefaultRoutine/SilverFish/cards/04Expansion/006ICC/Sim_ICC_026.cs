using Chuck.SilverFish;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_026: SimTemplate //* Grim Necromancer
    {
        // Battlecry: Summon two 1/1 Skeletons.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_026t); //1/1 Skeleton

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            p.CallKid(kid, own.zonepos - 1, own.own); //1st left
            p.CallKid(kid, own.zonepos, own.own);
        }
    }
}