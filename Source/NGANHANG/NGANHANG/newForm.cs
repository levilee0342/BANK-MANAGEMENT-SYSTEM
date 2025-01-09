using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGANHANG.View;

namespace NGANHANG
{
    static class newForm
    {
        public static frmNhanVien frmNhanVien = new frmNhanVien();
        public static frmLogin frmLogin;
        public static frmRegister frmRegister;
        public static frmTaiKhoan frmTaiKhoan;
        public static frmKH frmKH = new frmKH();
        public static Frpt_SaoKeGiaoDichCuaMotTaiKhoanTrongMotKhoanThoiGian frmReportSaoKe;
        public static Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian frmReportTaiKhoan = new Frpt_LietKeCacTaiKhoanMoTrongMotKhoanThoiGian();
        public static Frpt_Lietkekhachhangtheotungchinhanh frmReportLietKeKH = new Frpt_Lietkekhachhangtheotungchinhanh();
        public static frmTraCuuKhachHang frmTraCuuKH = new frmTraCuuKhachHang();
        public static frmMoTK frmMoTK = new frmMoTK();
    }
}
