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

        public static Image SharedImg { get { return sharedImg; } set {sharedImg=value ; } }
        public static bool Durum { get {  return durum; } set { durum = value; } }
    }
}
