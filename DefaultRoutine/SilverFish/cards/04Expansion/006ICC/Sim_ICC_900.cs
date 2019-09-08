using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_900: SimTemplate //* Necrotic Geist
    {
        // Whenever one of your other minions dies, summon a 2/2 Ghoul.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.ICC_900t); //Ghoul 2/2

        public override void onMinionDiedTrigger(Playfield p, Minion m, Minion diedMinion)
        {
            int diedMinions = (m.own) ? p.tempTrigger.ownMinionsDied : p.tempTrigger.enemyMinionsDied;
            if (diedMinions == 0) return;
            int residual = (p.pID == m.pID) ? diedMinions - m.extraParam2 : diedMinions;
            m.pID = p.pID;
            m.extraParam2 = diedMinions;
            for (int i = 0; i < residual; i++)
            {
                p.CallKid(kid, m.zonepos, m.own);
            }
        }
    }
}