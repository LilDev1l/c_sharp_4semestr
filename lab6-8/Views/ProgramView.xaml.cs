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
    /// Логика взаимодействия для ProgramView.xaml
    /// </summary>
    public partial class ProgramView : Window
    {
        public ProgramView()
        {
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

            ProgramName.Text = (string)this.TryFindResource("GameViewName");
        }
        private void SetEnLocal(State langState)
        {
            this.Resources = new ResourceDictionary() { Source = new Uri(@"/ProgramStore;component/Language/ENLocal.xaml", UriKind.Relative) };

            ProgramName.Text = (string)this.TryFindResource("GameViewName");
        }
    }
}
