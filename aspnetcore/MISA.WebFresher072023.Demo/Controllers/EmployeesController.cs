using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MISA.WebFresher072023.Api.Entity;
using System.Resources;
using MISA.WebFresher072023.Api.Resources;
using System.Data;
using System.Text.Unicode;

namespace MISA.WebFresher072023.Demo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly string _connectionString;

        public EmployeesController()
        {
            // Khởi tạo chuỗi kết nối
            _connectionString = "User Id = root; Host = localhost; Database = misa.web07; Character Set = utf8";
        }

        // Tạo kết nối
        private MySqlConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }






        /// <summary>
        /// Lấy toàn bộ danh sách nhân viên
        /// </summary>
        /// <returns>
        /// 200 - nếu có dữ liệu
        /// 400 - nếu có lỗi nghiệp vụ
        /// 500 - lỗi exception
        /// </returns>
        /// CREATED BY: youngbachhh (11/09/2023)
        [HttpGet]
        public async Task<IActionResult> GetAllEmployeeAsync()
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    // Tạo câu truy vấn
                    var sqlCommand = "sp_GetAllEmployees";

                    var result = await connection.QueryAsync<EmployeeEntity>("sp_GetAllEmployees", commandType: CommandType.StoredProcedure);

                    return Ok(result.ToList());
                }

                    
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            
        }


        // <summary>
        /// Lấy thông tin nhân viên theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// 200 - nếu có dữ liệu
        /// 400 - nếu có lỗi nghiệp vụ
        /// 500 - lỗi exception
        /// </returns>
        /// CREATED BY: youngbachhh (11/09/2023)

        [HttpGet]
        [Route("{employeeId}")]
        public async Task<IActionResult> GetEmployeeAsync(Guid employeeId)
        {
            try
            {

                using (var connection = CreateConnection())
                {
                    // Tạo câu truy vấn
                    var sqlCommand = "sp_GetEmployeeById";

                    var result = await connection.QueryFirstOrDefaultAsync<EmployeeEntity>("sp_GetEmployeeById", commandType: CommandType.StoredProcedure);

                    return Ok(result);

                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            
        }

        /// <summary>
        /// Thêm một nhân viên mới
        /// </summary>
        /// <param name="employee">Thông tin của nhân viên cần thêm</param>
        /// <returns>
        /// 201 - nếu thêm thành công, trả về ID của nhân viên mới
        /// 400 - nếu có lỗi nghiệp vụ
        /// 500 - lỗi exception
        /// </returns>
        /// CREATED BY: youngbachhh (11/09/2023)

        [HttpPost]
        public async Task<IActionResult> AddEmployeeAsync([FromBody] EmployeeEntity employee)
        {

            try
            {
                var error = new ErrorService();

                var errorData = new Dictionary<string, string>();
                var errorList = new List<string>();
                // Validate dữ liệu trả về mã 400  
                // 1.1 Mã nhân viên
                if (string.IsNullOrEmpty(employee.EmployeeCode))
                {

                    errorData.Add("EmployeeCode", ResourceVN.ValidateError_EmployeeCodeNotEmpty);
                    errorList.Add(ResourceVN.ValidateError_EmployeeCodeNotEmpty);

                }
                // 1.2 Tên nhân viên
                if(string.IsNullOrEmpty(employee.FullName))
                {

                    errorData.Add("FullName", ResourceVN.ValidateError_FullNameNotEmpty);
                    errorList.Add(ResourceVN.ValidateError_FullNameNotEmpty);

                }
                // 1.3 Email
                // 1.4 Ngày sinh


                // Mã nhân viên đã tồn tại chưa
                if(CheckEmployeeCodeExist(employee.EmployeeCode))
                {
                    errorData.Add("EmployeeCode", ResourceVN.ValidateError_EmployeeCodeExist);
                    errorList.Add(ResourceVN.ValidateError_EmployeeCodeExist);
                }
                

                if (errorList.Count > 0)
                {
                    error.DevMsg = ResourceVN.Error_ValidateData;
                    error.UserMsg = ResourceVN.Error_ValidateData;
                    error.Data = errorData;

                    return BadRequest(error);
                }


                using (var connection = CreateConnection())
                {
                    // Tạo câu truy vấn INSERT
                    var sqlCommand = "Proc sp_InsertEmployee";

                    // Tạo đối tượng DynamicParameters để truyền tham số
                    var dynamicParam = new DynamicParameters();
                    dynamicParam.Add("@p_EmployeeId", Guid.NewGuid()); // Tạo một EmployeeId mới
                    dynamicParam.Add("@p_EmployeeCode", employee.EmployeeCode);
                    dynamicParam.Add("@p_FullName", employee.FullName);
                    dynamicParam.Add("@p_DepartmentId", employee.DepartmentId);
                    dynamicParam.Add("@p_PositionName", employee.PositionName);
                    dynamicParam.Add("@p_DateOfBirth", employee.DateOfBirth);
                    dynamicParam.Add("@p_Gender", employee.Gender);
                    dynamicParam.Add("@p_IdentityNumber", employee.IdentityNumber);
                    dynamicParam.Add("@p_IdentityDate", employee.IdentityDate);
                    dynamicParam.Add("@p_IdentityPlace", employee.IdentityPlace);
                    dynamicParam.Add("@p_Address", employee.Address);
                    dynamicParam.Add("@p_MobilePhone", employee.MobilePhone);
                    dynamicParam.Add("@p_LandlinePhone", employee.LandlinePhone);
                    dynamicParam.Add("@p_Email", employee.Email);
                    dynamicParam.Add("@p_BankAccount", employee.BankAccount); 
                    dynamicParam.Add("@p_BankName", employee.BankName);
                    dynamicParam.Add("@p_BranchName", employee.BranchName);
                    dynamicParam.Add("@p_CreatedBy", employee.CreatedBy);
                    dynamicParam.Add("@p_ModifiedBy", employee.ModifiedBy);

                    var result = await connection.ExecuteAsync(sql: sqlCommand, param: dynamicParam, commandType: CommandType.StoredProcedure);


                    return StatusCode(201, new { EmployeeId = dynamicParam.Get<Guid>("@EmployeeId") });
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);

            }
        }



        /// <summary>
        /// Sửa thông tin nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// 200 - nếu có dữ liệu
        /// 400 - nếu có lỗi nghiệp vụ
        /// 500 - lỗi exception
        /// </returns>
        /// CREATED BY: youngbachhh (11/09/2023)

        [HttpPut]
        [Route("{employeeId}")]
        public async Task<IActionResult> EditEmployeeAsync(Guid employeeId, [FromBody] EmployeeEntity employee)
        {
            try
            {

                using (var connection = CreateConnection())
                {

                    // Kiểm tra xem nhân viên có tồn tại
                    var existingEmployee = await GetEmployeeAsync(employeeId);

                    if (existingEmployee == null)
                    {
                        throw new Exception(ResourceVN.Error_EmployeeNotFound);
                    }

                    // Tạo câu truy vấn UPDATE
                    var sqlCommand = "Proc sp_EditEmployee";

                    // Tạo đối tượng DynamicParameters để truyền tham số
                    var dynamicParam = new DynamicParameters();
                    dynamicParam.Add("@EmployeeId", employeeId);
                    dynamicParam.Add("@EmployeeCode", employee.EmployeeCode);
                    dynamicParam.Add("@FullName", employee.FullName);
                    dynamicParam.Add("@DepartmentId", employee.DepartmentId);
                    dynamicParam.Add("@PositionName", employee.PositionName);
                    dynamicParam.Add("@DateOfBirth", employee.DateOfBirth);
                    dynamicParam.Add("@Gender", employee.Gender);
                    dynamicParam.Add("@IdentityNumber", employee.IdentityNumber);
                    dynamicParam.Add("@IdentityDate", employee.IdentityDate);
                    dynamicParam.Add("@IdentityPlace", employee.IdentityPlace);
                    dynamicParam.Add("@Address", employee.Address);
                    dynamicParam.Add("@MobilePhone", employee.MobilePhone);
                    dynamicParam.Add("@LandlinePhone", employee.LandlinePhone);
                    dynamicParam.Add("@Email", employee.Email);
                    dynamicParam.Add("@BankAccount", employee.BankAccount);
                    dynamicParam.Add("@BankName", employee.BankName);
                    dynamicParam.Add("@BranchName", employee.BranchName);
                    dynamicParam.Add("@CreatedDate", employee.CreatedDate);
                    dynamicParam.Add("@CreatedBy", employee.CreatedBy);
                    dynamicParam.Add("@ModifiedDate", employee.ModifiedDate);
                    dynamicParam.Add("@ModifiedBy", employee.ModifiedBy);



                    var result = await connection.ExecuteAsync(sql: sqlCommand, param: dynamicParam, commandType: CommandType.StoredProcedure);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);

            }
        }

        /// <summary>
        /// Xoá nhân viên
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns>
        /// 200 - nếu có dữ liệu
        /// 400 - nếu có lỗi nghiệp vụ
        /// 500 - lỗi exception
        /// </returns>
        /// CREATED BY: youngbachhh (11/09/2023)

        [HttpDelete]
        [Route("{employeeId}")]
        public async Task<IActionResult> DeleteEmployeeAsync(Guid employeeId)
        {
            try
            {
                using (var connection = CreateConnection())
                {

                    var employee = await GetEmployeeAsync(employeeId);

                    if (employee == null)
                    {
                        throw new Exception(ResourceVN.Error_EmployeeNotFound);
                    }

                    // Tạo câu truy vấn
                    var sqlCommand = "sp_DeleteEmployee";

                    var result = await connection.ExecuteAsync("sp_DeleteEmployee", commandType: CommandType.StoredProcedure);

                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
            
        }

        /// <summary>
        /// Xử lý ngoại lệ
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        /// CreatedBy: youngbachhh (11/09/2023)
        private IActionResult HandleException(Exception ex)
        {
            var error = new ErrorService();
            error.DevMsg = ex.Message;
            error.UserMsg = ResourceVN.Error_Exception;

            return StatusCode(500 , error);
        }



        /// <summary>
        /// Hàm kiểm tra mã nhân viên đã tồn tại hay chưa
        /// </summary>
        /// param name="employeeCode"></param>
        /// returns>true là đa tồn tại, false là chưa tồn tại</returns>
        /// CreatedBy: youngbachhh (11/09/2023)
        private bool CheckEmployeeCodeExist(string employeeCode)
        {

            using (var connection = CreateConnection())
            {
                // Tạo câu truy vấn
                var sql = $"SELECT EmployeeCode FROM Employee WHERE EmployeeCode = @employeeCode";

                // Tạo DynamicParam
                var dynamicParam = new DynamicParameters();
                dynamicParam.Add("@employeeCode", employeeCode);

                var result = connection.QueryFirstOrDefault(sql, dynamicParam);

                if (result == null)
                {
                    return false;
                }

                return true;
            }
                
        }
    }
}
