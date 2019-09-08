using HREngine.Bots;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_832: SimTemplate //* Malfurion the Pestilent
    {
        // Choose One - Summon 2 Poisonous Spiders; or 2 Scarabs with Taunt.

        CardDB.Card kidSpider = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_832t3); //Frost Widow
        CardDB.Card kidScarab = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.ICC_832t4); //Scarab Beetle
        
        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.setNewHeroPower(CardDB.CardIdEnum.ICC_832p, ownplay); // Plague Lord
            if (ownplay) p.ownHero.armor += 5;
            else p.enemyHero.armor += 5;

            if (choice == 1 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kidSpider, pos, ownplay);
                p.CallKid(kidSpider, pos, ownplay);
            }
            if (choice == 2 || (p.ownFandralStaghelm > 0 && ownplay))
            {
                int pos = (ownplay) ? p.ownMinions.Count : p.enemyMinions.Count;
                p.CallKid(kidScarab, pos, ownplay);
                p.CallKid(kidScarab, pos, ownplay);
            }
        }
    }
}