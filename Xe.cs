using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lqk_2022605650
{
    internal class Xe
    {
        private string soDk;
        private string hSX;
        private string nSX;
        public string SoDk{ set { soDk = value; } get { return soDk; } }
        public string HSX{ set { hSX = value; } get { return hSX; } }  
        public string NSX{ set { nSX = value; } get { return nSX; } }
        public Xe() { }
        public Xe(string sdk,string hsx, string nsx)
        {
            this.soDk = sdk;
            this.hSX = hsx; 
            this.nSX = nsx;
        }
        public override string? ToString()
        {
            return $"{soDk,-20} {hSX,-20} {nSX,-20}";
        }
    }
}
