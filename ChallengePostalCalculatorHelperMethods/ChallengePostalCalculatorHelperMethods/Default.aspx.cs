using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengePostalCalculatorHelperMethods
{
    public partial class Default : System.Web.UI.Page
    {
/*
 *      .:Overview:.
 *      
 *          Event: Input_Changed
 *      
                // Display Shipping Cost

                    // Check Input
                        "TextBox Empty" 
                        "Radio Checked"
                        "TextBox TryParse"
                            error messages

                    // Calculate Cost
                        "GetShippingMultiplier"
                        "Calculate Volume"
                        "Calculate Cost"

                    // Display Results 
                        "Shipping Time"
                        "Shipping Cost"
*/

 // EVENTS SECTION

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DepthLabel.Text = "*If 'Depth' is undeclared, the package <br />will assume 1/2 inch thickness.";
            }
        }

        protected void Input_Changed(object sender, EventArgs e)
        {
            DisplayShippingCost();
        }

 // Variables

        double packageWidth = 0;
        double packageHeight = 0;
        double packageDepth = 0.5;
        double shippingCost = 0;

 // MAIN METHOD

        private void DisplayShippingCost()
        {
            // Check Input
            if (!CheckInput()) return;
            // Calculate Cost
            CalculateCost(out shippingCost);
            // Display Cost
            DisplayCost();
        }

 // CHECK INPUT SECTION

        private bool CheckInput()
        {
            // Check Dimension Text Input (false if failed)
            if (WidthTextBox.Text.Trim().Length == 0
                || HeightTextBox.Text.Trim().Length == 0) return false;
            // Check Radio Buttons Input (false if failed)
            if (!GroundRadioButton.Checked
                && !AirRadioButton.Checked
                && !NextDayRadioButton.Checked) return false;
            // Check Input Dimension Text for Numerical Values (false if failed)
            if (!CheckDimensionInputText())
            {
                ResultLabel.Text = "";
                return false;
            }
            // If All Gates Are Passed (return true)
            ErrorLabel.Text = "";
            return true;
        }

        private bool CheckDimensionInputText()
        {
            // Check Input Dimension Text for Numerical Values (false if failed)
            if (!double.TryParse(WidthTextBox.Text.Trim(), out packageWidth))
            {
                ErrorLabel.Text = "The package width requires a numerical input.";
                return false;
            }
            if (!double.TryParse(HeightTextBox.Text.Trim(), out packageHeight))
            {
                ErrorLabel.Text = "The package height requires a numerical input.";
                return false;
            }
            if (double.TryParse(DepthTextBox.Text.Trim(), out packageDepth))
            {
                DepthLabel.Text = "";
                return true;
            }
            else
            {
                DepthLabel.Text = "If 'Depth' is undeclared, the package <br />will assume 1/2 inch thickness.";
                packageDepth = 0.5;
                return true;
            };
        }

 // CALCULATE COST SECTION

        private double CalculateCost(out double shippingCost)
        {
            // Get Shipping Cost Inputs
            GetShippingMethodMultiplier(out double shippingMultiplier);
            CalculateVolume(out double packageVolume);
            // Calculate Shipping Cost
            shippingCost = shippingMultiplier * packageVolume;
            return shippingCost;
        }

        private double GetShippingMethodMultiplier(out double shippingMultiplier)
        {
            shippingMultiplier = 0;
            if (GroundRadioButton.Checked) shippingMultiplier = .15;
            if (AirRadioButton.Checked) shippingMultiplier = .25;
            if (NextDayRadioButton.Checked) shippingMultiplier = .45;

            return shippingMultiplier;
        }

        private double CalculateVolume(out double packageVolume)
        {
            packageVolume = packageWidth * packageHeight * packageDepth;

            return packageVolume;
        }

 // DISPLAY RESULTS SECTION

        private void DisplayCost()
        {
            GetShippingTime(out string shippingTime);
            ResultLabel.Text = String.Format("Shipping Cost: {0:C}", shippingCost)
                + "<br />Your package will be delivered " + shippingTime;
        }

        private string GetShippingTime(out string shippingTime)
        {
            shippingTime = "";
            if (GroundRadioButton.Checked) shippingTime = "within 2-5 business days";
            if (AirRadioButton.Checked) shippingTime = "within 1-3 business days";
            if (NextDayRadioButton.Checked) shippingTime = "by tomorrow";
            return shippingTime;
        }

    }
}