<template>
  <div class="">
    <div class="page-header">
      <div class="page-title">Nhân viên</div>
      <MISAButton
        :text="this.language.BUTTON.ADD"
        classValue="m-btn"
        :clickFunction="btnAddOnClick"
      ></MISAButton>
    </div>
    <div class="page-toolbar">
      <div class="mutiple__feature">
        <div class="count__checked">Đã chọn {{ countCheckedEmployee }}</div>

        <div
          class="mutiple__unchecked"
          :class="{ active: countCheckedEmployee >= 2 }"
          style="cursor: pointer"
        >
          <div
            class="mutiple__unchecked--text"
            style="font-weight: bold"
            @click="uncheckAll"
          >
            Bỏ chọn
          </div>
        </div>
        <div
          class="mutiple__delete"
          :class="{ active: countCheckedEmployee >= 2 }"
          style="cursor: pointer"
          @click="deleteMultipleEmployees"
        >
          <div class="multiple__delete--text" style="font-weight: bold">
            Xoá nhiều
          </div>
          <div class="icon__wrapper">
            <div class="icon icon__delete"></div>
          </div>
        </div>
      </div>

      <div class="search__feature">
        <input
          type="text"
          style="width: 220px"
          name=""
          id=""
          class="m-input m-input-icon m-icon-search"
          placeholder="Tìm kiếm theo mã, tên nhân viên"
        />
        <div class="icon__wrapper">
          <div class="icon icon__export"></div>
        </div>
        <div class="icon__wrapper">
          <div class="icon icon__reload" @click="fetchEmployeeData"></div>
        </div>
      </div>
    </div>

    <div class="page-grid">
      <div class="table-container">
        <table class="m-table">
          <thead style="background-color: rgb(238, 238, 238)">
            <tr>
              <th
                class="text-align-center "
                style="min-width: 48px"
              >
                <div class="checkbox__item">
                  <input type="checkbox" id="myCheckbox" class="checkbox" />
                  <label
                    for="myCheckbox"
                    class="checkbox__label"
                    
                    @click="checkedAllEmployee"
                  ></label>
                  <div class="icon__wrapper" :class="{ isChecked: isCheckAll }">
                    <div class="icon icon__check"></div>
                  </div>
                </div>
              </th>
              <th
                class="text-align-left "
                style="min-width: 150px"
              >
                MÃ NHÂN VIÊN
              </th>
              <th class="text-align-left" style="min-width: 215px">
                TÊN NHÂN VIÊN
              </th>
              <th class="text-align-left" style="min-width: 100px">
                GIỚI TÍNH
              </th>
              <th class="text-align-center" style="min-width: 130px">
                NGÀY SINH
              </th>
              <th
                class="text-align-left tooltip"
                data-tooltip="Số chứng minh nhân dân"
                style="min-width: 150px"
              >
                SỐ CMND
              </th>
              <th class="text-align-left" style="min-width: 170px">
                CHỨC DANH
              </th>
              <th class="text-align-left" style="min-width: 200px">
                TÊN ĐƠN VỊ
              </th>
              <th class="text-align-left" style="min-width: 170px">
                SỐ TÀI KHOẢN
              </th>
              <th class="text-align-left" style="min-width: 215px">
                TÊN NGÂN HÀNG
              </th>
              <th
                class="text-align-left tooltip"
                data-tooltip="Chi nhánh tài khoản ngân hàng"
                style="min-width: 230px"
              >
                CHI NHÁNH TK NGÂN HÀNG
              </th>
              <th
                class="text-align-center"
                style="min-width: 130px;"
              >
                CHỨC NĂNG
              </th>
            </tr>
          </thead>
          <tbody>
            <tr
              v-for="employee in employeeList"
              :key="employee.EmployeeId"
              @dblclick="rowOnDbClick(employee)"
              :class="[
                employee.EmployeeId,
                { checkedColor: employee.isChecked },
              ]"
              
            >
              <td
                class="text-align-center "
                style="min-width: 48px"
              >
                <div class="checkbox__item">
                  <input
                    type="checkbox"
                    :id="'checkbox-' + employee.EmployeeId"
                    class="checkbox"
                  />
                  <label
                    :for="'checkbox-' + employee.EmployeeId"
                    class="checkbox__label"
                    @click="checkedEmployee(employee)"
                  ></label>
                  <div
                    class="icon__wrapper"
                    :class="{ isChecked: employee.isChecked }"
                  >
                    <div class="icon icon__check"></div>
                  </div>
                </div>
              </td>
              <td class="text-align-left ">
                {{ employee.EmployeeCode }}
              </td>
              <td class="text-align-left">{{ employee.FullName }}</td>
              <td class="text-align-left">
                {{ formatData(employee.Gender, Enum.FORMAT_TYPE.GENDER) }}
              </td>
              <td class="text-align-center">
                {{ formatData(employee.DateOfBirth, Enum.FORMAT_TYPE.DATE) }}
              </td>
              <td class="text-align-left">{{ employee.PhoneNumber }}</td>
              <td class="text-align-left">{{ employee.PositionName }}</td>
              <td class="text-align-left">{{ employee.DepartmentName }}</td>
              <td class="text-align-left">123456789</td>
              <td class="text-align-left">Ngân hàng A</td>
              <td class="text-align-left">Chi nhánh A</td>
              <td
                class="text-align-center"
                style="color: #0062cc; cursor: pointer"
              >
                <div class="edit__wrapper">
                  <div class="edit-text" style="color: #0062cc">Sửa</div>
                  <div class="icon__wrapper edit__dropdown">
                    <div class="icon icon__dropdown--blue"></div>
                  </div>
                </div>
                <ul class="edit__dropdown__list">
                  <li class="edit__dropdown__item">
                    <span class="edit__dropdown__text">Nhân bản</span>
                  </li>
                  <li class="edit__dropdown__item" @click="deleteEmployee(employee)">
                    <span class="edit__dropdown__text">Xoá</span>
                  </li>
                  <li class="edit__dropdown__item">
                    <span class="edit__dropdown__text">Ngừng sử dụng</span>
                  </li>
                </ul>
              </td>
            </tr>
          </tbody>
        </table>
      </div>

      <div class="m-paging">
        <div class="m-paging__left">
          Tổng số: <strong> {{ employeeList.length }}</strong> bản ghi
        </div>
        <div class="m-paging__right">
          <div class="item-per-page__wrapper">
            <div class="item-per-page" @click="pageOnClick">
              <div class="item-per-page__option--selected">
                20 bản ghi trên 1 trang
              </div>
              <div class="icon__wrapper" style="margin-right: 6px">
                <div class="icon icon__dropdown--white"></div>
              </div>
            </div>
            <ul
              class="item-per-page__option__list"
              :class="{ 'show-paging': isShowPageList }"
            >
              <li class="item-per-page__option--item">
                <span class="item-per-page__option--text"
                  >10 bản ghi trên 1 trang</span
                >
              </li>
              <li class="item-per-page__option--item">
                <span class="item-per-page__option--text"
                  >50 bản ghi trên 1 trang</span
                >
              </li>
              <li class="item-per-page__option--item">
                <span class="item-per-page__option--text"
                  >100 bản ghi trên 1 trang</span
                >
              </li>
            </ul>
          </div>
          <div class="page-number">
            <div class="prev-page">Trước</div>
            <div class="page-number__wrapper">
              <div class="page-number--item">1</div>
              <div class="page-number--item">2</div>
              <div class="page-number--item">3</div>
            </div>
            <div class="next-page">Sau</div>
          </div>
        </div>
      </div>
    </div>
  </div>
  <EmployeeDetail
    v-if="isShowDialog"
    :isShow="isShowDialog"
    @isShowDialog="showDialogEmployeeDetail"
    :employeeSelected="employeeSelected"
    :employeeSelectedId="employeeSelectedId"
    :formMode="formDetailMode"
    @update:show-toast="showToast"
  />

  <TheToast
    :showToast="isShowToast"
    @closeToast="closeToast"
    :message="toastMessage"
    :messageType="toastType"
  ></TheToast>

  <div class="m-loading" :class="{ isLoading: isLoading }">
    <div class="icon__wrapper">
      <div class="icon icon__loading"></div>
    </div>
  </div>
</template>



<script>
import axios from "axios";
import EmployeeDetail from "./EmployeeDetail.vue";
import Enum from "@/scripts/enum";

import TheToast from "@/components/layout/TheToast.vue";
// import MISASelect from "@/components/base/MISASelect.vue";
import MISAButton from "@/components/base/MISAButton.vue";
import Resource from "@/scripts/resource";
import CommonJS from "@/scripts/common";

export default {
  name: "EmployeeList",
  components: {
    EmployeeDetail,
    MISAButton,
    TheToast,
  },

  //Vòng đời của Vue component
  beforeCreate() {
    //"1. beforeCreate"
    //Không thể truy cập DOM/data ở đây'
  },

  created() {
    this.isLoading = true;
    this.fetchEmployeeData();
    this.fetchDepartmentData();
  },

  beforeMount() {
    //Có thể truy cập data, event, method ở đây
    //Chưa có DOM
    //Chỉ chạy 1 lần
  },
  mounted() {
    //Có thể truy cập DOM/data ở đây
  },
  beforeUpdate() {
    //thay đổi style -> update dữ liệu -> render lại DOM
    //*Nên dùng để update dữ liệu vào DOM */
  },
  updated() {
    //update dữ liệu -> thay đổi state -> render lại DOM
    //Cũng có thể dùng để update dữ liệu vào DOM
  },
  beforeUnmount() {
    //Chưa bị hủy
  },
  unmounted() {
    //Đã bị hủy, không thể truy cập data, event, method ở đây
    //Ít khi dùng
  },

  methods: {
    fetchEmployeeData() {
      /**
       * Hàm gọi API để lấy về danh sách nhân viên và set giá trị checked cho từng nhân viên
       * CreatedBy: youngbachhh (22/08/2023)
       * UpdatedBy: youngbachhh (25/08/2023)
       */
      this.isLoading = true;
      axios
        .get("https://cukcuk.manhnv.net/api/v1/Employees")
        .then((response) => {
          this.isLoading = false;
          this.employeeList = response.data.map((employee) => {
            return { ...employee, isChecked: false };
          });
        })
        .catch((err) => {
          this.catchError(err);
        });
    },

    /**
     * Hàm gọi API để lấy về danh sách phòng ban
     * CreatedBy: youngbachhh (22/08/2023)
     * UpdatedBy: youngbachhh (25/08/2023)
     */
    fetchDepartmentData() {
      this.isLoading = true;
      axios
        .get("https://cukcuk.manhnv.net/api/v1/Departments")
        .then((res) => {
          this.isLoading = false;
          this.departmentList = res.data;
          var userMsg = "Load dữ liệu thành công";
          this.showToast(userMsg, Enum.TOAST_TYPE.SUCCESS);
        })
        .catch((err) => {
          this.isLoading = false;
          if (err.code === "ERR_NETWORK") {
            this.showToast(
              this.language.STATUS_CODE.INTERNAL_SERVER,
              Enum.TOAST_TYPE.ERROR
            );
            return;
          } else {
            let response = err.response;
            switch (response.status) {
              case 400:
                var userMsg = "Lỗi cú pháp";
                this.showToast(userMsg, Enum.TOAST_TYPE.ERROR);
                break;
              case 500:
                userMsg = "Lỗi server";
                this.showToast(userMsg, Enum.TOAST_TYPE.ERROR);
                break;
              default:
                break;
            }
          }
        });
    },

    /**
     * Định dạng dữ liệu theo kiểu
     * @param {String} value
     * @param {String} type
     * @returns {String}
     * CreatedBy: youngbachhh (22/08/2023)
     */
    formatData(value, type) {
      return CommonJS.formatData(value, type);
    },

    /**
     * Hàm xử lý khi click vào nút thêm mới nhân viên
     * CreatedBy: youngbachhh (22/08/2023)
     */
    btnAddOnClick() {
      this.employeeSelected = {};
      this.employeeSelectedId = null;
      this.formDetailMode = Enum.FORM_MODE.ADD;
      this.showDialogEmployeeDetail(true);
    },

    /**
     * Hiển thị dialog chi tiết nhân viên
     * @param {Boolean} isShow
     * CreatedBy: youngbachhh (22/08/2023)
     */
    showDialogEmployeeDetail(isShow) {
      this.isShowDialog = isShow;
    },

    /**
     * Hàm xử lý khi click vào nút chọn số bản ghi trên 1 trang
     * CreatedBy: youngbachhh (22/08/2023)
     */
    pageOnClick() {
      this.isShowPageList = !this.isShowPageList;
    },

    /**
     * Hàm xử lý khi double click vào 1 dòng trong bảng
     * @param {Employee} employee
     * CreatedBy: youngbachhh (25/08/2023)
     */
    rowOnDbClick(employee) {
      this.employeeSelected = employee;
      this.employeeSelectedId = employee.EmployeeId;
      this.formDetailMode = Enum.FORM_MODE.UPDATE;
      this.showDialogEmployeeDetail(true);
    },

    /**
     * Hàm xử lý khi click vào checkbox chọn 1 nhân viên
     * @param {Employee} employee
     * CreatedBy: youngbachhh (25/08/2023)
     */
    checkedEmployee(employee) {
      employee.isChecked = !employee.isChecked;
      if (employee.isChecked) {
        this.countCheckedEmployee++;
      } else {
        this.countCheckedEmployee--;
      }
    },


    /**
     * Hàm xử lý khi click vào checkbox chọn tất cả nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     */
    checkedAllEmployee() {
      var unchecked = true;
      this.isCheckAll = !this.isCheckAll;
      var count = 0;
      this.employeeList.forEach((employee) => {
        if (employee.isChecked) {
          count++;
        }
      });
      if (count == this.employeeList.length) {
        unchecked = false;
      }
      if (unchecked) {
        this.employeeList.forEach((employee) => {
          employee.isChecked = true;
        });
        this.countCheckedEmployee = this.employeeList.length;
      } else {
        this.employeeList.forEach((employee) => {
          employee.isChecked = false;
        });
        this.countCheckedEmployee = 0;
      }
    },

    /**
     * Hàm xử lý khi click vào Bỏ chọn tất cả nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     */
    uncheckAll() {
        this.isCheckAll = false;
      this.employeeList.forEach((employee) => {
        employee.isChecked = false;
      });
      this.countCheckedEmployee = 0;
    },

    /**
     * Show toast thông báo
     * @param {String} message
     * @param {String} messageType
     * CreatedBy: youngbachhh (29/08/2023)
     */
    showToast(message, messageType) {
      this.isShowToast = true;
      this.toastMessage = message;
      this.toastType = messageType;

      setTimeout(() => {
        this.closeToast();
      }, 3000);
    },

    /**
     * Ẩn toast thông báo
     * CreatedBy: youngbachhh (29/08/2023)
     */
    closeToast() {
      this.isShowToast = false;
    },

    /**
     * Hàm xử lý khi gọi API bị lỗi
     * @param {Object} err
     * CreatedBy: youngbachhh (29/08/2023)
     */
    catchError(err) {
      let response = err.response;
      var userMsg = err.response.data["userMsg"];
      switch (response.status) {
        case 400:
          this.$emit("update:show-toast", userMsg, Enum.TOAST_TYPE.ERROR);
          break;
        case 500:
          this.$emit("update:show-toast", userMsg, Enum.TOAST_TYPE.ERROR);
          break;
        default:
          break;
      }
      console.log(userMsg);
    },

      /**
     * Hàm gọi API để thực hiện xóa nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     */
     deleteEmployee(employee) {
      axios
        .delete(
          `https://cukcuk.manhnv.net/api/v1/Employees/${employee.EmployeeId}`
        )
        .then((res) => {
          //Thành công, hiển thị toast msg
          this.showToast(
            "update:show-toast",
            Resource.VI.SUCCESS.SUCCESS_DELETE,
            Enum.TOAST_TYPE.SUCCESS
          );
          console.log(res);
          this.fetchEmployeeData();
          this.isShowDialog = false;
        })
        .catch((err) => {
          console.log(err);
        });
    },


    /**
     * Hàm gọi API để thực hiện xóa nhiều nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     * Chưa hoàn thành
     */
    deleteMultipleEmployees() {
    const selectedEmployees = this.employeeList.filter(
      (employee) => employee.isChecked
    );

    if (selectedEmployees.length === 0) {
      // Không có nhân viên nào được chọn
      return;
    }

    const selectedEmployeeIds = selectedEmployees.map(
      (employee) => employee.EmployeeId
    );

    axios
      .post(
        'https://cukcuk.manhnv.net/api/v1/Employees/delete-multiple',
        selectedEmployeeIds
      )
      .then((res) => {
        this.showToast(
          'Xóa thành công ' + selectedEmployees.length + ' nhân viên',
          Enum.TOAST_TYPE.SUCCESS
        );
        this.fetchEmployeeData();
        this.uncheckAll(); 
        console.log(res);
      })
      .catch((err) => {
        console.log(err);
      });
  },
  },

  computed: {},

  data() {
    return {
      language: Resource[CommonJS.Language],
      selectedEmployees: [],
      employeeList: [],
      departmentList: [],
      employeeSelected: {},
      employeeSelectedId: null,
      isShowDialog: false,
      isShowPageList: false,
      isLoading: false,
      isCheckAll: false,
      formDetailMode: Enum.FORM_MODE.VIEW,
      Resource,
      Enum,
      countCheckedEmployee: 0,
      isShowToast: false,
      toastMessage: "",
      toastType: 0,
      delay: 2000,
    };
  },
};
</script>

<style scoped>
@import url(../../style/component/table.css);
@import url(../../style/component/paging.css);
@import url(../../style/page/employee.css);
</style>