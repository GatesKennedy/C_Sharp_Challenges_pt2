using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    /*
    REQUIREMENTS
    =============

    1. Name the project: ChallengeHeroMonsterClassesPart1

    2. Create a Character class
    It should have properties:
    Name
    Health
    DamageMaximum
    AttackBonus

    3. The Character class should have two methods:

    Attack() return an int - randomly determine the amount of damage this Character object inflicted.
    ((use the Random class))

    Defend(int damage) - deducts the damage from this Character's health

    4.  In the Page_Load() create two instances of the Character class: 

    hero
    monster

    ... and set their attributes (to whatever you want)

    5.  You will perform two sides of the battle.  The first half of the battle will involve the hero attacking the monster and the monster defending itself.  The second half of the battle will involve the monster attacking and the hero defending itself.  Just one round -- this is not a fight to the death.

    6.  Create a helper method in the Deafult class to display the stats of each character in a Label server control.
    */

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        class Character
        {
            /*
            2. Create a Character class
            It should have properties:
            Name
            Health
            DamageMaximum
            AttackBonus

            3. The Character class should have two methods:

            Attack() return an int - randomly determine the amount of damage this Character object inflicted.
            ((use the Random class))

            Defend(int damage) - deducts the damage from this Character's health
            */

            public string Name { get; set; }
            public int Health { get; set; }
            public int DamageMaximum { get; set; }
            public int AttackBonus { get; set; }

            public int Attack(out int DamageInflicted)
            {
                DamageInflicted = 0;



                return DamageInflicted;
            }

            public int Defend(out int damageTaken)
            {
                damageTaken = 0;


                return damageTaken;
            }
        }
    }
}