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
    public class CreatePrizeViewModel : Screen
    {
		private int _placeNumber;
        private string _placeName;
        private decimal _prizeAmount;
        private double _prizePercentage;
		//test git
        public int PlaceNumber
        {
			get { return _placeNumber; }
			set 
			{ 
				_placeNumber = value;
                NotifyOfPropertyChange(() => PlaceNumber);
            }
		}

		public string PlaceName
		{
			get { return _placeName; }
			set 
			{ 
				_placeName = value;
				NotifyOfPropertyChange(() => PlaceName);
			}
		}

		public decimal PrizeAmount
		{
			get { return _prizeAmount; }
			set 
			{ 
				_prizeAmount = value;
                NotifyOfPropertyChange(() => PrizeAmount);
            }
		}

		public double PrizePercentage
		{
			get { return _prizePercentage; }
			set 
			{ 
				_prizePercentage = value;
                NotifyOfPropertyChange(() => PrizePercentage);
            }
		}

		public bool CanCreatePrize(int placeNumber, string placeName, decimal prizeAmount, double prizePercentage)
		{
			return ValidateForm(placeNumber, placeName, prizeAmount, prizePercentage);
		}

		public void CreatePrize(int placeNumber, string placeName, decimal prizeAmount, double prizePercentage)
		{
			PrizeModel p = new PrizeModel { PlaceNumber = placeNumber, PlaceName = placeName, 
				PrizeAmount = prizeAmount, PrizePercentage = prizePercentage};

			GlobalConfig.Connection.CreatePrize(p);

			//TODO: Close the form, alert calling form
		}

		private bool ValidateForm(int placeNumber, string placeName, decimal prizeAmount, double prizePercentage)
        {
            bool output = true;

            if (placeNumber < 1)
            {
                output = false;
            }

            if (placeName.Length == 0)
            {
                output = false;
            }

            if (prizeAmount <= 0 && prizePercentage <= 0)
            {
                output = false;
            }

            if (prizePercentage < 0 || prizePercentage > 100)
            {
                output = false;
            }

            return output;
        }

    }
}
