using HREngine.Bots;

namespace SilverFish.cards._01Basic._03Mage
{
    class Sim_CS2_022 : SimTemplate//Polymorph
    {

        private CardDB.Card sheep = CardDB.Instance.getCardDataFromID(CardDB.CardIdEnum.CS2_tk1);

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            p.minionTransform(target, sheep);
        }

    }
}
