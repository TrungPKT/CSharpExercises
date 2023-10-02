using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UniversityExam
{
    class TuyenSinh
    {
        private static List<ThiSinh> _cacThiSinh = new List<ThiSinh>();
        public static void ThemMoiThiSinh()
        {
            bool loiTrungSoBaoDanh = false;
        NhapKhoiThi:
            Console.Clear();
            Console.WriteLine("Chon khoi thi:");
            Console.WriteLine("1. Khoi A");
            Console.WriteLine("2. Khoi B");
            Console.WriteLine("3. Khoi C");

            if (loiTrungSoBaoDanh)
                Console.WriteLine("Trung so bao danh!");

            string nhapKhoiThi = Console.ReadLine();
            if (nhapKhoiThi != "1" && nhapKhoiThi != "2" && nhapKhoiThi != "3")
                goto NhapKhoiThi;

        NhapSoBaoDanh:
            Console.Clear();
            Console.WriteLine("Nhap so bao danh:");
            bool isSoBaoDanh = Int32.TryParse(Console.ReadLine(), out int soBaoDanh);
            if (!isSoBaoDanh)
                goto NhapSoBaoDanh;
            var trungSoBaoDanh = _cacThiSinh.FirstOrDefault(thiSinh => thiSinh.SoBaoDanh == soBaoDanh);
            if (trungSoBaoDanh != null)
            {
                loiTrungSoBaoDanh = true;
                goto NhapSoBaoDanh;
            }


            Console.WriteLine("Nhap ten:");
            string? ten = Console.ReadLine();

            Console.WriteLine("Nhap dia chi:");
            string? diaChi = Console.ReadLine();

        NhapMucUuTien:
            Console.WriteLine("Nhap muc uu tien:");
            bool isMucUuTien = Int32.TryParse(Console.ReadLine(), out int mucUuTien);
            if (!isMucUuTien)
                goto NhapMucUuTien;

            switch (nhapKhoiThi)
            {
                case "1":
                    var thiSinhKhoiA = new KhoiA(soBaoDanh, ten, diaChi, mucUuTien);
                    _cacThiSinh.Add(thiSinhKhoiA);
                    Console.WriteLine("Da them thi sinh: " + thiSinhKhoiA.ToString());
                    Console.ReadLine();

                    break;
                case "2":
                    var thiSinhKhoiB = new KhoiB(soBaoDanh, ten, diaChi, mucUuTien);
                    _cacThiSinh.Add(thiSinhKhoiB);
                    Console.WriteLine("Da them thi sinh: " + thiSinhKhoiB.ToString());
                    Console.ReadLine();

                    break;
                case "3":
                    var thiSinhKhoiC = new KhoiC(soBaoDanh, ten, diaChi, mucUuTien);
                    _cacThiSinh.Add(thiSinhKhoiC);
                    Console.WriteLine("Da them thi sinh: " + thiSinhKhoiC.ToString());
                    Console.ReadLine();

                    break;
            }
        }
        public static void HienThiThongCacThiSinh()
        {
            foreach (ThiSinh thiSinh in _cacThiSinh) { Console.WriteLine(thiSinh.ToString()); }
            Console.ReadLine();
        }
        public static void TimKiemTheoSoBaoDanh()
        {
        NhapSoBaoDanh:
            Console.WriteLine("Nhap so bao danh:");
            bool isSoBaoDanh = Int32.TryParse(Console.ReadLine(), out int soBaoDanh);
            if (!isSoBaoDanh)
                goto NhapSoBaoDanh;

            var thiSinh = _cacThiSinh.FirstOrDefault(thiSinh => thiSinh.SoBaoDanh == soBaoDanh);

            if (thiSinh == null)
            {
                Console.WriteLine("Khong tim thay thi sinh");
                Console.ReadLine();
                return;
            }

            Console.WriteLine(thiSinh.ToString());
            Console.ReadLine();
        }
    }
}
