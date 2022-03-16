using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BarcodeScanner
{
    public class BarcodeData
    {
        public string value { get; private set; } = string.Empty;
        public string[] characters { get; private set; } = new string[0];
        public string[] blocks { get; private set; } = new string[0];

        public override string ToString()
        {
            return value;
        }
    }
}
