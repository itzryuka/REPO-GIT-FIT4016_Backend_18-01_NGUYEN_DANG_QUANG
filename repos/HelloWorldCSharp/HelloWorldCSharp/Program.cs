using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        Console.WriteLine("Chào mừng đến với C#!");
        string ten = "Nguyễn Văn A";  // Chuỗi ký tự 
        int tuoi = 20;                 // Số nguyên 
        double diem = 8.5;             // Số thực 
        Console.WriteLine("Tên: " + ten);
        Console.WriteLine("Tuổi: " + tuoi);
        Console.WriteLine("Điểm: " + diem);
        Console.WriteLine($"Thông tin: {ten}, tuổi {tuoi}, điểm {diem}");
    }

}
