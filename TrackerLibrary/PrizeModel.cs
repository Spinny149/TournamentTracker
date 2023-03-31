using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
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


    }
}
