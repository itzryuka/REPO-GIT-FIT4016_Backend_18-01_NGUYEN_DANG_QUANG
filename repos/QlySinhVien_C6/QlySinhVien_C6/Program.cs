using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    // Cần khai báo các Collection ở cấp độ lớp hoặc truyền qua tham số.
    // Dựa trên yêu cầu của bạn, tôi sẽ định nghĩa các hàm nhận Collection làm tham số.

    // TODO 4: Viết hàm ThemSinhVien
    public static void ThemSinhVien(
        string ten,
        double diem,
        List<string> danhSachTen,
        Dictionary<string, double> bangDiem,
        Stack<string> lichSu)
    {
        // 1. Thêm vào List và Dictionary
        if (!bangDiem.ContainsKey(ten))
        {
            danhSachTen.Add(ten);
            bangDiem.Add(ten, diem);

            // 2. Ghi lịch sử
            lichSu.Push($"[Thêm] {ten} - Điểm: {diem}");
            Console.WriteLine($"Đã thêm sinh viên: {ten}");
        }
        else
        {
            Console.WriteLine($"Sinh viên {ten} đã tồn tại!");
        }
    }

    // TODO 5: Viết hàm XoaSinhVien
    public static void XoaSinhVien(
        string ten,
        List<string> danhSachTen,
        Dictionary<string, double> bangDiem,
        Stack<string> lichSu)
    {
        // Kiểm tra xem sinh viên có tồn tại không
        if (bangDiem.ContainsKey(ten))
        {
            // 1. Xoá từ List và Dictionary
            danhSachTen.Remove(ten); // Xoá khỏi List
            bangDiem.Remove(ten);    // Xoá khỏi Dictionary

            // 2. Ghi lịch sử
            lichSu.Push($"[Xoá] {ten}");
            Console.WriteLine($"Đã xoá sinh viên: {ten}");
        }
        else
        {
            Console.WriteLine($"Không tìm thấy sinh viên: {ten} để xoá.");
        }
    }

    // TODO 6: Viết hàm InDanhSach
    public static void InDanhSach(List<string> danhSachTen, Dictionary<string, double> bangDiem)
    {
        Console.WriteLine("\n--- Danh Sách Sinh Viên ---");
        if (danhSachTen.Count == 0)
        {
            Console.WriteLine("Danh sách rỗng.");
            return;
        }

        // Duyệt List và sử dụng Dictionary để lấy điểm tương ứng
        int stt = 1;
        foreach (string ten in danhSachTen)
        {
            // Sử dụng TryGetValue() an toàn hơn, mặc dù ContainsKey đã kiểm tra ở hàm ThemSinhVien
            double diem = bangDiem[ten]; // Lấy điểm từ Dictionary
            Console.WriteLine($"{stt++}. Tên: {ten,-15} | Điểm GPA: {diem:F2}");
        }
        Console.WriteLine("----------------------------------");
    }

    // TODO 7: Viết hàm TimSinhVienTheoTen
    // - Yêu cầu: Sử dụng Dictionary.TryGetValue()
    public static double TimSinhVienTheoTen(string tenCanTim, Dictionary<string, double> bangDiem)
    {
        double diem;
        if (bangDiem.TryGetValue(tenCanTim, out diem))
        {
            Console.WriteLine($"Đã tìm thấy {tenCanTim}. Điểm: {diem:F2}");
            return diem;
        }
        else
        {
            Console.WriteLine($"Không tìm thấy sinh viên: {tenCanTim}");
            return -1; // Trả về -1 nếu không tìm thấy
        }
    }

    // TODO 8: Viết hàm HienThiLichSu
    // - Yêu cầu: Stack.Pop() để lấy từ mới nhất
    public static void HienThiLichSu(Stack<string> lichSu)
    {
        Console.WriteLine("\n--- Lịch Sử Thao Tác (Từ mới nhất) ---");
        if (lichSu.Count == 0)
        {
            Console.WriteLine("Lịch sử rỗng.");
            return;
        }

        // Dùng Pop() để lấy và xoá phần tử ra khỏi Stack (Last-In, First-Out)
        while (lichSu.Count > 0)
        {
            string thaoTac = lichSu.Pop();
            Console.WriteLine(thaoTac);
        }
        Console.WriteLine("----------------------------------");
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Quản Lý Sinh Viên với Collections ===\n");

        // TODO 1, 2, 3: Khai báo Collections
        List<string> danhSachTen = new();
        Dictionary<string, double> bangDiem = new();
        Stack<string> lichSu = new();

        // TODO 9: Thêm 3 sinh viên
        ThemSinhVien("Nguyễn Văn A", 3.5, danhSachTen, bangDiem, lichSu);
        ThemSinhVien("Trần Thị B", 3.9, danhSachTen, bangDiem, lichSu);
        ThemSinhVien("Lê Văn C", 2.85, danhSachTen, bangDiem, lichSu);
        ThemSinhVien("Nguyễn Văn A", 3.0, danhSachTen, bangDiem, lichSu); // Thử thêm trùng

        // TODO 10: In danh sách
        InDanhSach(danhSachTen, bangDiem);

        // TODO 11: Tìm sinh viên
        TimSinhVienTheoTen("Trần Thị B", bangDiem);
        TimSinhVienTheoTen("Phạm D", bangDiem);

        // TODO 12: Xoá 1 sinh viên
        Console.WriteLine("\n--- Thao tác Xoá ---");
        XoaSinhVien("Lê Văn C", danhSachTen, bangDiem, lichSu);
        XoaSinhVien("Phạm D", danhSachTen, bangDiem, lichSu); // Thử xoá không tồn tại

        // TODO 13: In danh sách lại
        InDanhSach(danhSachTen, bangDiem);

        // TODO 14: Hiển thị lịch sử
        HienThiLichSu(lichSu);
    }
}