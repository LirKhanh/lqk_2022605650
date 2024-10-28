using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;

namespace lqk_2022605650
{
    internal class Program
    {
        public static void Menu()
        {
            Console.WriteLine("=====================\n1.Nhap xe/xe tai: \n2.Hien thi danh sach:\n3.Sua thong tin xe\n4.Thoat chuong trinh\n=====================");
        }
        public static void Menu2()
        {
            Console.WriteLine("=====================\n1.Nhap xe:\n2.Nhap xe tai:\n=====================");
        }
        public static bool Trung(List<Xe> list, string s)
        {
            return list.Exists(x => x.SoDk == s);
        }
        static void Main(string[] args)
        {
            try {
                int n = -1;
                List<Xe> list = new List<Xe>();
                while (n != 4) {
                    Menu();
                    n = Convert.ToInt32(Console.ReadLine());
                    switch (n) {
                        case 1:
                            Menu2();
                            int choice = Convert.ToInt32(Console.ReadLine());
                            Console.Write("Nhập SDK: ");
                            string sdk = Console.ReadLine();

                            if (!Trung(list, sdk))
                            {
                                Console.Write("Nhập hãng sản xuất: ");
                                string hsx = Console.ReadLine();
                                Console.Write("Nhập năm sản xuất: ");
                                string nsx = Console.ReadLine();

                                if (choice == 1)
                                {
                                    Xe xe = new Xe(sdk, hsx, nsx);
                                    list.Add(xe);
                                }
                                else if (choice == 2)
                                {
                                    Console.Write("Nhập tải trọng: ");
                                    string trongTai = Console.ReadLine();
                                    XeTai xeTai = new XeTai(sdk, hsx, nsx, trongTai);
                                    list.Add(xeTai);
                                }
                                else
                                {
                                    Console.WriteLine("Lựa chọn không hợp lệ.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("SDK đã tồn tại.");
                            }
                            break;

                        case 2:
                            foreach (var item in list) {
                                if(item is Xe)
                                    Console.WriteLine((Xe)item);
                                else if (item is XeTai)
                                    Console.WriteLine((XeTai)item);
                            }
                            break;
                        case 3:
                            Console.Write("Nhập SDK xe cần sửa: ");
                            string sdk1 = Console.ReadLine();

                            if (Trung(list, sdk1)) 
                            {
                                for (int i = 0; i < list.Count; i++)
                                {
                                    if (list[i].SoDk.Equals(sdk1))
                                    {
                                        Console.Write("Nhập SDK mới: ");
                                        list[i].SoDk = Console.ReadLine();
                                        Console.Write("Nhập hãng sản xuất mới: ");
                                        list[i].HSX = Console.ReadLine();
                                        Console.Write("Nhập năm sản xuất mới: ");
                                        list[i].NSX = Console.ReadLine();

                                        if (list[i] is XeTai xeTai)
                                        {
                                            Console.Write("Nhập tải trọng mới: ");
                                            xeTai.TaiTrong = Console.ReadLine();
                                        }
                                    }
                                }
                                Console.WriteLine("Thông tin xe đã được cập nhật.");
                            }
                            else
                            {
                                Console.WriteLine("SDK không tồn tại trong danh sách.");
                            }
                            break;

                        case 4:
                            break;
                        case 5:
                            Console.Write("Nhập SDK của xe cần xóa: ");
                            string sdk2 = Console.ReadLine();

                            // Tìm xe theo SDK và xóa nếu tồn tại
                            Xe xeToRemove = list.Find(x => x.SoDk == sdk2);

                            if (xeToRemove != null)
                            {
                                list.Remove(xeToRemove);
                                Console.WriteLine("Xe đã được xóa khỏi danh sách.");
                            }
                            else
                            {
                                Console.WriteLine("Không tìm thấy xe với SDK đã nhập.");
                            }
                            break;
                        default:
                            Console.WriteLine("Lenh khong hop le");
                            break;
                    }
                }
            }
            catch(FormatException e) {
                Console.WriteLine($"{e.Message}");
            }
        }
    }
}
