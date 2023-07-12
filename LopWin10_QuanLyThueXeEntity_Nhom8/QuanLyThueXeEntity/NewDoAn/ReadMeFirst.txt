Tạo 1 database mới trước, 
thứ tự là:

SuaDoAnEntityModel
SuaDoAnEntityDFContext
SuaDoAnEntityDFModel

vì lần này có sự thay đổi thêm chức năng của cô, nhưng vì làm theo linq hơi khó nên phần đó dùng lại sql như phần ADO.Net nên sẽ có connectionString
vì thế copy và chỉnh sửa connectionString như ADO.Net

nếu đặt tên database khác thì nhớ chỉnh đối tượng db theo đúng tên, vì nó dùng để truy vấn, khác với SQL dùng connectionString

các account Nhân viên (tk - mk) là:

- Quản Lý: sa - 1
- Nhân viên: em1 - 1	|	em2 - 2	|	em3 - 3

các account khách hàng (tk - mk) là:
ntd - 1	|	Thông tin: Nguyễn Trọng Dũng (họ tên) - 123123123 (CMND) - 456456456 (SĐT) - Quảng Ngãi (Địa Chỉ)

Các chức năng còn lại đọc trong file .doc BaoCao