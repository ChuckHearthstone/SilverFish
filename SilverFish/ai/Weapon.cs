using Triton.Game.Mapping;

namespace HREngine.Bots
{
    using System;
    using System.Collections.Generic;
    
    public class Weapon
    {
        public int pID = 0;
        public CardDB.cardName name = CardDB.cardName.unknown;
        public CardDB.Card card;
        public int numAttacksThisTurn = 0;
        public bool immuneWhileAttacking = false;
        
        public int Angr = 0;
        public int Durability = 0;
        
        public bool windfury = false;
        public bool immune = false;
        public bool lifesteal = false;
        public bool poisonous = false;
        public bool cantAttackHeroes = false;

        public Weapon()
        {
            this.card = CardDB.Instance.unknownCard;
        }

        public Weapon(Weapon w)
        {
            this.name = w.name;
            this.card = w.card;
            this.numAttacksThisTurn = w.numAttacksThisTurn;
            this.immuneWhileAttacking = w.immuneWhileAttacking;

            this.Angr = w.Angr;
            this.Durability = w.Durability;

            this.windfury = w.windfury;
            this.immune = w.immune;
            this.lifesteal = w.lifesteal;
            this.poisonous = w.poisonous;
            this.cantAttackHeroes = w.cantAttackHeroes;
        }

        public bool isEqual(Weapon w)
        {
            if (this.Angr != w.Angr) return false;
            if (this.Durability != w.Durability) return false;
            if (this.poisonous != w.poisonous) return false;
            if (this.lifesteal != w.lifesteal) return false;
            if (this.name != w.name) return false;
            return true;
        }

        public void equip(CardDB.Card c)
        {
            this.name = c.name;
            this.card = c;
            this.numAttacksThisTurn = 0;
            this.immuneWhileAttacking = c.immuneWhileAttacking;

            this.Angr = c.Attack;
            this.Durability = c.Durability;

            this.windfury = c.windfury;
            this.immune = false;
            this.lifesteal = c.lifesteal;
            this.poisonous = c.poisonous;
            this.cantAttackHeroes = (c.name == CardDB.cardName.foolsbane) ? true : false;
        }

        public string weaponToString()
        {
            return this.Angr + " " + this.Durability + " " + this.name + " " + this.card.cardIDenum + " " + (this.poisonous ? 1 : 0) + " " + (this.lifesteal ? 1 : 0);
        }
            
    }
}