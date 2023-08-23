using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWPFUI.ViewModels
{
    public class CreateTeamViewModel : Conductor<object>, IHandle<PersonModel>
    {
		private string _teamName = "";
        private BindableCollection<PersonModel> _availableTeamMembers;
        private PersonModel _selectedTeamMemberToAdd;
        private BindableCollection<PersonModel> _selectedTeamMembers = new BindableCollection<PersonModel>();
        private PersonModel _selectedTeamMemberToRemove;
		private bool _selectedTeamMembersIsVisible = true;
        private bool _addPersonIsVisible = false;

        public CreateTeamViewModel()
        {
            AvailableTeamMembers = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPerson_All());
			EventAggregationProvider.TrackerEventAggregator.SubscribeOnPublishedThread(this);			
        }

        public string TeamName
        {
			get { return _teamName; }
			set 
			{ 
				_teamName = value;
				NotifyOfPropertyChange(() => TeamName);
			}
		}

		public bool SelectedTeamMembersIsVisible
        {
			get { return _selectedTeamMembersIsVisible; }
			set 
			{ 
				_selectedTeamMembersIsVisible = value; 
				NotifyOfPropertyChange(() => SelectedTeamMembersIsVisible);
			}
		}

		public bool AddPersonIsVisible
        {
			get { return _addPersonIsVisible; }
			set 
			{ 
				_addPersonIsVisible = value; 
				NotifyOfPropertyChange(() => AddPersonIsVisible);
			}
		}

		public BindableCollection<PersonModel> AvailableTeamMembers
		{
			get { return _availableTeamMembers; }
			set 
			{ 
				_availableTeamMembers = value; 
			}
		}

		public PersonModel SelectedTeamMemberToAdd
        {
			get { return _selectedTeamMemberToAdd; }
			set 
			{ 
				_selectedTeamMemberToAdd = value; 
				NotifyOfPropertyChange(() => SelectedTeamMemberToAdd);
				NotifyOfPropertyChange(() => CanAddMember);
			}
		}

		public BindableCollection<PersonModel> SelectedTeamMembers
		{
			get { return _selectedTeamMembers; }
			set 
			{ 
				_selectedTeamMembers = value;
                NotifyOfPropertyChange(() => CanCreateTeam);
            }
        }
		
		public PersonModel SelectedTeamMemberToRemove
        {
			get { return _selectedTeamMemberToRemove; }
			set 
			{ 
				_selectedTeamMemberToRemove = value; 
				NotifyOfPropertyChange(() => SelectedTeamMemberToRemove);
				NotifyOfPropertyChange(() => CanRemoveMember);
            }
        }

		public bool CanAddMember
		{
			get
			{
				return SelectedTeamMemberToAdd != null;
			}
		}

		public void AddMember()
		{
			SelectedTeamMembers.Add(SelectedTeamMemberToAdd);
			AvailableTeamMembers.Remove(SelectedTeamMemberToAdd);
            NotifyOfPropertyChange(() => CanCreateTeam);

        }

        public void CreateMember()
        {
			ActivateItemAsync(new CreatePersonViewModel());
			SelectedTeamMembersIsVisible = false;
			AddPersonIsVisible = true;
        }

		public bool CanRemoveMember
		{
			get
			{
                return SelectedTeamMemberToRemove != null;
            }
			
		}

        public void RemoveMember() 
		{
			AvailableTeamMembers.Add(SelectedTeamMemberToRemove);
			SelectedTeamMembers.Remove(SelectedTeamMemberToRemove);
            NotifyOfPropertyChange(() => CanCreateTeam);

        }

		public void CancleCreation()
		{
            EventAggregationProvider.TrackerEventAggregator.PublishOnUIThreadAsync(new TeamModel());
            this.TryCloseAsync();
        }

        public bool CanCreateTeam
		{
            get
            {
                if (SelectedTeamMembers != null)
                {
                    if (TeamName.Length > 0 && SelectedTeamMembers.Count > 0)
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

		public void CreateTeam()
		{
			TeamModel t = new TeamModel();

			t.TeamName = TeamName;
			t.TeamMembers = SelectedTeamMembers.ToList();

			GlobalConfig.Connection.CreateTeam(t);

            EventAggregationProvider.TrackerEventAggregator.PublishOnUIThreadAsync(t);
            this.TryCloseAsync();

        }

        public Task HandleAsync(PersonModel message, CancellationToken cancellationToken)
        {
			if (!string.IsNullOrWhiteSpace(message.FullName))
			{
				SelectedTeamMembers.Add(message);
				NotifyOfPropertyChange(() => CanCreateTeam);
			}

            SelectedTeamMembersIsVisible = true;
            AddPersonIsVisible = false;
            
			return Task.CompletedTask;
        }
    }
}
