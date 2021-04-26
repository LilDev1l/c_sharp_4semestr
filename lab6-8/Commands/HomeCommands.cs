using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProgramStore.Commands
{
    class HomeCommands
    {
        static HomeCommands()
        {
            CategorySort = new RoutedCommand("CategorySort", typeof(MainWindow));
            Filter = new RoutedCommand("Filter", typeof(MainWindow));
            Find = new RoutedCommand("Find", typeof(MainWindow));
        }
        public static RoutedCommand CategorySort { get; set; }
        public static RoutedCommand Filter { get; set; }
        public static RoutedCommand Find { get; set; }
        
    }
}
