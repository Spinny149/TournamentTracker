using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackerLibrary.Models;

namespace MVCUI.Models
{
    public class TeamMVCModel
    {
        /// <summary>
        /// represents team names
        /// </summary>
        [Display(Name = "Team Name")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string TeamName { get; set; }

        /// <summary>
        /// Represents team members
        /// </summary>
        [Display(Name = "Team Members")]
        public List<SelectListItem> TeamMembers { get; set; } = new List<SelectListItem>();

        public List<string> SelectedTeamMembers { get; set; } = new List<string>();
    }
}