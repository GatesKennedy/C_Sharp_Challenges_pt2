using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

/*
1.  You will start by creating a new class named Dice.
The Dice class will have
    One property: 
		int Sides

    One Method:
		method called Roll().  
		The Roll() method will use the Sides property as the maximum value used by the Random.Next() method.
        The Roll() method will return the random number to the caller.  


    Hint: you cannot create a new instance of the Random class inside of the Roll() method otherwise you'll have that same problem we've fought before.
    You must create a new instance of the Random class * outside* of the Roll() method.

2.  In the Default class' Page_Load method, you will create a new instance of the Dice class and pass it as an input parameter to the Character class' Attack method.
    The Attack method will set the Sides property, then will call the Dice class' Roll() method and use the return value as the return value of the Attack method as well.

3.  You will re-write the logic in the Page_Load method to check and see if the hero gets an attack bonus or if the monster gets an attack bonus.
    In either case, you should perform the bonus attack and make the appropriate changes to the other character's health using the Defend method.

4.  You will create a while loop (a.k.a, the battle loop) and only break out of it once one character's health is less than zero.  
	Inside the while loop, the monster should attack the hero, then the hero should attack the monster.

5.  You will create a helper method in the Default class called displayResult() which accepts two input parameters, opponent1 and opponent2.
    Depending on their health, determine the winner and print out a winning message using both their names.
    If they both have health less than or equal to zero, then print out a message that they both died.
*/

namespace ChallengeHeroMonsterClassesPart2
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Character hero = new Character();
            hero.Name = "Bill";
            hero.Health = 100;
            hero.DamageMaximum = 85;
            hero.AttackBonus = false;

            Character monster = new Character();
            monster.Name = "Ted";
            monster.Health = 250;
            monster.DamageMaximum = 25;
            monster.AttackBonus = true;

            Dice rando1 = new Dice();
            int damage;
            int count = 1;

            if (hero.AttackBonus)
                monster.Defend(hero.Attack(rando1));
            if (monster.AttackBonus)
                hero.Defend(monster.Attack(rando1));

            while (hero.Health > 0 && monster.Health > 0)
            {
                damage = monster.Attack(rando1);
                if (monster.AttackBonus) damage += 5;
                hero.Defend(damage);

                damage = hero.Attack(rando1);
                if (hero.AttackBonus) damage += 5;
                monster.Defend(damage);

                resultLabel.Text += string.Format(".:Round {0}:.<br/>", count);
                PrintStats(hero);
                PrintStats(monster);
                resultLabel.Text += "<br/><br/>";
                count += 1;
            }
            DisplayResults(hero, monster);
        }

        private void PrintStats(Character character)
        {
            resultLabel.Text += String.Format("<p>Name: {0} - Health: {1} - DamageMaximum: {2} - AttackBonus: {3}</p>",
                character.Name,
                character.Health,
                character.DamageMaximum.ToString(),
                character.AttackBonus.ToString());
        }

        private void DisplayResults(Character character1, Character character2)
        {
            if (character1.Health > character2.Health)
            {
                resultLabel.Text += character1.Name + " defeats " + character2.Name;
            }
            else if (character1.Health < character2.Health)
            {
                resultLabel.Text += character2.Name + " defeats " + character1.Name;
            }
            else if (character1.Health==character2.Health)
            {
                resultLabel.Text += character1.Name + " and " + character2.Name + " have killed eachother... bum.";
            }
        }
    }
    

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice diceRoll)
        {
            diceRoll.Sides = this.DamageMaximum;
            return diceRoll.Roll();
        }

        public void Defend(int damage)
        {
            this.Health -= damage;
            if (this.Health < 0) this.Health = 0;
        }
    }

    class Dice
    {
        public int Sides { get; set; }

        Random rando = new Random();
        public int Roll()
        {
            return rando.Next(this.Sides);
        }
    }
}