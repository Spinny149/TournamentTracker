using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace TrackerWPFUI.ViewModels
{
    public class TournamentViewerViewModel : Screen
    {
        public TournamentModel Tournament { get; set; }

        private BindableCollection<int> _rounds = new BindableCollection<int>();
        private BindableCollection<MatchupModel> _matchups = new BindableCollection<MatchupModel>();
        private bool _unplayedOnly;
        private string _teamOne;
        private string _teamTwo;
        private double _teamOneScore;
        private double _teamTwoScore;
        private MatchupModel _selectedMatchup;
        private int _selectedRound;


        public BindableCollection<int> Rounds
        {
            get { return _rounds; }
            set { _rounds = value; }
        }

        public BindableCollection<MatchupModel> Matchups
        {
            get { return _matchups; }
            set { _matchups = value; }
        }

        public bool UnplayedOnly
        {
            get { return _unplayedOnly; }
            set 
            { 
                _unplayedOnly = value;
                NotifyOfPropertyChange(() => UnplayedOnly);
                LoadMatchups();
            }
        }

        public string TeamOne
        {
            get { return _teamOne; }
            set 
            { 
                _teamOne = value;
                NotifyOfPropertyChange(() => TeamOne);
            }
        }

        public string TeamTwo
        {
            get { return _teamTwo; }
            set 
            { 
                _teamTwo = value;
                NotifyOfPropertyChange(() => TeamTwo);
            }
        }

        public double TeamOneScore
        {
            get { return _teamOneScore; }
            set 
            { 
                _teamOneScore = value; 
                NotifyOfPropertyChange(() => TeamOneScore);
            }
        }

        public double TeamTwoScore
        {
            get { return _teamTwoScore; }
            set 
            { 
                _teamTwoScore = value; 
                NotifyOfPropertyChange(() => TeamTwoScore);
            }
        }

        public int SelectedRound
        {
            get { return _selectedRound; }
            set 
            { 
                _selectedRound = value; 
                NotifyOfPropertyChange(() => SelectedRound);
                LoadMatchups();
            }
        }

        public TournamentViewerViewModel(TournamentModel model)
        {
            Tournament = model;
            LoadRounds();
        }

        public MatchupModel SelectedMatchup
        {
            get { return _selectedMatchup; }
            set 
            { 
                _selectedMatchup = value;
                NotifyOfPropertyChange(() => SelectedMatchup);
                LoadMatchup();
            }
        }

        private void LoadRounds()
        {
            Rounds.Clear();

            Rounds.Add(1);
            int currRound = 1;

            foreach (List<MatchupModel> matchups in Tournament.Rounds)
            {
                if (matchups.First().MatchupRound > currRound)
                {
                    currRound = matchups.First().MatchupRound;
                    Rounds.Add(currRound);
                }
            }

            SelectedRound = 1;
        }

        private void LoadMatchups()
        {
            foreach (List<MatchupModel> matchups in Tournament.Rounds)
            {
                if (matchups.First().MatchupRound == SelectedRound)
                {
                    Matchups.Clear();

                    foreach (MatchupModel m in matchups)
                    {
                        if (m.Winner == null || !UnplayedOnly)
                        {
                            Matchups.Add(m);
                        }
                    }
                }
            }
            if (Matchups.Count > 0)
            {
                SelectedMatchup = Matchups.First();
            }
        }

        private void LoadMatchup()
        {

            if (SelectedMatchup != null)
            {
                for (int i = 0; i < SelectedMatchup.Entries.Count; i++)
                {
                    if (i == 0)
                    {
                        if (SelectedMatchup.Entries[0].TeamCompeting != null)
                        {
                            TeamOne = SelectedMatchup.Entries[0].TeamCompeting.TeamName;
                            TeamOneScore = SelectedMatchup.Entries[0].Score;

                            TeamTwo = "<bye>";
                            TeamTwoScore = 0;
                        }
                        else
                        {
                            TeamOne = "Not Yet Set";
                            TeamOneScore = 0;
                        }
                    }


                    if (i == 1)
                    {
                        if (SelectedMatchup.Entries[1].TeamCompeting != null)
                        {
                            TeamTwo = SelectedMatchup.Entries[1].TeamCompeting.TeamName;
                            TeamTwoScore = SelectedMatchup.Entries[1].Score;
                        }
                        else
                        {
                            TeamTwo = "Not Yet Set";
                            TeamTwoScore = 0;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }

        public void ScoreMatch()
        {
            for (int i = 0; i < SelectedMatchup.Entries.Count; i++)
            {
                if (i == 0)
                {
                    if (SelectedMatchup.Entries[0].TeamCompeting != null)
                    {
                        SelectedMatchup.Entries[0].Score = TeamOneScore;                       
                    }
                }

                if (i == 1)
                {
                    if (SelectedMatchup.Entries[0].TeamCompeting != null)
                    {
                        
                        SelectedMatchup.Entries[1].Score = TeamTwoScore;                       
                    }
                }
            }

            try
            {
                TournamentLogic.UpdateTournamentdResults(Tournament);

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Application Had Following ERROR: {ex.Message}");
                return;
            }

            LoadMatchups();
        
        }

    }    
}
