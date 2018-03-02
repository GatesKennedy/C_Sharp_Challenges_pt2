using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MegaChallengeCasino
{
    public partial class Default : System.Web.UI.Page
    {
        /*  Overview
         *      
         *      Event: Page_Load
         *          
         *          {Populate Icons}
         *          ViewState: "Set Balance = $100"
         *          
         *      Initialize Variables
         *          Enumeration: Icons (starts @ 0)
         *          'iconDisplayArray[]'
         *              [0] = iconImage1
         *              [1] = iconImage2
         *              [2] = iconImage3
         *          'betResultMultiplier' (0-5)
         *              0 = no multipler
         *              1 = Bar
         *              2 = 777
         *              3 = 1Cherry
         *              4 = 2Cherry
         *              5 = 3Cherry
         *          Enumeration: 'betResultMessage'
         *              [0] = "You Lost Your Money"
         *              [1] = "Bar! You Lost Your Money"
         *              [2] = "Triple 7's! You Won "
         *              [3] = "1 Cherry! You Won "
         *              [4] = "2 Cherries! You Won "
         *              [5] = "3 Cherries! You Won "
         *          
         *      Event: Lever_Button
         *      
         *          {Populate Icons}
         *              
         *              For Loop: "Icon 1, Icon 2, Icon 3"
         *                  {Random Generator}
         *                      values 0-11
         *                      set to 'iconDisplayArray[]'
         *                  {Assign Icons}
         *                      'IconImage1' = iconDisplayArray[0]
         *                      'IconImage2' = iconDisplayArray[1]
         *                      'IconImage3' = iconDisplayArray[2]
         *          
         *          {Calculate Bet Result}
         *          
         *              {FindMultipliers}
             *              {GateForBar}
             *                  For Loop: Find 'Bar'
             *                  >> 'iconDisplayArray'
             *                      True:  'betResultMultiplier'=1, Return
             *                      False:  Pass Gate
             *                  
             *              {GateForSevens}
             *                  If === '777'
             *                  >> 'iconDisplayArray'
             *                      True:  'betResultMultiplier'=2, Return
             *                      False:  Pass Gate
             *                      
             *              {GateForCherries}
             *                  'cherryCount'
             *                  For Loop: Count 'Cherry'
             *                  >> 'iconDisplayArray'
             *                  If      'cherryCount'=0,   'betResultMultiplier'=0, return
             *                  else If 'cherryCount'=1,   'betResultMultiplier'=3, return
             *                  else If 'cherryCount'=2,   'betResultMultiplier'=4, return
             *                  else    'cherryCount'=3,   'betResultMultiplier'=5, return
         *              
         *              {CalculateEarnings}
         *                  'betEarnings'
         *                  If '0'  0        Earnings = Bet x0
         *                  If '1'  Bar      Earnings = Bet x0
         *                  If '2'  777      Earnings = Bet x100
         *                  If '3'  1Cherry  Earnings = Bet x2
         *                  If '4'  2Cherry  Earnings = Bet x3
         *                  If '5'  3Cherry  Earnings = Bet x4
         *                  
         *          {UpdateBalance}
         *              Balance += 'betEarnings'
         *              Update Balance in ViewState
         *              
         *          {DisplayResultMesage}
         *              'BetResultLabel' = 'BetResultMessage' for 'betResultMulitiplier'
        */
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                PopulateIcons();
                double playerBalance = 100.00;
                ViewState.Add("Balance", playerBalance);
                MoneyBalanceLabel.Text = String.Format("{0:C}", playerBalance);
            }
        }

        //Initialize Variables
        //Enumeration: Icons
        private enum IconImages : int
        {
            Bar = 0,
            Seven = 1,
            Cherry = 2,
            Bell = 3,
            Clover = 4,
            Diamond = 5,
            HorseShoe = 6,
            Lemon = 7,
            Orange = 8,
            Plum = 9,
            Strawberry = 10,
            Watermellon = 11
        }
        //'iconDisplayArray[]'
        int[] iconDisplayArray = new int[3];

        //'betResultMultiplier' (0-5)
        int betResultMultiplier = 0;

        //'betResultMessageArray'
        string[] betResultMessageArray = new string[6]
        {
            "You Lost Your Money...",
            "Bar! You Lost Your Money...",
            "Triple 7s! You Won ",
            "1 Cherry! You Won ",
            "2 Cherries! You Won ",
            "3 Cherries! You Won "
        };

//EVENT: NEW TURN
        protected void LeverButton_Click(object sender, EventArgs e)
        {
            ExecuteTurn();
        }

// MAIN METHOD
        private void ExecuteTurn()
        {
            if (!GateForBetInput()) return;
            if (!GateBalanceRemains()) return;
            PopulateIcons();
            FindMultipliers();
            CalculateBetResults(out double betEarnings);
            DisplayResultMessage(betEarnings);
        }

// Gate for text input
        private bool GateForBetInput()
        {
            if (!double.TryParse(BetTextBox.Text, out double betValue))
            { 
                ErrorTextLabel.Text = "Your bet must be a numerical Value.";
                return false;
            }
            ErrorTextLabel.Text = "";
            return true;
        }

// Gate Balance Remains
        private bool GateBalanceRemains()
        {
            if ((double)ViewState["Balance"] > 0) return true;
            BetResultLabel.Text = "";
            ErrorTextLabel.Text = "<br />Whomp Whomp...<br /> You've lost all your money...";
            MoneyBalanceLabel.Text = "$0.00";
            return false;

        }

// POPULATE ICONS SECTION
        private void PopulateIcons()
        {
            RandomGenerator();
            AssignIcons();
        }

        private void RandomGenerator()
        {
            Random rando = new Random();
            for (int i = 0; i < iconDisplayArray.Length; i++)
            {
                iconDisplayArray[i] = rando.Next(0, 12);
            }
        }

        private void AssignIcons()
        {
            IconImages image1 = (IconImages)iconDisplayArray[0];
            IconImages image2 = (IconImages)iconDisplayArray[1];
            IconImages image3 = (IconImages)iconDisplayArray[2];

            IconImage1.ImageUrl = String.Format("~/Images/{0}.png",image1);
            IconImage2.ImageUrl = String.Format("~/Images/{0}.png",image2);
            IconImage3.ImageUrl = String.Format("~/Images/{0}.png",image3);
        }

// FIND MULTIPLIERS SECTION
        private void FindMultipliers()
        {
            if (GateForBar())    { betResultMultiplier = 1; return; }
            if (GateForSevens()) { betResultMultiplier = 2; return; }
            CountCherries(out int cherryCount);
            AssignCherryMulitiplier(cherryCount);
        }

        private bool GateForBar()
        {
            for (int i = 0; i < iconDisplayArray.Length; i++)
            {
                if (iconDisplayArray[i] == 0) return true;
            };
            return false;
        }

        private bool GateForSevens()
        {
            for (int i = 0; i < iconDisplayArray.Length; i++)
            {
                if (iconDisplayArray[i] != 1) return false;
            }
            return true;
        }

        private int CountCherries(out int cherryCount)
        {
            cherryCount = 0;
            for (int i = 0; i < iconDisplayArray.Length; i++)
            {
                if (iconDisplayArray[i] == 2) cherryCount += 1;
            }
            return cherryCount;
        }

        private void AssignCherryMulitiplier(int cherryCount)
        {
            if (cherryCount == 1) { betResultMultiplier = 3; return; }
            else if (cherryCount == 2) { betResultMultiplier = 4; return; }
            else if (cherryCount == 3) { betResultMultiplier = 5; return; }
            else if (cherryCount == 0) { betResultMultiplier = 0; return; }
        }

// CALCULATE BET RESULTS
        private double CalculateBetResults(out double betEarnings)
        {
            double betValue = double.Parse(BetTextBox.Text);
            TranslateMultiplier(betResultMultiplier, out int multiplierValue);
            CalculateAndUpdateBalance(betValue, multiplierValue, out betEarnings);
            return betEarnings;
        }

        private int TranslateMultiplier(int multiplier, out int multiplierValue)
        {
            multiplierValue = 0;
            if (multiplier == 2) multiplierValue = 100;
            else if (multiplier == 3) multiplierValue = 2;
            else if (multiplier == 4) multiplierValue = 3;
            else if (multiplier == 5) multiplierValue = 4;
            return multiplierValue;
        }

        private double CalculateAndUpdateBalance(double Wager, int Multiplier, out double Earnings)
        {
            Earnings = Wager * Multiplier;
            double lastBalance = (double)ViewState["Balance"];
            double updatedBalance = lastBalance - Wager + (Wager * Multiplier);
            ViewState["Balance"] = updatedBalance;
            MoneyBalanceLabel.Text = String.Format("{0:C}",updatedBalance);
            return Earnings;
        }

// DISPLAY RESULT MESSAGE
        private void DisplayResultMessage(double EarningsFromLastBet)
        {
            double betValue = double.Parse(BetTextBox.Text);

            if (betResultMultiplier == 0 || betResultMultiplier == 1)
            {
                BetResultLabel.Text = betResultMessageArray[betResultMultiplier]
                    + String.Format("<br />{0:C} down the drain.", betValue);
                return;
            }
            else BetResultLabel.Text = betResultMessageArray[betResultMultiplier]
                    + String.Format("{0:C}! <br />Let's keep playing 'til you're broke!! Yay!", EarningsFromLastBet);
        }
    }
}