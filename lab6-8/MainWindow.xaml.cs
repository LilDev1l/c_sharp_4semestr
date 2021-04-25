using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GameStore.DataWork;
using GameStore.Commands;
using System.Windows.Resources;

namespace GameStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Game> currentGames;
        private UndoRedoStack undoRedo;

        public MainWindow()
        {
            State state = State.GetState();
            InitializeComponent();
            currentGames = new List<Game>();
            state.Languege = Languege.EN;
            state.Theme = ThemeType.BLUE;
            undoRedo = new UndoRedoStack();
            DisplayGames();
        }

        private void GenreSort_All_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(()=> {
                DisplayGames();
            });
            undoRedo.AddAction(command);

            DisplayGames();
        }
        private void GenreSort_Action_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.ACTION);
            });
            undoRedo.AddAction(command);
            
            DisplayGames(Genre.ACTION);
        }
        private void GenreSort_Shooter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.SHOOTER);
            });
            undoRedo.AddAction(command);
            
            DisplayGames(Genre.SHOOTER);
        }
        private void GenreSort_Arcade_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.ARCADE);
            });
            undoRedo.AddAction(command);
           
            DisplayGames(Genre.ARCADE);
        }
        private void GenreSort_RPG_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.RPG);
            });
            undoRedo.AddAction(command);
            
            DisplayGames(Genre.RPG);
        }
        private void GenreSort_Horror_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.HORROR);
            });
            undoRedo.AddAction(command);
           
            DisplayGames(Genre.HORROR);
        }
        private void GenreSort_Fighting_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.FIGHTING);
            });
            undoRedo.AddAction(command);
           
            DisplayGames(Genre.FIGHTING);
        }
        private void GenreSort_Simulator_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.SIMULATOR);
            });
            undoRedo.AddAction(command);
           
            DisplayGames(Genre.SIMULATOR);
        }
        private void GenreSort_Race_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayGames(Genre.RACE);
            });
            undoRedo.AddAction(command);
          
            DisplayGames(Genre.RACE);
        }

        public void DisplayGames(Genre genre = Genre.ALL)
        {
            List<Game> games = GameDataService.FindAll();

            currentGames.Clear();
            DataSectionStack.Children.Clear();

            if (genre != Genre.ALL)
            {
                foreach (var game in games)
                {
                    if (game.Genre == genre)
                    {
                        GameCell gameCell = new GameCell(game, this);
                        Grid viewGameCell = gameCell.BuildCell();
                        DataSectionStack.Children.Add(viewGameCell);
                        currentGames.Add(game);
                    }
                }
            }
            else
            {
                foreach (var game in games)
                {
                    GameCell gameCell = new GameCell(game, this);
                    Grid viewGameCell = gameCell.BuildCell();
                    DataSectionStack.Children.Add(viewGameCell);
                }
                currentGames = games;
            }
        }

        private void Filters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ByPoplarityButton.IsChecked == true)
            {
                UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                    SortByPopularity();
                    PrintCurrentGames();
                });
                undoRedo.AddAction(command);
                
                SortByPopularity();
                PrintCurrentGames();
                ByPoplarityButton.IsChecked = false;
            }
            else if (ByNameButton.IsChecked == true)
            {
                UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                    SortByName();
                    PrintCurrentGames();
                });
                undoRedo.AddAction(command);
              
                SortByName();
                PrintCurrentGames();
                ByNameButton.IsChecked = false;
            }
            else if (ByPriceButton.IsChecked == true)
            {
                UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                    SortByPrice();
                    PrintCurrentGames();
                });
                undoRedo.AddAction(command);
              
                SortByPrice();
                PrintCurrentGames();
                ByPriceButton.IsChecked = false;
            }
            else 
            {
                MessageBox.Show("Please, choose type for filter...");
            }
        }

        private void SortByPopularity()
        {
            currentGames.Sort((n,q)=> 
            {
                if (n.Rating < q.Rating)
                    return 1;
                else if (n.Rating > q.Rating)
                    return -1;
                else return 0;
            });
        }
        private void SortByName()
        {
            currentGames.Sort((n, q) =>
            {
                if (n.FullName.First() > q.FullName.First())
                    return 1;
                else if (n.FullName.First() < q.FullName.First())
                    return -1;
                else return 0;
            });
        }
        private void SortByPrice()
        {
            currentGames.Sort((n, q) =>
            {
                if (n.Price > q.Price)
                    return 1;
                else if (n.Price < q.Price)
                    return -1;
                else return 0;
            });
        }
        private void PrintCurrentGames()
        {
            DataSectionStack.Children.Clear();
            foreach (var game in currentGames)
            {
                GameCell gameCell = new GameCell(game, this);
                Grid viewGameCell = gameCell.BuildCell();
                DataSectionStack.Children.Add(viewGameCell);
            }
        }

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string findName = FindBar.Text;

            DataSectionStack.Children.Clear();
            currentGames.Clear();
            currentGames = GameDataService.FindByName(findName);

            if (currentGames != null && currentGames.Count > 0)
            {
                PrintCurrentGames();
            }

            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DataSectionStack.Children.Clear();
                currentGames.Clear();
                currentGames = GameDataService.FindByName(findName);

                if (currentGames != null && currentGames.Count > 0)
                {
                    PrintCurrentGames();
                }
            });
            undoRedo.AddAction(command);
            
        }
        private void AddGame_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataUpdate dataUpdate = new DataUpdate();
            dataUpdate.Owner = this;
            dataUpdate.Show();
        }

        private void LangButton_Click(object sender, RoutedEventArgs e)
        {
            State langState = State.GetState();
            switch (langState.Languege)
            {
                case Languege.EN:
                    SetRuLocal(langState);
                    break;
                case Languege.RU:
                    SetEnLocal(langState);
                    break;
                default:
                    break;
            }
        }

        private void SetRuLocal(State langState)
        {
            langState.Languege = Languege.RU;
            LangButton.Text = "RU";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/Language/RULocal.xaml", UriKind.Relative)};

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllGames.Text = (string)this.TryFindResource("AllGameGenre");
            Action.Text = (string)this.TryFindResource("ActionGameGenre");
            Shooter.Text = (string)this.TryFindResource("ShooterGameGenre");
            Arcade.Text = (string)this.TryFindResource("ArcadeGameGenre");
            Fighting.Text = (string)this.TryFindResource("FightingGameGenre");
            Race.Text = (string)this.TryFindResource("RaceGameGenre");
            Simulator.Text = (string)this.TryFindResource("SimulatorGameGenre");
            RPG.Text = (string)this.TryFindResource("RpgGameGenre");
            Horror.Text = (string)this.TryFindResource("HorrorGameGenre");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            ByRating.Text = (string)this.TryFindResource("FilterByPopularity");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }
        private void SetEnLocal(State langState)
        {
            langState.Languege = Languege.EN;
            LangButton.Text = "EN";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/Language/ENLocal.xaml", UriKind.Relative) };

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllGames.Text = (string)this.TryFindResource("AllGameGenre");
            Action.Text = (string)this.TryFindResource("ActionGameGenre");
            Shooter.Text = (string)this.TryFindResource("ShooterGameGenre");
            Arcade.Text = (string)this.TryFindResource("ArcadeGameGenre");
            Fighting.Text = (string)this.TryFindResource("FightingGameGenre");
            Race.Text = (string)this.TryFindResource("RaceGameGenre");
            Simulator.Text = (string)this.TryFindResource("SimulatorGameGenre");
            RPG.Text = (string)this.TryFindResource("RpgGameGenre");
            Horror.Text = (string)this.TryFindResource("HorrorGameGenre");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            ByRating.Text = (string)this.TryFindResource("FilterByPopularity");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }

        private void SetBlueTheme(State themeState)
        {
            themeState.Theme = ThemeType.BLUE;
            ThemeButtonText.Text = "BL";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/Recourses/BlueThems.xaml", UriKind.Relative) };

            BaseFrame.Style = (Style)this.TryFindResource("BackColor");
            Title.Style = (Style)this.TryFindResource("TitleLineColor");
            LogoPlace.Style = (Style)this.TryFindResource("TitleLineColor");
            FindPlace.Style  = (Style)this.TryFindResource("TitleLineColor");

            FilterPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            TableTitle.Style = FindPlace.Style = (Style)this.TryFindResource("TitleLineColor"); ;
            DataPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            MenuPlace.Style  = (Style)this.TryFindResource("MainViewsColor");

            AllButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ActionButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ArcadeButton.Style = (Style)this.TryFindResource("ButtonStyle"); 
            FightButton.Style= (Style)this.TryFindResource("ButtonStyle"); 
            ShooterButton.Style = (Style)this.TryFindResource("ButtonStyle"); 
            RaceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            SimulatorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            RPGButton.Style = (Style)this.TryFindResource("ButtonStyle");
            HorrorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("TitleLineColor");
            LangButton.Style = (Style)this.TryFindResource("TitleLineColor");
            ThemeButton.Style = (Style)this.TryFindResource("TitleLineColor");

            GroupButton.Style  = (Style)this.TryFindResource("ButtonStyle");
            ByNameButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPoplarityButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPriceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            
            AddGameButton.Style = (Style)this.TryFindResource("AddButtonTemplate");
        }
        private void SetRedTheme(State themeState)
        {
            themeState.Theme = ThemeType.RED;
            ThemeButtonText.Text = "RD";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/Recourses/RedThems.xaml", UriKind.Relative) };

            BaseFrame.Style = (Style)this.TryFindResource("BackColor");
            Title.Style = (Style)this.TryFindResource("TitleLineColor");
            LogoPlace.Style = (Style)this.TryFindResource("TitleLineColor");
            FindPlace.Style = (Style)this.TryFindResource("TitleLineColor");

            FilterPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            TableTitle.Style = FindPlace.Style = (Style)this.TryFindResource("TitleLineColor"); ;
            DataPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            MenuPlace.Style = (Style)this.TryFindResource("MainViewsColor");

            AllButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ActionButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ArcadeButton.Style = (Style)this.TryFindResource("ButtonStyle");
            FightButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ShooterButton.Style = (Style)this.TryFindResource("ButtonStyle");
            RaceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            SimulatorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            RPGButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LangButton.Style = (Style)this.TryFindResource("TitleLineColor");
            HorrorButton.Style = (Style)this.TryFindResource("ButtonStyle");

            GroupButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByNameButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPoplarityButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPriceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("TitleLineColor");
            ThemeButton.Style = (Style)this.TryFindResource("TitleLineColor");

            AddGameButton.Style = (Style)this.TryFindResource("AddButtonTemplate");
            
        }
        private void SetGrayTheme(State themeState)
        {
            themeState.Theme = ThemeType.GRAY;
            ThemeButtonText.Text = "GR";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/GameStore;component/Recourses/GrayThems.xaml", UriKind.Relative) };

            BaseFrame.Style = (Style)this.TryFindResource("BackColor");
            Title.Style = (Style)this.TryFindResource("TitleLineColor");
            LogoPlace.Style = (Style)this.TryFindResource("TitleLineColor");
            FindPlace.Style = (Style)this.TryFindResource("TitleLineColor");

            FilterPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            TableTitle.Style = FindPlace.Style = (Style)this.TryFindResource("TitleLineColor"); ;
            DataPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            MenuPlace.Style = (Style)this.TryFindResource("MainViewsColor");

            AllButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ActionButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ArcadeButton.Style = (Style)this.TryFindResource("ButtonStyle");
            FightButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ShooterButton.Style = (Style)this.TryFindResource("ButtonStyle");
            RaceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            SimulatorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            RPGButton.Style = (Style)this.TryFindResource("ButtonStyle");
            HorrorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("TitleLineColor");
            LangButton.Style = (Style)this.TryFindResource("TitleLineColor");
            ThemeButton.Style = (Style)this.TryFindResource("TitleLineColor");

            GroupButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByNameButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPoplarityButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPriceButton.Style = (Style)this.TryFindResource("ButtonStyle");

            AddGameButton.Style = (Style)this.TryFindResource("AddButtonTemplate");
        }
        private void ThemeButton_Click(object sender, RoutedEventArgs e)
        {
            State themeState = State.GetState();
            switch (themeState.Theme)
            {
                case ThemeType.BLUE:
                    SetGrayTheme(themeState);
                    break;
                case ThemeType.GRAY:
                    SetRedTheme(themeState);
                    break;
                case ThemeType.RED:
                    SetBlueTheme(themeState);
                    break;
                default:
                    break;
            }
            DisplayGames();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            undoRedo.Redo();
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            undoRedo.Undo();
        }
    }
}
