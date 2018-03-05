using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePhunWithStrings
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // 1.  Reverse your name
            // In my case, the result would be:
            // robaT boB
            string name = "Conor Kennedy";
            string ronoC = "";
            for (int i = (name.Length-1); i >=0; i--) ronoC += name[i];
            ResultLabel1.Text = ronoC;


            // 2.  Reverse this sequence:
            // When you're finished it should look like this:
            // Chewbacca,Han,Leia,Luke
            string names = "Luke,Leia,Han,Chewbacca";
            string[] sameButDifferent = names.Split(',');
            string differentButSame = "";
            for (int i = (sameButDifferent.Length-1); i >=0 ; i--)  
            {
                differentButSame += sameButDifferent[i] + ", ";
            }
            ResultLabel2.Text = differentButSame.Trim();


            // 3. Use the sequence to create ascii art:
            // *****luke*****
            // *****leia*****
            // *****han******
            // **Chewbacca***
          
            string[] starWars = new string[4] { "luke", "leia", "han", "Chewbacca"};
            for (int i = 0; i < starWars.Length; i++)
            {
                while (starWars[i].Length<14)
                {
                    starWars[i] = starWars[i].PadRight((starWars[i].Length+1), '*');
                    if (starWars[i].Length<14)
                    {
                        starWars[i] = starWars[i].PadLeft((starWars[i].Length+1), '*');
                    }
                }
            }
            for (int i = 0; i < starWars.Length; i++)
            {
                ResultLabel3.Text += starWars[i] + "<br />";
            }
            

            // 4. Solve this puzzle:
            string puzzle = "NOW IS ZHEremove-me ZIME FOR ALL GOOD MEN ZO COME ZO ZHE AID OF ZHEIR COUNZRY.";
            // Once you fix it with string helper methods, it should read:
            // Now is the time for all good men to come to the aid of their country.

            puzzle = puzzle.ToLower().Replace('z', 't');
            int puzzleIndex = puzzle.IndexOf("remove");
            puzzle = puzzle.Remove(puzzleIndex, 9);
            puzzle = puzzle.Replace("now", "Now");

            ResultLabel4.Text = puzzle;
        }
    }
}