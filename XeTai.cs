using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lqk_2022605650
{
    internal class XeTai : Xe
    {
        private string taiTrong;
        public string TaiTrong { get { return taiTrong; } set { taiTrong = value; } }
        public XeTai(string sdk, string hsx, string nsx, string taitrong):base(sdk,hsx,nsx)
        {
            this.taiTrong = taitrong;
        }
        public int Phi()
        {
            if (Convert.ToInt32(taiTrong) < 8)
                return 1000000;
            else if (Convert.ToInt32(taiTrong) >= 13)
                return 2000000;
            else
                return 3000000;
        }
        public override string? ToString()
        {
            return base.ToString() +$"{taiTrong,-20} {Phi(),-20}";
        }
    }
}
