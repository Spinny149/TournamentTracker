﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
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
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        /// <summary>
        /// Represents team members
        /// </summary>
        [Display(Name = "Team Members")]
        public List<PersonModel> TeamMembers { get; set; } = new List<PersonModel>();

    }
}
