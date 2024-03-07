using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackerLibrary.Models;

namespace MVCUI.Models
{
    public class TournamentMVCModel
    {
        /// <summary>
        /// Represents tournament phase
        /// </summary>
        [Display(Name = "Tournament Name")]
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string TournamentName { get; set; }

        /// <summary>
        /// Represents entry money to bet
        /// </summary>
        [Display(Name = "Entry Fee")]
        [Required]
        [DataType(DataType.Currency)]
        public decimal EntryFee { get; set; }

        /// <summary>
        /// Represents teams in tournament
        /// </summary>
        [Display(Name = "Entered Teams")]
        public List<SelectListItem> EnteredTeams { get; set; } = new List<SelectListItem>();
        public List<string> SelectedEnteredTeams { get; set; } = new List<string>();


        /// <summary>
        /// Represents prizes to win???
        /// </summary>
        [Display(Name = "Prizes")]
        public List<SelectListItem> Prizes { get; set; } = new List<SelectListItem>();
        public List<string> SelectedPrizes { get; set; } = new List<string>();

    }
}