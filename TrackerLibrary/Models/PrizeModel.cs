using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents rewards for round
    /// </summary>
    public class PrizeModel
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents place in content
        /// </summary>
        public int PlaceNumber { get; set; }

        /// <summary>
        /// Represents name of taken place
        /// </summary>
        public string PlaceName { get; set; }

        /// <summary>
        /// Represents amount of money to win
        /// </summary>
        public decimal PrizeAmount { get; set; }

        /// <summary>
        /// Represents prize percentage
        /// </summary>
        public double PrizePercentage { get; set; }


        public PrizeModel()
        {

        }

        public PrizeModel(string placeName, string placeNumber, string prizeAmount, string prizePercentage)
        {
            PlaceName = placeName;

            int placeNumbervalue = 0;
            int.TryParse(placeNumber, out placeNumbervalue);
            PlaceNumber = placeNumbervalue;


            decimal prizeAmountValue = 0;
            decimal.TryParse(prizeAmount, out prizeAmountValue);
            PrizeAmount = prizeAmountValue;

            double prizePercentageValue = 0;
            double.TryParse(prizePercentage, out prizePercentageValue);
            PrizePercentage = prizePercentageValue;



        }


    }
}
