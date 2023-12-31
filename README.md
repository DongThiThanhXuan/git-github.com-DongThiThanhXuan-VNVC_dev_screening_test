I/ Project Viết bằng C# .NET Core 6.
  1/ Cấu trúc bài làm: 2 thư mục
  - Thư mục API là Server side
  - Thư mục DemoWinform là chạy client site bằng Winform application
  2/ DB là SQLite đi kèm trong thư mục API ( SQLite nhẹ và ko cần cài đặt).
II/ Hướng dẫn cài đặt và chạy:
  - Tải project về, giải nén.
  - Tải Visual Studio 2022
  - Tải SDK 6.0.417 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
  - Mở project API trên Visual Studio, mở file launchSettings.json ở Properties, đổi applicationUrl thành "https://localhost:5001;http://localhost:5000"
III/ Công nghệ sử dụng
    1/ Web API:
      - Entity framework
      - SQLite
    2/ Winform App
      - Fluent Validation
      - 
IV/ Tính năng
    1/ Web API:
  - Có Schedule function chạy tự động đầu mỗi giờ để tạo kết quả xổ số, khởi tạo lottery slot mới để user có thể đặt, update kết quả xổ số cho user.
  - Slot từ 0h->23 tương ứng 0h->23h,
  - 
   

