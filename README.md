Full dựng và demo app qua video 6 phút link https://drive.google.com/file/d/1D8e0TcrgnQ2PQng0iPWV_tE14lojZzIv/view

I/ Công nghệ sử dụng
    Cả client và API đều được viết bằng C# .NET Core 6.
    
1/ Cấu trúc thư mục:
      - Thư mục API là Server side.
      - Thư mục DemoWinform là chạy client site bằng Winform application.
      - DB là file soxo.db đi kèm trong thư mục API. Khi API chạy dotnet run thì sẽ tự tạo ra file này. Đây là SQLite nên ko cần cài đặt. Khi chạy project thì tạo db theo code. Nếu có sự thay đổi như thêm hoặc sửa trong model thì chạy lại câu lệnh dotnet ef migrations add initialxxx (xxx là version name để phân biệt với các version trước).

2/ Web API:
      - Entity Framework
      - Code first approach (sử dụng code để tạo và update cơ sở dữ liệu, project khi tair veef ko cos file db, sau khi chayj thaays cos file db).
         
3/ Client Winform App
      - Fluent Validation

4/ Database
      - Sqlite. Ghi chú: project không phụ thuộc cơ sở dữ liệu do tất cả được tạo và thay đổi bằng code (không sử dụng trigger hay procedure). Vì vậy có thể dùng sqlite hay bất kỳ database nào.
      - Nếu cần, có thể xóa file soxo.db và khi api project chạy thì db file sẽ tự sinh ra lại.
   
II/ Hướng dẫn cài đặt:
  - Tải project về, giải nén.
  - Tải Visual Studio 2022
  - Tải SDK 6.0.417 https://dotnet.microsoft.com/en-us/download/dotnet/6.0
  - Mở project API trên Visual Studio, mở file launchSettings.json ở Properties, đổi applicationUrl thành "https://localhost:5001;http://localhost:5000"
   
III/ Tính năng
  - Mỗi lượt xố số được xác định bởi ngày và slot thời gian. Slot có giá trị từ 0->23 tương ứng 0->23h.
  - Note: app không sử dụng nhiều đến service interface vì logic app không phức tạp, không nhiều dòng code. Khi App lớn sẽ tách bớt logic qua Service. Và do không đủ thời gian nên cũng không kịp làm phần Unit Test. Và khi làm unit test sẽ cần interface để test.

    1/ Web API:
     - Schedule function chạy tự động đầu mỗi giờ để:
        - Tạo kết quả xổ số
        - Khởi tạo lottery slot mới để user có thể đặt
        - update kết quả xổ số cho user.
     - Trong trường hợp test, các scheduled function sẽ được chạy khi mới khởi động Application
     - Thời gian trả ra
     - Kết quả trả ra là Restful api

    2/ Winform:
     - Validate số điện thoại, fullname, pick number (số user chọn)

IV/ Tính năng
   Anh/chị vui lòng truy cập link sau để lấy postman và xem video demo https://drive.google.com/file/d/1D8e0TcrgnQ2PQng0iPWV_tE14lojZzIv/view

