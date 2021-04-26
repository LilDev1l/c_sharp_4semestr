using ProgramStore.DataWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace ProgramStore
{
    class ProgramCell
    {
        private Program program;
        private readonly MainWindow mainWindow;

        public Program getProgram()
        {
            return program;
        }

        public ProgramCell(Program program, MainWindow mainWindow)
        {
            this.program = program;
            this.mainWindow = mainWindow;
        }

        public Grid BuildCell()
        {
            Grid grid = CreateGrid();
            grid.Children.Add(CreateImage());
            grid.Children.Add(CreateTextBlock());
            grid.Children.Add(CreateButtomPanel());
            return grid;
        }

        private Grid CreateGrid()
        {
            Grid grid = new Grid();
            List<byte> colors = GetCodeColorRGB();
            grid.Background = new SolidColorBrush(Color.FromRgb(colors.ElementAt(0), colors.ElementAt(1), colors.ElementAt(2)));
            grid.Margin = new Thickness(5);

            ColumnDefinition column1 = new ColumnDefinition();
            ColumnDefinition column2 = new ColumnDefinition();
            ColumnDefinition column3 = new ColumnDefinition();
            column1.Width = new GridLength(1, GridUnitType.Star);
            column2.Width = new GridLength(4, GridUnitType.Star);
            column3.Width = new GridLength(3, GridUnitType.Star);
            RowDefinition row = new RowDefinition();
            row.Height = new GridLength(45, GridUnitType.Pixel);

            grid.ColumnDefinitions.Add(column1);
            grid.ColumnDefinitions.Add(column2);
            grid.ColumnDefinitions.Add(column3);
            grid.RowDefinitions.Add(row);
            return grid;
        }
        private List<byte> GetCodeColorRGB()
        {
            List<byte> vs = new List<byte>();
            State state = State.GetState();
            switch (state.Theme)
            {
                case ThemeType.BLUE:
                    vs.Add(120);
                    vs.Add(151);
                    vs.Add(228);
                    break;
                case ThemeType.GRAY://#979BA4
                    vs.Add(151);
                    vs.Add(155);
                    vs.Add(164);
                    break;
                default:
                    break;
            }
            return vs;
        }

        private WrapPanel CreateButtomPanel()
        {
            WrapPanel wrapPanel = new WrapPanel();
            wrapPanel.Name = "ButtonPanel";
            wrapPanel.HorizontalAlignment = HorizontalAlignment.Right;
            Grid.SetColumn(wrapPanel, 2);
            wrapPanel.Children.Add(CreateViewButtom());
            wrapPanel.Children.Add(CreateUpdateButtom());
            wrapPanel.Children.Add(CreateDeleteButtom());
            return wrapPanel;
        }

        private Image CreateImage()
        {
            Image image = new Image();
            image.Margin = new Thickness(5);
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(program.Image, UriKind.Absolute) ;
            bi3.EndInit();
            image.Source = bi3;
            Grid.SetColumn(image, 0);
            Grid.SetRow(image, 0);
            return image;
        }

        private TextBlock CreateTextBlock()
        {
            TextBlock textBlock = new TextBlock();
            textBlock.Text = program.Name;
            textBlock.TextWrapping = TextWrapping.Wrap;
            textBlock.Margin = new Thickness(5, 2, 5, 2);
            Grid.SetColumn(textBlock, 1);
            Grid.SetRow(textBlock, 0);
            return textBlock;
        }

        private Button CreateViewButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            button.Command = Commands.ProgramCommand.View;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = Commands.ProgramCommand.View;
            commandBinding.Executed += ViewProgram_Executed;
            button.CommandBindings.Add(commandBinding);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/ProgramStore;component/images/eye.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private  Button CreateDeleteButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            button.Command = Commands.ProgramCommand.Delete;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = Commands.ProgramCommand.Delete;
            commandBinding.Executed += DeleteProgram_Executed;
            button.CommandBindings.Add(commandBinding);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/ProgramStore;component/images/cancel.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private  Button CreateUpdateButtom()
        {
            Button button = new Button();
            button.Template = CreateStyleForButton();
            button.Width = 35;
            button.Height = 35;
            button.VerticalAlignment = VerticalAlignment.Center;
            button.HorizontalAlignment = HorizontalAlignment.Right;
            button.Margin = new Thickness(3);
            button.Command = Commands.ProgramCommand.Update;
            CommandBinding commandBinding = new CommandBinding();
            commandBinding.Command = Commands.ProgramCommand.Update;
            commandBinding.Executed += UpdateProgram_Executed;
            button.CommandBindings.Add(commandBinding);

            Image image = new Image();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(@"/ProgramStore;component/images/repeat.png", UriKind.Relative);
            bi3.EndInit();
            image.Source = bi3;

            button.Content = image;

            return button;
        }

        private ControlTemplate CreateStyleForButton()
        {
            string controlTemplateBuf = "<ControlTemplate xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'" + $" TargetType=\"Button\">\n<Grid>\n<Ellipse Fill = \"{GetCodeColor()}\" ></Ellipse >\n" +
                             "<Label Content = \"{TemplateBinding Content}\" HorizontalAlignment = \"Center\" VerticalAlignment = \"Center\"></Label>\n" +
                        "</Grid ></ControlTemplate >";
            return (ControlTemplate)XamlReader.Parse(controlTemplateBuf);
        }

        private string GetCodeColor()
        {
            State state = State.GetState();
            switch (state.Theme)
            {
                case ThemeType.BLUE:
                    return "#427E8E";
                case ThemeType.GRAY:
                    return "#979BA4";
                default:
                    return null;
            }
        }

        public void ViewProgram_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ProgramView programView = new ProgramView();
            ProgramViewFieldInicalization(programView);
            programView.Show();
        }

        private void ProgramViewFieldInicalization(ProgramView programView)
        {
            programView.Owner = mainWindow;
            programView.DescriptionText.Text = program.Description;
            programView.ProgramName.Text = program.Name;
            programView.Price.Text = program.Price.ToString();
            BitmapImage bi3 = new BitmapImage();
            bi3.BeginInit();
            bi3.UriSource = new Uri(program.Image, UriKind.Absolute);
            bi3.EndInit();
            programView.ProgramImage.Source = bi3;
        }

        private string CategoryToString(Category category)
        {
            switch (category)
            {
                case Category.UTILITY: return "utility";
                case Category.DEFENDER: return "defender";
                case Category.EDITOR: return "editor";
                case Category.WEB: return "web";
                default:
                    return "";
            }
        }

        public void DeleteProgram_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ProgramDataService.RemoveProgram(program);
            mainWindow.DisplayPrograms();
        }
        
        public void UpdateProgram_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            DataUpdate dataUpdate = new DataUpdate(mainWindow);
            DataUpdateFieldInit(dataUpdate);
            ProgramDataService.RemoveProgram(program);
            dataUpdate.Show();
            mainWindow.DisplayPrograms();
        }

        private void DataUpdateFieldInit(DataUpdate dataUpdate)
        {
            dataUpdate.Owner = mainWindow;
            dataUpdate.Description.Text = program.Description;
            dataUpdate.Name.Text = program.Name;
            dataUpdate.Price.Text = program.Price.ToString();
            dataUpdate.Category.Text = CategoryToString(program.Category);
            dataUpdate.Path = program.Image;
        }
    }
}
