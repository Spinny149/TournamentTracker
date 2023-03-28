using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary
{
    /// <summary>
    /// Represents user model
    /// </summary>
    public class PersonModel
    {
        /// <summary>
        /// Represents user name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Represents user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Represents user eamil 
        /// </summary>
        public string EmailAddress { get; set; }

        /// <summary>
        /// Represents user cellphone
        /// </summary>
        public string CellphoneNumber { get; set; }
    }
}
