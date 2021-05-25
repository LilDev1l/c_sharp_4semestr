using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows;


namespace lab11
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int iterator = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Prev_OnClick(object sender, RoutedEventArgs e)
        {
            if (iterator <= 0)
            {
                iterator = DataTable.Items.Count - 1;
            }

            iterator--;
            DataTable.SelectedItem = DataTable.Items.GetItemAt(iterator);
        }
        private void Next_OnClick(object sender, RoutedEventArgs e)
        {
            if (iterator >= DataTable.Items.Count)
            {
                iterator = 0;
            }

            DataTable.SelectedItem = DataTable.Items.GetItemAt(iterator);
            iterator++;
        }
    }
}
