using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;
using TrackerLibrary.DataAccess;
using TrackerLibrary.Models;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        private IPrizerequestor callingForm;

        public CreatePrizeForm(IPrizerequestor caller)
        {
            InitializeComponent();
            callingForm = caller;
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {
            if (ValidateForm()) 
            {
                PrizeModel model = new PrizeModel(
                    placeNameValue.Text, 
                    placeNumberValue.Text, 
                    prizeAmountValue.Text, 
                    prizePrecentageValue.Text);
                
                GlobalConfig.Connection.CreatePrize(model);

                callingForm.PrizeComplete(model);

                this.Close();

                //placeNameValue.Text = "";
                //placeNumberValue.Text = "";
                //prizeAmountValue.Text = "0";
                //prizePrecentageValue.Text = "0";

            }
            else
            {
                MessageBox.Show("This form has invalid information");
            }

        }

        private bool ValidateForm() 
        { 
            bool output = true;
            int placeNumber = 0;

            if(int.TryParse(placeNumberValue.Text, out placeNumber) == false)
            { 
                output = false;
            }

            if (placeNumber < 1)
            {
                output = false;  
            }

            if (placeNameValue.Text.Length == 0) 
            {
                output = false;
            }

            decimal prizeAmount = 0;
            double prizePercentage = 0;

            bool prizeAmountValid = decimal.TryParse(prizeAmountValue.Text, out prizeAmount);
            bool prizePercentageValid = double.TryParse(prizeAmountValue.Text, out prizePercentage);

            if (prizeAmountValid == false || prizePercentageValid == false) 
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }
    }
}
