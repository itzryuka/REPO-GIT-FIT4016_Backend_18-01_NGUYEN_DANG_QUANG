using System;
using System.Text;
// TODO 1: Định nghĩa Lớp SinhVien 
class SinhVien
{
    // TODO 2: Khai báo các properties (thuộc tính) 
    public string HoTen { get; set; }
    public int Tuoi { get; set; }
    public double Diem { get; set; }

    // TODO 3: Viết Constructor (hàm khởi tạo) 
    // Hàm này được gọi khi tạo một đối tượng SinhVien mới 
    // Constructor có tên giống hệt tên lớp 
    public SinhVien(string hoTen, int tuoi, double diem)
    {
        this.HoTen = hoTen;
        this.Tuoi = tuoi;
        this.Diem = diem;
    }

    // TODO 4: Viết Method XepLoai() để trả về xếp loại 
    public string XepLoai()
    {
        // (Viết code của bạn tại đây) 
        // Tiêu chí xếp loại giống như PHT trước
        if (this.Diem >= 8.5)
        {
            return "Giỏi";
        }
        else if (this.Diem >= 7.0)
        {
            return "Khá";
        }
        else if (this.Diem >= 5.5)
        {
            return "Trung bình";
        }
        else
        {
            return "Yếu";
        }
    }

    // TODO 5: Viết Method HienThiThongTin() để in thông tin sinh viên 
    public void HienThiThongTin()
    {
        // Thay thế this.Diem bằng Diem và gọi XepLoai()
        Console.WriteLine("{0,-20} {1,-10} {2,-10:F1} {3,-10}",
                                  HoTen,
                                  Tuoi,
                                  Diem,
                                  XepLoai());
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Quản lý Sinh viên (Sử dụng OOP) ===\n");
        Console.OutputEncoding = Encoding.UTF8;
        // TODO 6: Tạo các đối tượng SinhVien 
        SinhVien sv1 = new SinhVien("Nguyễn Văn A", 20, 8.5);
        SinhVien sv2 = new SinhVien("Trần Thị B", 21, 7.2);
        SinhVien sv3 = new SinhVien("Lê Văn C", 19, 5.8);

        Console.WriteLine("{0,-20} {1,-10} {2,-10} {3,-10}", "Họ và Tên", "Tuổi", "Điểm", "Xếp Loại");
        Console.WriteLine("-------------------------------------------------------");

        // TODO 7: Gọi method HienThiThongTin() để in thông tin 
        sv1.HienThiThongTin();
        sv2.HienThiThongTin();
        sv3.HienThiThongTin();

        // TODO 8: (Tùy chọn) Tính trung bình điểm của 3 sinh viên 
        double diemTB = (sv1.Diem + sv2.Diem + sv3.Diem) / 3;

        Console.WriteLine($"\nĐiểm trung bình lớp: {diemTB:F2}");
    }
}
