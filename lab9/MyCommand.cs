using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace lab9
{
    class MyCommand
    { 
        private static RoutedUICommand requery;

        static MyCommand()
        {
            InputGestureCollection inputs = new InputGestureCollection();
            inputs.Add(new KeyGesture(Key.R, ModifierKeys.Control, "Ctrl + R"));
            requery = new RoutedUICommand("Requery", "Requery", typeof(MyCommand), inputs);
        }

        public static RoutedUICommand Requery
        {
            get { return requery; }
        }
    }
}
