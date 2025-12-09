using System;
using System.Text;
class Program

{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.WriteLine("=== Chương trình Xếp loại Sinh viên ===\n");
        // TODO 1: Khai báo biến thông tin sinh viên 
        // string hoVaTen = "Nguyễn Văn A"; (Thay bằng tên của bạn) 
        // double diem = 7.5; (Thay bằng điểm của bạn) 
        String hoVaTen = "Nguyễn Đăng Quang";
        double diem = 8.0;
        // TODO 2: In ra thông tin sinh viên 
        // Console.WriteLine($"Họ tên: {hoVaTen}"); 
        // Console.WriteLine($"Điểm: {diem}\n"); 
        Console.WriteLine($"Họ tên: {hoVaTen}");
        Console.WriteLine($"Điểm: {diem}\n");
        // TODO 3: Viết cấu trúc if/else if/else để xếp loại 
        // Tiêu chí: 
        // - Nếu điểm >= 8.5 => "Giỏi" 
        // - Nếu điểm >= 7.0 => "Khá" 
        // - Nếu điểm >= 5.5 => "Trung bình" 
        // - Nếu điểm < 5.5 => "Yếu" 
        if (diem >= 8.5)
        {
            Console.WriteLine("Xếp loại: Giỏi");
        }
        else if (diem >= 7.0)
        {
            Console.WriteLine("Xếp loại: Khá");
        }
        else if (diem >= 5.5)
        {
            Console.WriteLine("Xếp loại: Trung bình");
        }
        else
        {
            Console.WriteLine("Xếp loại: Yếu");
        }

        string[] tenSV = { "Nguyễn Văn A", "Trần Thị B", "Lê Văn C" };
        double[] diemSV = { 8.5, 7.2, 5.8 };

        Console.WriteLine("\n=== BẢNG ĐIỂM SINH VIÊN ===");

        // TODO 4: Viết vòng lặp for để in ra bảng điểm của 3 sinh viên 
        // Vòng lặp duyệt qua các phần tử của mảng, từ index 0 đến (chiều dài mảng - 1)
        for (int i = 0; i < tenSV.Length; i++)
        {
            // Lấy điểm của sinh viên hiện tại
            double diemTB = diemSV[i];
            string xepLoai;

            // TODO 5: In ra tên, điểm và xếp loại của từng sinh viên 
            // Cấu trúc IF/ELSE để xếp loại
            if (diemTB >= 8.0)
            {
                xepLoai = "Giỏi";
            }
            else if (diemTB >= 6.5)
            {
                xepLoai = "Khá";
            }
            else if (diemTB >= 5.0)
            {
                xepLoai = "Trung bình";
            }
            else
            {
                xepLoai = "Yếu";
            }

            // In thông tin ra Console
            Console.WriteLine($"SV: {tenSV[i],-15} | Điểm: {diemTB:F1} | Xếp loại: {xepLoai}");   
        }

        // TODO 6: (Tùy chọn) Dùng while loop để tính tổng điểm 

        // Gợi ý: Duyệt mảng diemSV và cộng tất cả lại 

        double tongDiem = 0;

        int j = 0;

        while (j < diemSV.Length)
        {
            // Cộng điểm của sinh viên thứ 'j' vào tongDiem
            tongDiem += diemSV[j];

            // Tăng biến đếm để chuyển sang sinh viên tiếp theo
            j++;
        }


        Console.WriteLine($"\nTổng điểm: {tongDiem}");
        Console.WriteLine($"Điểm trung bình: {tongDiem / diemSV.Length:F2}");

    }

}
