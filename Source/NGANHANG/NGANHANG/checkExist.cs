﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGANHANG
{
    static class checkExist
    {
        public static bool checkFormNhanVien = false;
        public static bool checkFormTaiKhoan = false;
        public static bool checkFormKH = false;
        public static bool checkFormLogin = false;
        public static bool checkFormRegister = false;
        public static bool checkReportSaoKe = false;
        public static bool checkReportTaiKhoan = false;
        public static bool checkFormTraCuuKH = false;
        public static bool checkReportKH = false;

        public static void logOut()
        {
            checkFormLogin = checkFormRegister = checkFormNhanVien = checkFormTraCuuKH
            = checkFormKH = checkFormTaiKhoan = checkReportSaoKe = checkReportTaiKhoan = checkReportKH = false;
        }

    }

    
}
