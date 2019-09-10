using System.Collections.Generic;
using HREngine.Bots;
using SilverFish.Enums;

namespace SilverFish.cards._04Expansion._006ICC
{
    class Sim_ICC_086: SimTemplate //* Glacial Mysteries
    {
        // Put one of each Secret from your deck into the battlefield.

        public override void onCardPlay(Playfield p, bool ownplay, Minion target, int choice)
        {
            if (ownplay)
            {
                List<CardIdEnum> secrets = new List<CardIdEnum>();
                CardDB.Card c;
                foreach (var cid in p.prozis.turnDeck)
                {
                    c = CardDB.Instance.getCardDataFromID(cid.Key);
                    if (c.Secret) secrets.Add(cid.Key);
                }

                foreach (CardIdEnum cId in secrets)
                {
                    if (p.ownSecretsIDList.Count < 5 && !p.ownSecretsIDList.Contains(cId)) p.ownSecretsIDList.Add(cId);
                }
            }
            else
            {
                for (int i = p.enemySecretCount; i < 5; i++)
                {
                    p.enemySecretCount++;
                    p.enemySecretList.Add(Probabilitymaker.Instance.getNewSecretGuessedItem(p.getNextEntity(), p.enemyHeroStartClass));
                }
            }
        }
	}
}