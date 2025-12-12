using System;
using System.Text;

class Program
{
    // TODO 1: Viết hàm XepLoai nhận vào điểm và trả về xếp loại (string) 
    // Hàm này sẽ thay thế phần if/else ở PHT trước 
    static string XepLoai(double diem)
    {

        if (diem >= 8.5)
        {
            return "Giỏi";
        }
        else if (diem >= 7.0)
        {
            return "Khá";
        }
        else if (diem >= 5.5)
        {
            return "Trung bình";
        }
        else
        {
            return "Yếu";
        }
    }
    // TODO 2: Viết hàm TinhTrungBinh nhận vào mảng điểm và trả về trung bình (double) 
    static double TinhTrungBinh(double[] diem)
    {

        if (diem == null || diem.Length == 0)
        {
            return 0.0;
        }

        double tongDiem = 0;
        foreach (double d in diem)
        {
            tongDiem += d;
        }

        return tongDiem / diem.Length;
    }

    // TODO 3: Viết hàm InBangDiem nhận vào 2 mảng (tên, điểm) 
    static void InBangDiem(string[] ten, double[] diem)
    {
        if (ten.Length != diem.Length)
        {
            Console.WriteLine("Lỗi: Số lượng tên và điểm không khớp.");
            return;
        }

        Console.WriteLine("{0,-20} {1,-10} {2,-10}", "Họ và Tên", "Điểm", "Xếp Loại");
        Console.WriteLine("---------------------------------------------");

        for (int i = 0; i < ten.Length; i++)
        {
            string xepLoai = XepLoai(diem[i]);
            Console.WriteLine("{0,-20} {1,-10:F1} {2,-10}", ten[i], diem[i], xepLoai);
        }
    }

    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        string[] tenSV = { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C" };
        double[] diemSV = { 8.5, 7.2, 5.8 };

        Console.WriteLine("=== Chương trình Quản lý Sinh viên ===\n");

        // TODO 4: Gọi hàm InBangDiem để in bảng điểm 
        InBangDiem(tenSV, diemSV);

        // TODO 5: Gọi hàm TinhTrungBinh và in kết quả 
        double trungBinh = TinhTrungBinh(diemSV);
        Console.WriteLine($"\nĐiểm trung bình lớp: {trungBinh:F2}");
    }
}