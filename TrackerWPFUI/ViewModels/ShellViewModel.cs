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
    public class ShellViewModel : Conductor<object>, IHandle<TournamentModel>
    {
        public ShellViewModel()
        {
            //Initalize the database connection
            GlobalConfig.InitializeConnections(TrackerLibrary.DatabaseType.Sql);

            EventAggregationProvider.TrackerEventAggregator.SubscribeOnPublishedThread(this);

            _existingTournaments = new BindableCollection<TournamentModel>(GlobalConfig.Connection.GetTournament_All());

        }

        public void CreateTournament()
        {
            ActivateItemAsync(new CreateTournamentViewModel());

        }

        public Task HandleAsync(TournamentModel message, CancellationToken cancellationToken)
        {
            //Open Tournament Viewer to the given tournament
            return Task.CompletedTask;
        }

        private BindableCollection<TournamentModel> _existingTournaments;

        public BindableCollection<TournamentModel> ExisitingTournaments
        {
            get { return _existingTournaments; }
            set { _existingTournaments = value; }
        }

        private TournamentModel _selectedTournament;

        public TournamentModel SelectedTournament
        {
            get { return _selectedTournament; }
            set 
            { 
                _selectedTournament = value;
                NotifyOfPropertyChange(() => SelectedTournament);
            }
        }



    }
}
