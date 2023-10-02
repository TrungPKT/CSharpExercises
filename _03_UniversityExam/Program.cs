namespace _3_UniversityExam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string state = "0";

            while (state != "-1")
            {
                switch (state)
                {
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Phan Mem Tuyen Sinh");
                        Console.WriteLine("Chon 1 tinh nang:");
                        Console.WriteLine("1. Them moi thi sinh");
                        Console.WriteLine("2. Hien thi thong tin cac thi sinh");
                        Console.WriteLine("3. Tim kiem theo so bao danh");
                        Console.WriteLine("4. Thoat khoi chuong trinh");

                        string? inputZero = Console.ReadLine();
                        if (inputZero != "1" && inputZero != "2" && inputZero != "3" && inputZero != "4")
                            goto case "0";
                        
                        state = inputZero;

                        break;
                    case "1":
                        Console.Clear();
                        TuyenSinh.ThemMoiThiSinh();

                        state = "0";

                        break;
                    case "2":
                        Console.Clear();
                        TuyenSinh.HienThiThongCacThiSinh();

                        state = "0";

                        break;
                    case "3":
                        Console.Clear();
                        TuyenSinh.TimKiemTheoSoBaoDanh();

                        state = "0";

                        break;
                    case "4":
                        state = "-1";

                        break;
                }
            }
        }
    }
}