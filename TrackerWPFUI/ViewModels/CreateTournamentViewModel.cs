using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.Models;

namespace TrackerWPFUI.ViewModels
{
    public class CreateTournamentViewModel : Conductor<object>.Collection.AllActive
    {
		private string _tournamentName;
        private decimal _entryFee;
        private int myVar;
        private BindableCollection<TeamModel> _availableTeams;
        private TeamModel _selectedTeamToAdd;
        private BindableCollection<TeamModel> _selectedteams;
        private TeamModel _selectedtemToRemove;
        private Screen _activeAddTeamView;
        private BindableCollection<PrizeModel> _selectedPrizes;
        private PrizeModel _selectedPrizeToRemove;
        private Screen _activeAddPrizeView;

        public string TournamentName
        {
			get { return _tournamentName; }
			set 
			{ 
				_tournamentName = value;
				NotifyOfPropertyChange(() => TournamentName);			
			}
		}

		public decimal EntryFee
		{
			get { return _entryFee; }
			set 
			{
				_entryFee = value; 
				NotifyOfPropertyChange(() => EntryFee);
			
			}
		}

		public int MyProperty
		{
			get { return myVar; }
			set { myVar = value; }
		}

		public BindableCollection<TeamModel> AvailableTeams
        {
			get { return _availableTeams; }
			set { _availableTeams = value; }
		}

		public TeamModel SelectedTeamToAdd
		{
			get { return _selectedTeamToAdd; }
			set 
			{
				_selectedTeamToAdd = value;
				NotifyOfPropertyChange(() => SelectedTeamToAdd);
			}
		}

		public BindableCollection<TeamModel> SelectedTeams
		{
			get { return _selectedteams; }
			set 
			{ 
				_selectedteams = value; 
				NotifyOfPropertyChange(() =>SelectedTeams);
			}
		}

		public TeamModel SelectedTeamToRemove
		{
			get { return _selectedtemToRemove; }
			set 
			{ 
				_selectedtemToRemove = value;
				NotifyOfPropertyChange(() => SelectedTeamToRemove);
			}
		}

		public Screen ActiveAddTeamView
		{
			get { return _activeAddTeamView; }
			set 
			{ 
				_activeAddTeamView = value; 
				NotifyOfPropertyChange(() => ActiveAddTeamView);
			
			}
		}

		public BindableCollection<PrizeModel> SelectedPrizes
		{
			get { return _selectedPrizes; }
			set { _selectedPrizes = value; }
		}

		public PrizeModel SelectedPrizeToRemove
		{
			get { return _selectedPrizeToRemove; }
			set
			{
				_selectedPrizeToRemove = value;
				NotifyOfPropertyChange(() => SelectedPrizeToRemove);
			}
		}

		public Screen ActiveAddPrizeView
        {
			get { return _activeAddPrizeView; }
			set 
			{ 
				_activeAddPrizeView = value;
				NotifyOfPropertyChange(() => ActiveAddPrizeView);
			}
		}

		public bool CanAddTeam()
		{
			return SelectedTeamToAdd != null;
        }

		public void AddTeam()
		{

		}

		public void CreateTeam()
		{

		}

		public bool CanRemoveTeam()
		{
			return SelectedTeamToRemove != null;
		}

		public void RemoveTeam()
		{

		}

		public void CreatePrize()
		{

		}

		public bool CanRemovePrize()
		{
			return SelectedPrizeToRemove != null;
		}

		public void RemovePrize()
		{

		}

		public bool CanCreateTournament()
		{
			//TODO: Add logic
			return true;
		}

		public void CreateTournament()
		{

		}
	}
}
