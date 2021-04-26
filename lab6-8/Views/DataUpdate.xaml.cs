using ProgramStore.DataWork;
using Microsoft.Win32;
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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProgramStore
{
    /// <summary>
    /// Логика взаимодействия для DataUpdate.xaml
    /// </summary>
    public partial class DataUpdate : Window
    {
        MainWindow main;
        public string Path { get; set; } = "";

        public DataUpdate(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
            FieldsInit();
        }

        private void FieldsInit()
        {
            State langState = State.GetState();
            switch (langState.Languege)
            {
                case Languege.EN:
                    SetEnLocal(langState);
                    break;
                case Languege.RU:
                    SetRuLocal(langState);
                    break;
                default:
                    break;
            }
        }
        private void SetRuLocal(State langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Language/RULocal.xaml", UriKind.Relative) };

            NameLabel.Text = (string)this.TryFindResource("DataUpdateName");
            CategoryLabel.Text = (string)this.TryFindResource("DataUpdateCategory");
            ImageLabel.Text = (string)this.TryFindResource("DataUpdateImage");
            PriceLabel.Text = (string)this.TryFindResource("DataUpdatePrice");
            DescriptionLabel.Text = (string)this.TryFindResource("DataUpdateDescription");
            ExitButton.Content = (string)this.TryFindResource("DataUpdateExitButton");
            EnterButton.Content = (string)this.TryFindResource("DataUpdateEnterButton");
            ImageButton.Content = (string)this.TryFindResource("DataUpdateImageButton");

        }
        private void SetEnLocal(State langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Language/ENLocal.xaml", UriKind.Relative) };

            NameLabel.Text = (string)this.TryFindResource("DataUpdateName");
            CategoryLabel.Text = (string)this.TryFindResource("DataUpdateCategory");
            ImageLabel.Text = (string)this.TryFindResource("DataUpdateImage");
            PriceLabel.Text = (string)this.TryFindResource("DataUpdatePrice");
            DescriptionLabel.Text = (string)this.TryFindResource("DataUpdateDescription");
            ExitButton.Content = (string)this.TryFindResource("DataUpdateExitButton");
            EnterButton.Content = (string)this.TryFindResource("DataUpdateEnterButton");
            ImageButton.Content = (string)this.TryFindResource("DataUpdateImageButton");
        }

        private void Number_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !(Char.IsDigit(e.Text, 0));
        }
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                Path = openFileDialog.FileName;
            }
        }
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                ProgramDataService.AddProgram(CreateProgram());
                this.Close();
            }
            else
            {
                MessageBox.Show("Please write all fields ...");
            }
            main.DisplayPrograms();
        }
        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (IsValid())
            {
                ProgramDataService.AddProgram(CreateProgram());
                this.Close();
            }
            else
            {
                MessageBox.Show("Please write all fields ...");
            }
            main.DisplayPrograms();
        }
        private Program CreateProgram()
        {
            Program program = new Program();
            program.Name = Name.Text;
            program.Image = Path;
            program.Category = StringToCategory(Category.Text);
            program.Price = Convert.ToInt32(Price.Text);
            program.Description = Description.Text;
            return program;
        }
        private bool IsValid()
        {
            return Name.Text.Length > 0  && Category.SelectedItem != null && Path.Length > 0 && Price.Text.Length > 0;
        }
        private Category StringToCategory(string category)
        {
            switch (category)
            {
                case "utility": return ProgramStore.Category.UTILITY;
                case "defender": return ProgramStore.Category.DEFENDER;
                case "editor": return ProgramStore.Category.EDITOR;
                case "web": return ProgramStore.Category.WEB;
                default:
                    return ProgramStore.Category.ALL;
            }
        }
    }
}
