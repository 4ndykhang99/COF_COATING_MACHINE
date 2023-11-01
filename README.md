# COF_COATING_MACHINE
Included code, PCB, Software for COF &amp; Coating machine

## 11/2/2023
- Ghi nhận các lỗi:
    - Trôi công tắc hành trình trong chế độ COF.
    - Khi sử dụng COFcontroller.exe lưu đến mẫu 9 hoặc 10 sẽ bị lỗi ( chưa xác định), dữ liệu bị ngắn đi khi plot biểu đồ trên phần mềm, hoặc có thể do tốc độ của motor nhanh dần lên, càng đo về sau, biểu đồ plot lên càng ngắn.
    - Lỗi random: đo COF, bộ điều khiển trả về giá trị 0. Phần mềm lẫn board đọc về giá trị 0.
    - Idea về detect vị trí mỗi lần khởi động máy: khởi tạo một hàm scan_pos(), mỗi khi mất điện và bật hệ thống lại, hoặc mỗi lần reset, chương trình sẽ qua hàm scan_pos để nhận biết trạng thái của 2 công tắc hành trình như thế nào => giải quyết được vấn đề lưu vào bộ nhớ flash.
    - Sếp suggest biểu đồ tự động detect chiều cao và tự động scale vừa với cửa sổ biểu đồ.
