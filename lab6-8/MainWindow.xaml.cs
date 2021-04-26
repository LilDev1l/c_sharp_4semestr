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
using ProgramStore.DataWork;
using ProgramStore.Commands;
using System.Windows.Resources;

namespace ProgramStore
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Program> currentPrograms;
        private UndoRedoStack undoRedo;

        public MainWindow()
        {
            State state = State.GetState();
            InitializeComponent();
            currentPrograms = new List<Program>();
            state.Languege = Languege.EN;
            state.Theme = ThemeType.BLUE;
            undoRedo = new UndoRedoStack();
            DisplayPrograms();
        }

        private void CategorySort_All_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(()=> {
                DisplayPrograms();
            });
            undoRedo.AddAction(command);

            DisplayPrograms();
        }
        private void CategorySort_Utility_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayPrograms(Category.UTILITY);
            });
            undoRedo.AddAction(command);
            
            DisplayPrograms(Category.UTILITY);
        }
        private void CategorySort_Defender_Executed(object sender, ExecutedRoutedEventArgs e)
        {   
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayPrograms(Category.DEFENDER);
            });
            undoRedo.AddAction(command);
            
            DisplayPrograms(Category.DEFENDER);
        }
        private void CategorySort_Editor_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayPrograms(Category.EDITOR);
            });
            undoRedo.AddAction(command);
           
            DisplayPrograms(Category.EDITOR);
        }
        private void CategorySort_Web_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DisplayPrograms(Category.WEB);
            });
            undoRedo.AddAction(command);
            
            DisplayPrograms(Category.WEB);
        }

        public void DisplayPrograms(Category category = Category.ALL)
        {
            List<Program> programs = ProgramDataService.FindAll();

            currentPrograms.Clear();
            DataSectionStack.Children.Clear();

            if (category != Category.ALL)
            {
                foreach (var program in programs)
                {
                    if (program.Category == category)
                    {
                        ProgramCell programCell = new ProgramCell(program, this);
                        Grid viewProgramCell = programCell.BuildCell();
                        DataSectionStack.Children.Add(viewProgramCell);
                        currentPrograms.Add(program);
                    }
                }
            }
            else
            {
                foreach (var program in programs)
                {
                    ProgramCell programCell = new ProgramCell(program, this);
                    Grid viewProgramCell = programCell.BuildCell();
                    DataSectionStack.Children.Add(viewProgramCell);
                }
                currentPrograms = programs;
            }
        }

        private void Filters_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (ByNameButton.IsChecked == true)
            {
                UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                    SortByName();
                    PrintCurrentPrograms();
                });
                undoRedo.AddAction(command);
              
                SortByName();
                PrintCurrentPrograms();
                ByNameButton.IsChecked = false;
            }
            else if (ByPriceButton.IsChecked == true)
            {
                UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                    SortByPrice();
                    PrintCurrentPrograms();
                });
                undoRedo.AddAction(command);
              
                SortByPrice();
                PrintCurrentPrograms();
                ByPriceButton.IsChecked = false;
            }
            else 
            {
                MessageBox.Show("Please, choose type for filter...");
            }
        }
        private void SortByName()
        {
            currentPrograms.Sort((n, q) =>
            {
                if (n.Name.First() > q.Name.First())
                    return 1;
                else if (n.Name.First() < q.Name.First())
                    return -1;
                else return 0;
            });
        }
        private void SortByPrice()
        {
            currentPrograms.Sort((n, q) =>
            {
                if (n.Price > q.Price)
                    return 1;
                else if (n.Price < q.Price)
                    return -1;
                else return 0;
            });
        }
        private void PrintCurrentPrograms()
        {
            DataSectionStack.Children.Clear();
            foreach (var program in currentPrograms)
            {
                ProgramCell programCell = new ProgramCell(program, this);
                Grid viewProgramCell = programCell.BuildCell();
                DataSectionStack.Children.Add(viewProgramCell);
            }
        }

        private void Find_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string findName = FindBar.Text;

            DataSectionStack.Children.Clear();
            currentPrograms.Clear();
            currentPrograms = ProgramDataService.FindByName(findName);

            if (currentPrograms != null && currentPrograms.Count > 0)
            {
                PrintCurrentPrograms();
            }

            UndoRedoStack.Command command = new UndoRedoStack.Command(() => {
                DataSectionStack.Children.Clear();
                currentPrograms.Clear();
                currentPrograms = ProgramDataService.FindByName(findName);

                if (currentPrograms != null && currentPrograms.Count > 0)
                {
                    PrintCurrentPrograms();
                }
            });
            undoRedo.AddAction(command);
            
        }
        private void AddProgram_Executed(object sender, ExecutedRoutedEventArgs e)
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
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Language/RULocal.xaml", UriKind.Relative)};

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllPrograms.Text = (string)this.TryFindResource("AllProgramsCategory");
            Utility.Text = (string)this.TryFindResource("UtilityProgramCategory");
            Editor.Text = (string)this.TryFindResource("EditorProgramCategory");
            Defender.Text = (string)this.TryFindResource("DefenderProgramCategory");
            Web.Text = (string)this.TryFindResource("WEBProgramCategory");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }
        private void SetEnLocal(State langState)
        {
            langState.Languege = Languege.EN;
            LangButton.Text = "EN";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Language/ENLocal.xaml", UriKind.Relative) };

            TableTitleText.Text = (string)this.TryFindResource("TableTitle");

            AllPrograms.Text = (string)this.TryFindResource("AllProgramsCategory");
            Utility.Text = (string)this.TryFindResource("UtilityProgramCategory");
            Editor.Text = (string)this.TryFindResource("EditorProgramCategory");
            Defender.Text = (string)this.TryFindResource("DefenderProgramCategory");
            Web.Text = (string)this.TryFindResource("WEBProgramCategory");

            FilterPlaceTitle.Text = (string)this.TryFindResource("FilterTitle");
            ByName.Text = (string)this.TryFindResource("FilterByName");
            ByPrice.Text = (string)this.TryFindResource("FilterByPrice");
            GroupButtonText.Text = (string)this.TryFindResource("CommandToFilter");
        }

        private void SetBlueTheme(State themeState)
        {
            themeState.Theme = ThemeType.BLUE;
            ThemeButtonText.Text = "BL";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Recourses/BlueThems.xaml", UriKind.Relative) };

            BaseFrame.Style = (Style)this.TryFindResource("BackColor");
            Title.Style = (Style)this.TryFindResource("TitleLineColor");
            LogoPlace.Style = (Style)this.TryFindResource("TitleLineColor");
            FindPlace.Style  = (Style)this.TryFindResource("TitleLineColor");

            FilterPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            DataPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            MenuPlace.Style  = (Style)this.TryFindResource("MainViewsColor");

            AllButton.Style = (Style)this.TryFindResource("ButtonStyle");
            UtilityButton.Style = (Style)this.TryFindResource("ButtonStyle");
            EditorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            DefenderButton.Style = (Style)this.TryFindResource("ButtonStyle");
            WebButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("TitleLineColor");
            LangButton.Style = (Style)this.TryFindResource("TitleLineColor");
            ThemeButton.Style = (Style)this.TryFindResource("TitleLineColor");

            GroupButton.Style  = (Style)this.TryFindResource("ButtonStyle");
            ByNameButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByPriceButton.Style = (Style)this.TryFindResource("ButtonStyle");
            
            AddGameButton.Style = (Style)this.TryFindResource("AddButtonTemplate");
        }
        private void SetGrayTheme(State themeState)
        {
            themeState.Theme = ThemeType.GRAY;
            ThemeButtonText.Text = "GR";
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Recourses/GrayThems.xaml", UriKind.Relative) };

            BaseFrame.Style = (Style)this.TryFindResource("BackColor");
            Title.Style = (Style)this.TryFindResource("TitleLineColor");
            LogoPlace.Style = (Style)this.TryFindResource("TitleLineColor");
            FindPlace.Style = (Style)this.TryFindResource("TitleLineColor");

            FilterPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            DataPlace.Style = (Style)this.TryFindResource("MainViewsColor");
            MenuPlace.Style = (Style)this.TryFindResource("MainViewsColor");

            AllButton.Style = (Style)this.TryFindResource("ButtonStyle");
            UtilityButton.Style = (Style)this.TryFindResource("ButtonStyle");
            EditorButton.Style = (Style)this.TryFindResource("ButtonStyle");
            DefenderButton.Style = (Style)this.TryFindResource("ButtonStyle");
            WebButton.Style = (Style)this.TryFindResource("ButtonStyle");
            LanguegeButton.Style = (Style)this.TryFindResource("TitleLineColor");
            LangButton.Style = (Style)this.TryFindResource("TitleLineColor");
            ThemeButton.Style = (Style)this.TryFindResource("TitleLineColor");

            GroupButton.Style = (Style)this.TryFindResource("ButtonStyle");
            ByNameButton.Style = (Style)this.TryFindResource("ButtonStyle");
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
                    SetBlueTheme(themeState);
                    break;
                default:
                    break;
            }
            DisplayPrograms();
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
