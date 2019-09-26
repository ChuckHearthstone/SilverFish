namespace Chuck.SilverFish
{

    public class SimTemplate
    {
        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion attacker, Minion target, out int number)
        {
            number = 0;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, Minion target, int number)
        {
            return;
        }

        public virtual void onSecretPlay(Playfield p, bool ownplay, int number)
        {
            return;
        }


        /// <summary>
        /// 使用卡牌
        /// </summary>
        /// <param name="p"></param>
        /// <param name="ownplay"></param>
        /// <param name="target"></param>
        /// <param name="choice"></param>
        public virtual void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            return;
        }

        /// <summary>
        /// 弃牌
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="own"></param>
        /// <param name="num"></param>
        /// <param name="checkBonus"></param>
        /// <returns></returns>
        public virtual bool onCardDicscard(Playfield p, Handmanager.Handcard hc, Minion own, int num, bool checkBonus = false) 
        {
            return false;
        }

        public virtual void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            return;
        }

        public virtual void onAuraStarts(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAuraEnds(Playfield p, Minion m)
        {
            return;
        }


        public virtual void onEnrageStart(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onEnrageStop(Playfield p, Minion m)
        {
            return;
        }

        public virtual void onAMinionGotHealedTrigger(Playfield p, Minion triggerEffectMinion, int minionsGotHealed)
        {
            return;
        }

        public virtual void onAHeroGotHealedTrigger(Playfield p, Minion triggerEffectMinion, bool ownerOfHeroGotHealed)
        {
            return;
        }
        public virtual void onACharGotHealed(Playfield p, Minion triggerEffectMinion, int charsGotHealed)
        {
            return;
        }        

        public virtual void onTurnEndsTrigger(Playfield p, Minion triggerEffectMinion, bool turnEndOfOwner)
        {
            return;
        }

        public virtual void onTurnStartTrigger(Playfield p, Minion triggerEffectMinion, bool turnStartOfOwner)
        {
            return;
        }

        public virtual void onMinionGotDmgTrigger(Playfield p, Minion triggerEffectMinion, int anzOwnMinionsGotDmg, int anzEnemyMinionsGotDmg, int anzOwnHeroGotDmg, int anzEnemyHeroGotDmg)
        {
            return;
        }

        public virtual void onMinionDiedTrigger(Playfield p, Minion triggerEffectMinion, Minion diedMinion)
        {
            return;
        }

        public virtual void onMinionIsSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onMinionWasSummoned(Playfield p, Minion triggerEffectMinion, Minion summonedMinion)
        {
            return;
        }

        public virtual void onDeathrattle(Playfield p, Minion m)
        {
            return;
        }

        /// <summary>
        /// 使用一张牌后，触发场上随从的效果
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        /// <summary>
        /// 使用一张牌后触发，触发手牌的效果
        /// </summary>
        /// <param name="p"></param>
        /// <param name="hc"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerhc"></param>
        public virtual void onCardIsGoingToBePlayed(Playfield p, Handmanager.Handcard hc, bool wasOwnCard, Handmanager.Handcard triggerhc)
        {
            return;
        }

        /// <summary>
        /// 原来就没有调用的地方，应该不能使用
        /// </summary>
        /// <param name="p"></param>
        /// <param name="c"></param>
        /// <param name="wasOwnCard"></param>
        /// <param name="triggerEffectMinion"></param>
        public virtual void onCardWasPlayed(Playfield p, CardDB.Card c, bool wasOwnCard, Minion triggerEffectMinion)
        {
            return;
        }

        public virtual void onInspire(Playfield p, Minion m, bool ownerOfInspire)
        {
            return;
        }

        public virtual void onMinionLosesDivineShield(Playfield p, Minion m, int num)
        {
            return;
        }


    }

}