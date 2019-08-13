namespace HREngine.Bots
{
    using System.Collections.Generic;


    public class Deck
    {
        public Dictionary<CardDB.cardIDEnum, int> deckDiff = new Dictionary<CardDB.cardIDEnum, int>();
        public int deckSize = 0;
        public bool deckChanged = false;
        //public int anzcards = 0;
        //public int enemyAnzCards = 0;
        //Helpfunctions help;
        //CardDB cdb = CardDB.Instance;
        
        public Deck()
        {

        }

        public Deck(Playfield p, CardDB.cardIDEnum cardId, int number, bool own)
        {
            Deck newDeck = new Deck();
            newDeck.deckChanged = true;
            if (this.deckChanged)
            {
                newDeck.deckSize += this.deckSize;
                foreach (KeyValuePair<CardDB.cardIDEnum, int> diff in this.deckDiff)
                {
                    newDeck.deckDiff.Add(diff.Key, diff.Value);
                }
            }
            if (number > 0)
            {
                newDeck.deckSize += number;
                if (newDeck.deckDiff.ContainsKey(cardId)) newDeck.deckDiff[cardId] += number;
                else newDeck.deckDiff.Add(cardId, number);
            }

            //if (own) p.ownDeck = newDeck;
            //else p.enemyDeck = newDeck;
        }
        /*
        public void print(bool tobuffer = false)
        {
            Helpfunctions help = Helpfunctions.Instance;
            if (tobuffer)
            {
                if (this.actionType == actionEnum.playcard)
                {
                    string playaction = "play ";

                    playaction += "id " + this.card.entity;
                    if (this.target != null)
                    {
                        playaction += " target " + this.target.entitiyID;
                    }

                    if (this.place >= 0)
                    {
                        playaction += " pos " + this.place;
                    }

                    if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                    help.writeToBuffer(playaction);
                }
                if (this.actionType == actionEnum.attackWithMinion)
                {
                    help.writeToBuffer("attack " + this.own.entitiyID + " enemy " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.attackWithHero)
                {
                    help.writeToBuffer("heroattack " + this.target.entitiyID);
                }
                if (this.actionType == actionEnum.useHeroPower)
                {

                    if (this.target != null)
                    {
                        help.writeToBuffer("useability on target " + this.target.entitiyID);
                    }
                    else
                    {
                        help.writeToBuffer("useability");
                    }
                }
                return;
            }
            if (this.actionType == actionEnum.playcard)
            {
                string playaction = "play ";

                playaction += "id " + this.card.entity;
                if (this.target != null)
                {
                    playaction += " target " + this.target.entitiyID;
                }

                if (this.place >= 0)
                {
                    playaction += " pos " + this.place;
                }

                if (this.druidchoice >= 1) playaction += " choice " + this.druidchoice;

                help.logg(playaction);
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                help.logg("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                help.logg("attack with hero, enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                help.logg("useability ");
                if (this.target != null)
                {
                    help.logg("on enemy: " + this.target.entitiyID);
                }
            }
            help.logg("");
        }

        public string printString()
        {
            string retval = "";

            if (this.actionType == actionEnum.playcard)
            {
                retval += "play ";

                retval += "id " + this.card.entity;
                if (this.target != null)
                {
                    retval += " target " + this.target.entitiyID;
                }

                if (this.place >= 0)
                {
                    retval += " pos " + this.place;
                }
                if (this.druidchoice >= 1) retval += " choice " + this.druidchoice;
            }
            if (this.actionType == actionEnum.attackWithMinion)
            {
                retval += ("attacker: " + this.own.entitiyID + " enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.attackWithHero)
            {
                retval += ("attack with hero, enemy: " + this.target.entitiyID);
            }
            if (this.actionType == actionEnum.useHeroPower)
            {
                retval += ("useability ");
                if (this.target != null)
                {
                    retval += ("on target: " + this.target.entitiyID);
                }
            }

            return retval;
        }*/

    }
    /*
    public class Deckmanager
    {
        

        public void clearAll()
        {
            this.deckOwn.Clear();
            this.deckEnemy.Clear();
            this.cardsInDeckOwn = 0;
            this.cardsInDeckEmemy = 0;
        }
        
        public void setDeckcards(List<Deckcard> hc, int anzown, int anzenemy)
        {
            this.Deckcards.Clear();
            foreach (Deckcard h in hc)
            {
                this.Deckcards.Add(new Deckcard(h));
            }
            //this.Deckcards.AddRange(hc);
            this.Deckcards.Sort((a, b) => a.position.CompareTo(b.position));
            this.anzcards = anzown;
            this.enemyAnzCards = anzenemy;
        }

        public void printcards()
        {
            help.logg("Own Deckcards: ");
            foreach (Deckmanager.Deckcard c in this.Deckcards)
            {
                help.logg("pos " + c.position + " " + c.card.name + " " + c.manacost + " entity " + c.entity + " " + c.card.cardIDenum + " " + c.addattack);
            }
            help.logg("Enemy cards: " + this.enemyAnzCards);
        }


    }*/

}