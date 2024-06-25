# Cơ sở dữ liệu phân tán 

## Ứng dụng Quản lý Hệ thống Ngân hàng

Ứng dụng này cung cấp các chức năng để quản lý hệ thống ngân hàng, bao gồm quản lý khách hàng và nhân viên, giao dịch tài khoản, liệt kê và thống kê, và quản trị. Ứng dụng được tổ chức thành nhiều phần chính, mỗi phần cung cấp các tính năng cụ thể.

## Tổng quan Menu

### A. Cập nhật

1. **Cập nhật Thông tin Khách hàng**
    - Chức năng thêm, sửa hoặc xóa thông tin khách hàng.
  
2. **Mở Tài khoản cho Khách hàng**
    - SubForm để tạo tài khoản mới cho khách hàng.

3. **Cập nhật Thông tin Nhân viên**
    - Thêm nhân viên mới.
    - Xóa nhân viên hiện có.
    - Chỉnh sửa chi tiết nhân viên.
    - Chuyển nhân viên qua chi nhánh khác.

4. **Cập nhật Giao dịch của Khách hàng**
    - Quản lý giao dịch gửi tiền.
    - Quản lý giao dịch rút tiền.
    - Quản lý giao dịch chuyển tiền.

### B. Liệt kê - Thống kê

1. **Sao kê Giao dịch của một Tài khoản trong một Khoảng thời gian (@tungay, @denngay)**
    - Ví dụ đầu ra:
    ```
    Số dư đến ngày @tungay - 1: 10.000.000

    Số dư đầu        Ngày        Loại giao dịch    Số tiền      Số dư sau
    10.000.000       1/3/22      GT                5.000.000     15.000.000
    15.000.000       7/3/22      CT                7.000.000     8.000.000

    Số dư tới ngày @denngay: 8.000.000
    ```

2. **Liệt kê các Tài khoản mở trong một Khoảng thời gian của Chi nhánh, của tất cả các Chi nhánh**
    - Liệt kê tài khoản dựa trên khoảng thời gian và tiêu chí chi nhánh được chỉ định.

3. **Liệt kê các Khách hàng theo từng Chi nhánh**
    - Liệt kê khách hàng theo chi nhánh.
    - Sắp xếp khách hàng trong từng chi nhánh theo thứ tự tăng dần của tên.

### C. Quản trị

1. **Nhóm Người dùng: NganHang, ChiNhanh, KhachHang**

    - **Nhóm NganHang:**
        - Có thể chọn bất kỳ chi nhánh nào để xem báo cáo bằng cách chọn tên chi nhánh và tìm dữ liệu trên phân mảnh tương ứng.
        - Người dùng trong nhóm này có thể tạo tài khoản mới cùng nhóm.

    - **Nhóm ChiNhanh:**
        - Có toàn quyền làm việc trên chi nhánh đã đăng nhập.
        - Người dùng trong nhóm này có thể tạo tài khoản mới cùng nhóm.

    - **Nhóm KhachHang:**
        - Chỉ có thể xem sao kê tài khoản của chính mình.
        - Người dùng trong nhóm này không được phép tạo tài khoản mới.

## Sử dụng

Để bắt đầu sử dụng ứng dụng, thực hiện các bước sau:

1. **Đăng nhập**: Tùy theo nhóm người dùng, truy cập các chức năng tương ứng như mô tả trong phần Quản trị.
2. **Điều hướng**: Sử dụng menu để điều hướng qua các tính năng khác nhau như cập nhật thông tin khách hàng hoặc nhân viên, quản lý giao dịch, liệt kê và tạo thống kê.
3. **Hoạt động Form**: Sử dụng các chức năng của form để thêm, xóa, phục hồi, ghi, hoặc thoát.

---


