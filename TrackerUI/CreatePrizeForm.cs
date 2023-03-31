using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrackerUI
{
    public partial class CreatePrizeForm : Form
    {
        public CreatePrizeForm()
        {
            InitializeComponent();
        }

        private void createPrizeButton_Click(object sender, EventArgs e)
        {

        }

        private bool ValidateForm() 
        { 
            bool output = false;
            int placeNumber = 0;
            if(int.TryParse(placeNumberValue.Text, out placeNumber))
            { }


            return output;
        }
    }
}
