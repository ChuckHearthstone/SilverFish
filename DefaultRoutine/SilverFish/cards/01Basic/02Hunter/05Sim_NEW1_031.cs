using HREngine.Bots;

namespace SilverFish.cards._01Basic._02Hunter
{
	class Sim_NEW1_031 : SimTemplate //* animalcompanion
	{
        //Summon a random Beast Companion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.NEW1_032);//misha
        
		public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
		{
            int pos = (ownplay)?  p.ownMinions.Count : p.enemyMinions.Count;
            p.CallKid(kid, pos, ownplay, false);
		}

    }

    class Sim_NEW1_032 : SimTemplate //misha
    {

        //    spott/


    }

    class Sim_NEW1_033 : SimTemplate //leokk
    {

        //    andere befreundete diener haben +1 angriff.
        public override void onAuraStarts(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnRaidleader++;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }
            else
            {
                p.anzEnemyRaidleader++;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, 1, 0);
                }
            }

        }

        public override void onAuraEnds(Playfield p, Minion own)
        {
            if (own.own)
            {
                p.anzOwnRaidleader--;
                foreach (Minion m in p.ownMinions)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
            else
            {
                p.anzEnemyRaidleader--;
                foreach (Minion m in p.enemyMinions)
                {
                    if (own.entitiyID != m.entitiyID) p.minionGetBuffed(m, -1, 0);
                }
            }
        }

    }

    class Sim_NEW1_034 : SimTemplate //huffer
    {

        //    ansturm/


    }
}