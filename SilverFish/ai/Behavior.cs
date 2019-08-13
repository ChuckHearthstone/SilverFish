
using System.Collections.Generic;

namespace HREngine.Bots
{
    public abstract class Behavior
    {
        public virtual float getPlayfieldValue(Playfield p)
        {
            return 0;
        }

        public virtual int getEnemyMinionValue(Minion m, Playfield p)
        {
            return 0;
        }

        public virtual string BehaviorName()
        {
            return "None";
        }

        public virtual int getPlayCardPenality(CardDB.Card card, Minion target, Playfield p)
        {
            return 0;
        }

        public virtual int getAttackWithHeroPenality(Minion target, Playfield p)
        {
            return 0;
        }

        public virtual int getAttackWithMininonPenality(Minion m, Playfield p, Minion target)
        {
            return 0;
        }

        public virtual int getSirFinleyPriority(List<Handmanager.Handcard> discoverCards)
        {
            return -1;
        }

    }

}