using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWPFUI.ViewModels
{
    public class CreateTournamentViewModel : Conductor<object>.Collection.AllActive, IHandle<TeamModel>, IHandle<PrizeModel>
    {
		private string _tournamentName = "";
        private decimal _entryFee;
        private int myVar;
        private BindableCollection<TeamModel> _availableTeams;
        private TeamModel _selectedTeamToAdd;
        private BindableCollection<TeamModel> _selectedteams = new BindableCollection<TeamModel>();
        private TeamModel _selectedtemToRemove;		
		private bool _selectedTeamsIsVisible = true;
        private Screen _activeAddTeamView;
        private bool _addTeamIsVisible = false;
        private BindableCollection<PrizeModel> _selectedPrizes = new BindableCollection<PrizeModel>();
        private PrizeModel _selectedPrizeToRemove;
        private Screen _activeAddPrizeView;
        private bool _selectedPrizesIsVisible = true;
        private bool _addPrizeIsVisible = false;

        public CreateTournamentViewModel()
        {
			AvailableTeams = new BindableCollection<TeamModel>(GlobalConfig.Connection.GetTeam_All());
            EventAggregationProvider.TrackerEventAggregator.SubscribeOnPublishedThread(this);

        }
        public string TournamentName
        {
			get { return _tournamentName; }
			set 
			{ 
				_tournamentName = value;
				NotifyOfPropertyChange(() => TournamentName);
				NotifyOfPropertyChange(() => CanCreateTournament);
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
				NotifyOfPropertyChange(() => CanAddTeam);
			}
		}

		public BindableCollection<TeamModel> SelectedTeams
		{
			get { return _selectedteams; }
			set 
			{ 
				_selectedteams = value; 
				NotifyOfPropertyChange(() =>SelectedTeams);
				NotifyOfPropertyChange(() => CanCreateTournament);
			}
		}

		public TeamModel SelectedTeamToRemove
		{
			get { return _selectedtemToRemove; }
			set 
			{ 
				_selectedtemToRemove = value;
				NotifyOfPropertyChange(() => SelectedTeamToRemove);
				NotifyOfPropertyChange(() => CanRemoveTeam);
			}
		}

		public bool SelectedTeamsIsVisible
        {
			get { return _selectedTeamsIsVisible; }
			set 
			{ 
				_selectedTeamsIsVisible = value; 
				NotifyOfPropertyChange(() => SelectedTeamsIsVisible);
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

		public bool AddTeamIsVisible
        {
			get { return _addTeamIsVisible; }
			set 
			{ 
				_addTeamIsVisible = value; 
				NotifyOfPropertyChange(() => AddTeamIsVisible);			
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
				NotifyOfPropertyChange(() => CanRemovePrize);
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

		public bool AddPrizeIsVisible
        {
			get { return _addPrizeIsVisible; }
			set 
			{ 
				_addPrizeIsVisible = value; 
				NotifyOfPropertyChange(() => AddPrizeIsVisible);
			}
		}

		public bool SelectedPrizesIsVisible
        {
			get { return _selectedPrizesIsVisible; }
			set 
			{ 
				_selectedPrizesIsVisible = value; 
				NotifyOfPropertyChange(() => SelectedPrizesIsVisible);
			}
		}

		public bool CanAddTeam
		{
			get
			{
                return SelectedTeamToAdd != null;
            }
        }

		public void AddTeam()
		{
			SelectedTeams.Add(SelectedTeamToAdd);
			AvailableTeams.Remove(SelectedTeamToAdd);
            NotifyOfPropertyChange(() => CanCreateTournament);
        }

        public void CreateTeam()
		{
			ActiveAddTeamView = new CreateTeamViewModel();
			Items.Add(ActiveAddTeamView);

			SelectedTeamsIsVisible = false;
			AddTeamIsVisible = true;

        }

		public bool CanRemoveTeam
		{
			get
			{
				return SelectedTeamToRemove != null;
			}
		}

		public void RemoveTeam()
		{
			AvailableTeams.Add(SelectedTeamToRemove);
            SelectedTeams.Remove(SelectedTeamToRemove);
            NotifyOfPropertyChange(() => CanCreateTournament);
        }

        public void CreatePrize()
		{
			ActiveAddPrizeView = new CreatePrizeViewModel();
			Items.Add(ActiveAddPrizeView);

			SelectedPrizesIsVisible = false;
			AddPrizeIsVisible = true;
		}

		public bool CanRemovePrize
		{
			get
			{
				return SelectedPrizeToRemove != null;
			}
		}

		public void RemovePrize()
		{
			SelectedPrizes.Remove(SelectedPrizeToRemove);
		}

		public bool CanCreateTournament
		{
			get
			{
				if(SelectedTeams != null)
				{
                    if (TournamentName.Length > 0 && SelectedTeams.Count > 1)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
				else
				{
					return false;
				}
			}
		}

		public void CreateTournament()
		{
            //Create Tournament model
            TournamentModel tm = new TournamentModel();
            tm.TournamentName = TournamentName;
            tm.EntryFee = EntryFee;

            tm.Prizes = SelectedPrizes.ToList();
            tm.EnteredTeams = SelectedTeams.ToList();

            //Wireup matchup
            TournamentLogic.CreateRounds(tm);

            //Create tournament entries
            //Create all of the prizes entries
            //Create all of team entries
            GlobalConfig.Connection.CreateTournament(tm);

            tm.AlertUsersToNewRound();

            EventAggregationProvider.TrackerEventAggregator.PublishOnUIThreadAsync(tm);
            this.TryCloseAsync();
        }

        public Task HandleAsync(TeamModel message, CancellationToken cancellationToken)
        {
			if(!string.IsNullOrWhiteSpace(message.TeamName))
			{
				SelectedTeams.Add(message);
                NotifyOfPropertyChange(() => CanCreateTournament);
            }

            SelectedTeamsIsVisible = true;
            AddTeamIsVisible = false;

			return Task.CompletedTask;
        }

        public Task HandleAsync(PrizeModel message, CancellationToken cancellationToken)
        {
			if(!string.IsNullOrWhiteSpace(message.PlaceName))
			{
				SelectedPrizes.Add(message);
			}

            SelectedPrizesIsVisible = true;
            AddPrizeIsVisible = false;

			return Task.CompletedTask;
        }
    }
}
