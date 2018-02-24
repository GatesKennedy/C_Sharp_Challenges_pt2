using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeForXmenBattleCount
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Display
                // "Most Battles Belong to: Name (Value: X)"
                // "Least Battles Belong to: Name (Value: Y)"
            
            // Wolverine fewest battles
            // Pheonix most battles

            //Provided Arrays (added 'Shirley Mason' and 'Sybil' for a generalized scenario)
            string[] names = new string[] { "Professor X", "Iceman", "Angel", "Beast", "Pheonix", "Cyclops", "Wolverine", "Nightcrawler", "Storm", "Colossus", "Shirley Mason", "Sybil Dorsett", "Peggy Baldwin" };
            int[] numbers = new int[] { 7, 9, 12, 15, 17, 13, 2, 6, 8, 13, 17, 2, 6};

            // Define Max and Min
            int numbersMax = numbers.Max();
            int numbersMin = numbers.Min();

            // Status for multiple Max, Min Values
            bool foundMax = false;
            bool foundMin = false;

            // Declare Result String
            string result = "";

            // Iterate through 'numbers' Array
            for (int i = 0; i < numbers.Length; i++)
            {
                // Compare iteration to Max Value
                if (numbers[i] == numbersMax)
                {
                    // First max-found
                    if (foundMax==false)
                    {
                        result += String.Format("Most Battles Belong to: {0} (Value: {1} Battles)<br />", names[i], numbers[i]);
                    }
                    // Succeeding max-founds
                    else
                    {
                        result += String.Format("Most Battles Also Belongs to: {0} (Value: {1} Battles)<br />", names[i], numbers[i]);
                    }

                    foundMax = true;
                }
                // Compare iteration to Min Value
                else if (numbers[i] == numbersMin)
                {
                    // First min-found
                    if (foundMin==false)
                    {
                        result += String.Format("Least Battles Belong to: {0} (Value: {1} Battles)<br />", names[i], numbers[i]);
                    }
                    // Succeeding min-founds
                    else
                    {
                        result += String.Format("Least Battles Also Belongs to: {0} (Value: {1} Battles)<br />", names[i], numbers[i]);
                    }

                    foundMin = true;
                }
                else
                {
                    ; // do nothing. Included for potential break point
                }
            }

            // Display Result String
            resultLabel.Text = result;
        }
    }
}