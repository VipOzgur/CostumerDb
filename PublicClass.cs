using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusteriData
{
    public class PublicClass
    {
        private static Image sharedImg;
        private static bool durum =false;
        private static int combobox1SelectedIndex=0;
        private static int comboboxKameralarSelectedIndex=0;

        public static Image SharedImg { get { return sharedImg; } set {sharedImg=value ; } }
        public static bool Durum { get {  return durum; } set { durum = value; } }
        public static int ComboBox1SelectedIndex { get { return combobox1SelectedIndex; } set { combobox1SelectedIndex = value; } }
        public static int ComboBoxKameralarSelectedIndex { get { return comboboxKameralarSelectedIndex; } set { comboboxKameralarSelectedIndex = value; } }
    }
}
