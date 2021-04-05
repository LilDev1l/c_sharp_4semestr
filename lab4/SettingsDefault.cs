using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_Lab02
{
    class SettingsDefault
    {
        private SettingsDefault() { }

        private static SettingsDefault instance;
        public Font Font { get; } = new Font(FontFamily.GenericSansSerif, 7.8f, FontStyle.Regular);
        public Color Color { get; } = Color.Black;

        public static SettingsDefault getInstance()
        {
            if (instance == null)
                instance = new SettingsDefault();
            return instance;
        }
    }
}
