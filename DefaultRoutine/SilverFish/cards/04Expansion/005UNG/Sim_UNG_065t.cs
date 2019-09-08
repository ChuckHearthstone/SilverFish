using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._005UNG
{
	class Sim_UNG_065t : SimTemplate //* Sherazin, Seed
	{
		//When you play 4 cards in a turn, revive this minion.

        CardDB.Card kid = CardDB.Instance.getCardDataFromID(CardIdEnum.UNG_065); //Sherazin, Corpse Flower

        public override void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            triggerEffectMinion.Attack++;
            triggerEffectMinion.cantAttack = true;
            if (triggerEffectMinion.Attack > 3) p.minionTransform(triggerEffectMinion, kid);
        }

        public override void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            if (triggerEffectMinion.own == turnEndOfOwner)
            {
                triggerEffectMinion.Attack = 0;
            }
        }
    }
}