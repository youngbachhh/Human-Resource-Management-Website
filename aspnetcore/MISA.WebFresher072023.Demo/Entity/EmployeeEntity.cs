using MISA.WebFresher072023.Demo.Enum;
using System;

namespace MISA.WebFresher072023.Demo
{
    public class EmployeeEntity
    {
        public Guid EmployeeId { get; set; } // ID nhân viên

        public string EmployeeCode { get; set; } // Mã nhân viên

        public string FullName { get; set; } // Họ và tên đầy đủ

        public string? FirstName { get; set; } // Tên

        public string? LastName { get; set; } // Họ và tên đệm

        public DateTime? DateOfBirth { get; set; } // Ngày sinh

        public Enum.Gender? Gender { get; set; } // Giới tính

        public string DepartmentId { get; set; } // ID của đơn vị


        public string? IdentityNumber { get; set; } // Số CMND

        public DateTime? IdentityDate { get; set; } // Ngày cấp CMND

        public string? IdentityPlace { get; set; } // Nơi cấp CMND

        public string? Address { get; set; } // Địa chỉ

        public string? MobilePhone { get; set; } // Số điện thoại di động

        public string? LandlinePhone { get; set; } // Số điện thoại cố định

        public string? Email { get; set; } // Email

        public string? BankAccount { get; set; } // Số tài khoản ngân hàng

        public string? BankName { get; set; } // Tên ngân hàng

        public string? BranchName { get; set; } // Tên chi nhánh ngân hàng

        public string? PositionName { get; set; } // Chức danh

        public DateTime? CreatedDate { get; set; } // Ngày tạo bản ghi

        public string? CreatedBy { get; set; } // Người tạo bản ghi

        public DateTime? ModifiedDate { get; set; } // Ngày chỉnh sửa bản ghi

        public string? ModifiedBy { get; set; } // Người chỉnh sửa bản ghi

    }
}
