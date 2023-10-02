using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_UniversityExam
{
    internal class KhoiB : ThiSinh
    {
        //public const string Toan = "Toan";
        //public const string Hoa = "Hoa";
        //public const string Sinh = "Sinh";
        public KhoiB() : base()
        {
        }
        public KhoiB(int? soBaoDanh, string ten, string diaChi, int? mucUuTien) : base(soBaoDanh, ten, diaChi, mucUuTien)
        {
        }
        public override string ToString() { return $"so bao danh: {SoBaoDanh}, ten: {Ten}, dia chi: {DiaChi}, muc do uu tien: {MucUuTien}, Khoi B: Toan, Hoa, Sinh"; }
    }
}
