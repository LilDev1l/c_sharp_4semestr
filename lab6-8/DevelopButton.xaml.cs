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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProgramStore
{
    /// <summary>
    /// Логика взаимодействия для DevelopButton.xaml
    /// </summary>
    public partial class DevelopButton : UserControl
    {
        public DevelopButton()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Developer: Sergei Valko, Version:1.1.1");
        }
    }
}
