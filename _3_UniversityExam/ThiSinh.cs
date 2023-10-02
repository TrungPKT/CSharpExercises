using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UniversityExam
{
    abstract class ThiSinh
    {
        public int? SoBaoDanh { get; set; }
        public string Ten { get; set; }
        public string DiaChi { get; set; }
        public int? MucUuTien { get; set; }
        public ThiSinh()
        {
            SoBaoDanh = null;
            Ten = string.Empty;
            DiaChi = string.Empty;
            MucUuTien = null;
        }
        public ThiSinh(int? soBaoDanh, string ten, string diaChi, int? mucUuTien)
        {
            SoBaoDanh = soBaoDanh;
            Ten = ten;
            DiaChi = diaChi;
            MucUuTien = mucUuTien;
        }
    }
}
