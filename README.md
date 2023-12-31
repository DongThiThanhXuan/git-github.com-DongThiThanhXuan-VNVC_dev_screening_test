I/ Công nghệ sử dụng
   - Cả client và API đều được viết bằng C# .NET Core 6.

    1/ Cấu trúc thư mục:
      - Thư mục API là Server side.
      - Thư mục DemoWinform là chạy client site bằng Winform application.
      - DB là SQLite đi kèm trong thư mục API: SQLite nhẹ và ko cần cài đặt. Khi chạy project thì tạo db theo code. Nếu có sự thay đổi như thêm hoặc sửa trong model thì chạy lại câu lệnh dotnet ef migrations add initialxxx (xxx là version name để phân biệt với các version trước).

    2/ Web API:
      - Entity Framework
      - Code first approach (sử dụng code để tạo và update cơ sở dữ liệu).
      - SQLite hoặc bất kỳ cơ sở dữ liệu nào. Không phụ thuộc cơ sở dữ liệu do tất cả được tạo và thay đổi bằng code (không sử dụng trigger hay procedure).
      
    3/ Client Winform App
      - Fluent Validation
      - 
   
II/ Hướng dẫn cài đặt:
  - Tải project về, giải nén.
  - Tải Visual Studio 2022
  - Tải SDK 6.0.417 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
  - Mở project API trên Visual Studio, mở file launchSettings.json ở Properties, đổi applicationUrl thành "https://localhost:5001;http://localhost:5000"


III/ Tính năng
- Mỗi lượt xố số được xác định bởi ngày và slot thời gian. Slot có giá trị từ 0->23 tương ứng 0->23h.
    1/ Web API:
     - Schedule function chạy tự động đầu mỗi giờ để:
        - Tạo kết quả xổ số
        - Khởi tạo lottery slot mới để user có thể đặt
        - update kết quả xổ số cho user.
     - Trong trường hợp test, các scheduled function sẽ được chạy khi mới khởi động Application
    
   

