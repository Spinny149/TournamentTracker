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
    public class CreateTeamViewModel : Conductor<object>
    {
		private string _teamName = "";
        private BindableCollection<PersonModel> _availableTeamMembers;
        private PersonModel _selectedTeamMemberToAdd;
        private BindableCollection<PersonModel> _selectedTeamMembers = new BindableCollection<PersonModel>();
        private PersonModel _selectedTeamMemberToRemove;

        public CreateTeamViewModel()
        {
            AvailableTeamMembers = new BindableCollection<PersonModel>(GlobalConfig.Connection.GetPerson_All());
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

			//TODO: Pass team back to parent, close form


		}


   

    }
}
