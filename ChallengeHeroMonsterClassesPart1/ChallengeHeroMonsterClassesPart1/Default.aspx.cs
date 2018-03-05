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
            Character Hero = new Character();
            Hero.Name = "T'Challa";
            Hero.Health = 220;
            Hero.DamageMaximum = 299;
            Hero.AttackBonus = false;

            Character Monster = new Character();
            Monster.Name = "Cthulhu";
            Monster.Health = 300;
            Monster.DamageMaximum = 219;
            Monster.AttackBonus = false;

            HeroLabel.Text = String.Format("Hero: {0} ({1}hp)", Hero.Name, Hero.Health);
            MonsterLabel.Text = String.Format("Monster: {0} ({1}hp)", Monster.Name, Monster.Health);

            int damage;

            damage = Hero.Attack();
            Monster.Defend(damage);

            damage = Monster.Attack();
            Hero.Defend(damage);

            DisplayResults(Hero);
            DisplayResults(Monster);
        }

        private void DisplayResults(Character character)
        {
            ResultLabel.Text += String.Format("{0} Health: {1}hp<br />", character.Name, character.Health);
        }

    }


    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack()
        {
            Random rando = new Random();
            int DamageInflicted = rando.Next(25, this.DamageMaximum);
            return DamageInflicted;
        }

        public void Defend(int damageTaken)
        {
            this.Health -= damageTaken;
        }
    }
}