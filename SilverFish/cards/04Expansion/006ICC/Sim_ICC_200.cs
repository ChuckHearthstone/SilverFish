using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_200: SimTemplate //* Venomstrike Trap
    {
        // Secret: When one of your minions is attacked, summon a 2/3 Poisonous Cobra.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.cardIDEnum.EX1_170); //Emperor Cobra

        public override void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
        }
    }
}