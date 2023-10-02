using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UniversityExam
{
    internal class KhoiC : ThiSinh
    {
        //public const string Van = "Van";
        //public const string Su = "Su";
        //public const string Dia = "Dia";
        public KhoiC() : base()
        {
        }
        public KhoiC(int? soBaoDanh, string ten, string diaChi, int? mucUuTien) : base(soBaoDanh, ten, diaChi, mucUuTien)
        {
        }
        public override string ToString() { return $"so bao danh: {SoBaoDanh}, ten: {Ten}, dia chi: {DiaChi}, muc do uu tien: {MucUuTien}, Khoi B: Toan, Hoa, Sinh"; }
    }
}
