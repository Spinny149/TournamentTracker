using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWPFUI.ViewModels
{
    public class CreatePersonViewModel : Screen
    {
		private string _firstName = "";
		private string _lastName = "";
		private string _email = "";
		private string _cellPhone = "";

		public string FirstName
		{
			get { return _firstName; }
			set 
			{ 
				_firstName = value; 
				NotifyOfPropertyChange(() => FirstName);
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set 
			{ 
				_lastName = value;
				NotifyOfPropertyChange(() => LastName);
			}
		}

		public string Email
		{
			get { return _email; }
			set 
			{ 
				_email = value; 
				NotifyOfPropertyChange(() => Email);
			}
		}

		public string CellPhone
		{
			get { return _cellPhone; }
			set 
			{ 
				_cellPhone = value; 
				NotifyOfPropertyChange(() => CellPhone);
			}
		}

		public bool CanCreatePerson(string firstName, string lastName, string email, string cellphone)
		{
			if(firstName.Length > 0 && lastName.Length > 0 && email.Length > 0 && cellphone.Length > 0)
			{
				return true;
			}
			else
			{
				return false;
			}

		}


        public void CreatePerson(string firstName, string lastName,string email, string cellphone)
		{
            PersonModel p = new PersonModel();
            p.FirstName = firstName;
            p.LastName = lastName;
            p.EmailAddress = email;
            p.CellphoneNumber = cellphone;

            GlobalConfig.Connection.CreatePerson(p);

			//TODO: Send to back to parent and close

        }



	}
}
