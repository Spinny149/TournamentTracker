using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents one team
    /// </summary>
    public class TeamModel
    {
        public int Id { get; set; }

        /// <summary>
        /// represents team names
        /// </summary>
        public string TeamName { get; set; }

        /// <summary>
        /// Represents team members
        /// </summary>
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

    }
}
