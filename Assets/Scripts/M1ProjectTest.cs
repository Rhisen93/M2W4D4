using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M1ProjectTest : MonoBehaviour
{
    public Hero a = new Hero("Rhisen", 100, new Stats(10, 8, 6, 12, 5, 80, 15), Element.Fire, Element.Ice, Element.Lightning, new Weapon("Momo", Weapon.DAMAGE_TYPE.PHYSICAL, Element.Fire, new Stats(12, 10, 8, 14, 7, 82, 17)));
    public Hero b = new Hero("Argoreth", 90, new Stats(8, 6, 4, 10, 3, 60, 14), Element.Fire, Element.Ice, Element.Lightning, new Weapon("Sword", Weapon.DAMAGE_TYPE.PHYSICAL, Element.Fire, new Stats(10, 8, 6, 12, 5, 75, 15)));

    private Stats dmgTotalA;
    private Stats dmgTotalB;
    
    // Start is called before the first frame update
    void Start()
    {
        dmgTotalA = Stats.Sum(a.GetBaseStats(), a.Weapon.GetBonusStats());
        dmgTotalB = Stats.Sum(b.GetBaseStats(), b.Weapon.GetBonusStats());
    }

    private void Attack(Hero attacker, Hero defender, Stats attackerStats, Stats defenderStats)
    {
        Debug.Log(attacker.GetName() + " Sta Attacando " + defender.GetName());
        if (GameFormulas.HasHit(attackerStats, defenderStats))
        {
            if (GameFormulas.HasElementAdvantage(attacker.Weapon.GetElem(), defender))
            {
                Debug.Log("WEAKNESS");
            }
            if (GameFormulas.HasElementDisadvantage(attacker.Weapon.GetElem(), defender))
            {
                Debug.Log("RESIST");
            }
            int CalcoloDanno = GameFormulas.CalculateDamage(attacker, defender);
            defender.TakeDamage(CalcoloDanno);
            Debug.Log("il danno è di: " + CalcoloDanno);
            if (defender.IsAlive() == false)
            {
                Debug.Log("il nome del vincitore è " + attacker.GetName());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (a.IsAlive() && b.IsAlive())
        {
            if (dmgTotalA.spd > dmgTotalB.spd) // comincia a il turno
            {
                Attack(a, b, dmgTotalA, dmgTotalB);
                if (b.IsAlive())
                {
                    Attack(b, a, dmgTotalB, dmgTotalA);
                }

            }
            else // comincia b il turno 
            {
                Attack(b, a, dmgTotalB, dmgTotalA);
                if (a.IsAlive())
                {
                    Attack(a, b, dmgTotalA, dmgTotalB);
                }

            }
        }
        else
        {
            return;
        }



    }
}
