using HREngine.Bots;

namespace SilverFish.cards._03Adventure._004KAR
{
	class Sim_KAR_021 : SimTemplate // Wicked Witchdoctor
	{
		//Whenever you cast a spell, summon a random basic Totem.

        CardDB.Card searing = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_050);
        CardDB.Card healing = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.NEW1_009);
        CardDB.Card wrathofair = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_052);
		
        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            if (triggerEffectMinion.own == wasOwnCard && hc.card.type == CardDB.CardType.SPELL)
            {
				CardDB.Card kid;
				int otherTotems = 0;
				bool wrath = false;
                foreach (Minion m in (wasOwnCard) ? p.ownMinions : p.enemyMinions)
				{
					switch (m.name)
					{
						case CardDB.CardName.searingtotem: otherTotems++; continue;
						case CardDB.CardName.stoneclawtotem: otherTotems++; continue;
						case CardDB.CardName.healingtotem: otherTotems++; continue;
						case CardDB.CardName.wrathofairtotem: wrath = true; continue;
					}
				}
				if (p.isLethalCheck)
				{
					if (otherTotems == 3 && !wrath) kid = wrathofair;
					else kid = healing;
				}
				else
				{
					if (!wrath) kid = wrathofair;
					else kid = searing;
				}
                p.CallKid(kid, triggerEffectMinion.zonepos, wasOwnCard);
            }
        }
	}
}