using System;
using System.Text;
class Program
{
    // TODO 1: Viết hàm ChuyenDoiSo
    // - Tham số: string (chuỗi cần chuyển)
    // - Trả về: int (số nguyên)
    // - Mục đích: chuyển chuỗi sang số, xử lý lỗi
    // - Yêu cầu: Sử dụng try...catch bắt FormatException
    public static int ChuyenDoiSo(string chuoi)
    {
        try
        {
            int ketqua = int.Parse(chuoi);
            Console.WriteLine($"Chuyển đổi thành công: '{chuoi}' → {ketqua}");
            return ketqua;
        }
        catch (FormatException)
        {
            Console.WriteLine($"Lỗi: '{chuoi}' không phải là số nguyên hợp lệ!");
            return 0;  // Giá trị mặc định
        }
        catch (OverflowException)
        {
            Console.WriteLine($"Lỗi: '{chuoi}' quá lớn!");
            return 0;
        }
    }

    // TODO 2: Viết hàm ChiaHaiSo
    // - Tham số: int a, int b
    // - Trả về: int (kết quả chia)
    // - Mục đích: chia hai số an toàn
    // - Yêu cầu: Sử dụng try...catch bắt DivideByZeroException
    public static int ChiaHaiSo(int a, int b)
    {
        try
        {
            int ketqua = a / b;
            Console.WriteLine($"{a} / {b} = {ketqua}");
            return ketqua;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine($"Lỗi: Không được chia cho 0!");
            return 0;
        }
    }

    // TODO 3: Viết hàm TimSoTrongMang
    // - Tham số: int[] mang, int chIso
    // - Trả về: int (phần tử ở vị trí)
    // - Mục đích: truy cập mảng an toàn
    // - Yêu cầu: Bắt IndexOutOfRangeException
    public static int TimSoTrongMang(int[] mang, int chiSo)
    {
        try
        {
            int so = mang[chiSo];
            Console.WriteLine($"Phần tử tại vị trí {chiSo} = {so}");
            return so;
        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine($"Lỗi: Chỉ số {chiSo} ngoài phạm vi mảng!");
            return -1;
        }
    }


    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("=== Xử Lý Ngoại Lệ An Toàn ===\n");

        // --- TODO 4: Gọi hàm ChuyenDoiSo với các chuỗi khác nhau ---
        Console.WriteLine("--- 1. Kiểm tra ChuyenDoiSo ---");
        ChuyenDoiSo("123");     // Thành công
        ChuyenDoiSo("abc");     // Lỗi
        ChuyenDoiSo("45.67");   // Lỗi
        Console.WriteLine();

        // --- TODO 5: Gọi hàm ChiaHaiSo ---
        Console.WriteLine("--- 2. Kiểm tra ChiaHaiSo ---");
        ChiaHaiSo(10, 2);   // Thành công
        ChiaHaiSo(10, 0);   // Lỗi
        ChiaHaiSo(-5, 3);   // Thành công
        Console.WriteLine();

        // --- TODO 6: Gọi hàm TimSoTrongMang ---
        Console.WriteLine("--- 3. Kiểm tra TimSoTrongMang ---");
        int[] arr = { 10, 20, 30, 40, 50 };
        Console.WriteLine($"Mảng: {{{string.Join(", ", arr)}}}");

        TimSoTrongMang(arr, 2);  // Chỉ số hợp lệ (giá trị 30)
        TimSoTrongMang(arr, 5);  // Chỉ số ngoài phạm vi (Lỗi)
        TimSoTrongMang(arr, -1); // Chỉ số ngoài phạm vi (Lỗi)
        Console.WriteLine();


        // --- TODO 7: (Nâng cao) Viết try...catch...finally ---
        Console.WriteLine("--- 4. Kiểm tra try...catch...finally ---");
        try
        {
            Console.WriteLine("Mở file...");
            // string content = File.ReadAllText("file.txt"); // Dòng này thường gây lỗi nếu file không tồn tại

            // Giả lập ngoại lệ FileNotFoundException để kiểm tra khối catch
            throw new System.IO.FileNotFoundException("File không tìm thấy!");
        }
        catch (System.IO.FileNotFoundException ex)
        {
            Console.WriteLine($"Lỗi: {ex.Message}");
        }
        finally
        {
            // Khối finally LUÔN ĐƯỢC THỰC THI, dù khối try có thành công hay gặp lỗi.
            Console.WriteLine("Đóng file và dọn dẹp tài nguyên.");
        }
    }
}