using System;
using System.Collections.Generic;
using System.Text;

namespace HREngine.Bots
{
    class Sim_GVG_074 : SimTemplate //Kezan Mystic
    {
        //todo better!
        //  Battlecry: Take control of a random enemy Secret;. 

        public override void getBattlecryEffect(Playfield p, Minion own, Minion target, int choice)
        {
            if (own.own)
            {
                if (p.enemySecretList.Count >= 1)
                {
                    if(p.enemyHeroName == HeroEnum.hunter) p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_610);
                    if (p.enemyHeroName == HeroEnum.mage) p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_594);
                    if (p.enemyHeroName == HeroEnum.pala) p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_130);

                    if (p.enemyHeroName != HeroEnum.hunter && p.enemyHeroName != HeroEnum.mage && p.enemyHeroName != HeroEnum.pala) p.ownSecretsIDList.Add(CardDB.cardIDEnum.EX1_130);
                    
                    p.enemySecretList.RemoveAt(0);
                }
            }
            else
            {
                if (p.ownSecretsIDList.Count >= 1)
                {
                    p.ownSecretsIDList.RemoveAt(0);
                    SecretItem s = new SecretItem
                    {
                        canBe_avenge = false,
                        canBe_counterspell = false,
                        canBe_duplicate = false,
                        canBe_explosive = true,
                        canBe_eyeforaneye = false,
                        canBe_freezing = false,
                        canBe_icebarrier = false,
                        canBe_iceblock = false,
                        canBe_mirrorentity = false,
                        canBe_missdirection = false,
                        canBe_noblesacrifice = false,
                        canBe_redemption = false,
                        canBe_repentance = false,
                        canBe_snaketrap = false,
                        canBe_snipe = false,
                        canBe_spellbender = false,
                        canBe_vaporize = false,
                        entityId = 1050
                    };

                    p.enemySecretList.Add(s);
                }
            }
        }
    }
}