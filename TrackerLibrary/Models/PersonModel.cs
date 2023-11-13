using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    /// <summary>
    /// Represents user model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// The unique identifier for the prize
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Represents user name
        /// </summary>
        [Display(Name = "Given Name")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Represents user last name
        /// </summary>
        [Display(Name = "Last Name")]
        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Represents user eamil 
        /// </summary>
        [Display(Name = "Email")]
        [StringLength(200, MinimumLength = 6)]
        [Required]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Represents user cellphone
        /// </summary>
        [Display(Name = "CellPhone")]
        [StringLength(20, MinimumLength = 10)]
        [Required]
        public string CellphoneNumber { get; set; }

        public string FullName 
        {
            get { return $"{ FirstName } { LastName }"; }
        }
    }
}
