<template>
  <div
    class="employee-form"
    id="add__employee-form"
    :class="{ isShowDialog: isShow }"
  >
    <div class="container-form">
      <header class="popup--header">
        <div class="popup--title">
          <div class="header-popup">
            <div class="title-popup">Thông tin nhân viên</div>
            <label class="component">
              <input type="checkbox" class="checkbox--input" />
              <span class="slot-label">
                <div class="content">Là khách hàng</div>
              </span>
            </label>
            <label class="component">
              <input type="checkbox" class="checkbox--input" />
              <span class="slot-label">
                <div class="content">Là nhà cung cấp</div>
              </span>
            </label>
          </div>
        </div>

        <div class="popup-close">
          <div class="icon__wrapper">
            <div class="icon icon__help"></div>
          </div>

          <div class="icon__wrapper">
            <div class="icon icon__close" @click="btnCloseOnClick"></div>
          </div>
        </div>
      </header>

      <div class="popup-content__wrapper">
        <div class="popup-content">
          <div class="main-content" style="padding-bottom: 12px">
            <div class="left-info">
              <span class="multi-info__wrapper">
                <div class="row-input" style="width: 40%; margin-right: 6px">
                  <div class="m-input__title">
                    <div class="m-tooltip">Mã</div>
                    <div class="input__title__require">&nbsp;*</div>
                  </div>
                  <div class="m-input__input">
                    <input
                      type="text"
                      class="m-input input__required"
                      v-model="employee.EmployeeCode"
                      tabindex="1"
                      :class="{ 'm-input-error': isInputEmpty }"
                      required
                    />
                  </div>
                </div>
                <div class="row-input" style="width: 60%">
                  <div class="m-input__title">
                    <div class="m-tooltip">Tên</div>
                    <div class="input__title__require">&nbsp;*</div>
                  </div>
                  <div class="m-input__input">
                    <input
                      type="text"
                      class="m-input input__required"
                      v-model="employee.FullName"
                      tabindex="2"
                      :class="{ 'm-input-error': isInputEmpty }"
                      required
                    />
                  </div>
                </div>
              </span>
              <div class="row-input" style="width: 100%">
                <div class="m-input__title">
                  <div class="m-tooltip">Đơn vị</div>
                  <div class="input__title__require">&nbsp;*</div>
                </div>
                <!-- <div class="m-input__input" tabindex="4"
                                    style="display: flex; height: 40px; align-items: center; justify-content: space-between; background-color: white; border: 1px solid var(--border-color); border-radius: 4px; padding-left: 16px;">
                                    <div class="selected__department">
                                        Phòng nhân sự
                                    </div>
                                    <div class="icon__wrapper" style="margin-left: 2px">
                                        <div class="icon icon__dropdown--white"></div>
                                    </div>
                                </div> -->
                <MISACombox
                  url="https://cukcuk.manhnv.net/api/v1/Departments"
                  propText="DepartmentName"
                  propValue="DepartmentId"
                  tabindex="4"
                  v-model="employee.DepartmentId"
                ></MISACombox>
              </div>
              <div class="row-input" style="width: 100%">
                <div class="m-input__title">
                  <div class="m-tooltip">Chức danh</div>
                </div>
                <div class="m-input__input">
                  <input
                    type="text"
                    class="m-input"
                    v-model="employee.PositionName"
                    tabindex="7"
                  />
                </div>
              </div>
            </div>
            <div class="right-info">
              <span class="multi-info__wrapper">
                <div class="row-input" style="width: 40%; margin-right: 6px">
                  <div class="m-input__title">
                    <div class="m-tooltip">Ngày sinh</div>
                  </div>
                  <div class="m-input__input">
                    <input
                      type="date"
                      class="m-input"
                      v-model="employee.DateOfBirth"
                      tabindex="3"
                    />
                  </div>
                </div>
                <div
                  class="row-input"
                  style="
                    width: 60%;
                    padding-top: 5px;
                    padding-bottom: 6px;
                    padding-left: 10px;
                  "
                >
                  <div class="m-input__title">
                    <div class="m-tooltip">Giới tính</div>
                  </div>
                  <div class="radio-container">
                    <label class="radio-label">
                      <div class="radio-input">
                        <input type="radio" name="gender" value="male" />
                        <div class="radio-inner"></div>
                      </div>
                      <span>Nam</span>
                    </label>
                    <label class="radio-label">
                      <div class="radio-input">
                        <input type="radio" name="gender" value="female" />
                        <div class="radio-inner"></div>
                      </div>
                      <span>Nữ</span>
                    </label>
                    <label class="radio-label">
                      <div class="radio-input">
                        <input type="radio" name="gender" value="other" />
                        <div class="radio-inner"></div>
                      </div>
                      <span>Khác</span>
                    </label>
                  </div>
                </div>
              </span>

              <span class="multi-info__wrapper">
                <div class="row-input" style="width: 60%; margin-right: 6px">
                  <div class="m-input__title">
                    <div class="m-tooltip">Số CMND</div>
                  </div>
                  <div class="m-input__input">
                    <input
                      type="text"
                      class="m-input"
                      v-model="employee.IdentityNumber"
                      tabindex="5"
                    />
                  </div>
                </div>
                <div class="row-input" style="width: 40%">
                  <div class="m-input__title">
                    <div class="m-tooltip">Ngày cấp</div>
                  </div>
                  <div class="m-input__input">
                    <input
                      type="date"
                      class="m-input"
                      v-model="employee.IdentityDate"
                      tabindex="6"
                    />
                  </div>
                </div>
              </span>

              <div class="row-input" style="width: 100%">
                <div class="m-input__title">
                  <div class="m-tooltip">Nơp cấp</div>
                </div>
                <div class="m-input__input">
                  <input
                    type="text"
                    class="m-input"
                    v-model="employee.IdentityPlace"
                    tabindex="8"
                  />
                </div>
              </div>
            </div>
          </div>

          <div class="extra-content">
            <div class="row-input" style="width: 100%">
              <div class="m-input__title">
                <div class="m-tooltip">Địa chỉ</div>
              </div>
              <div class="m-input__input">
                <input
                  type="text"
                  class="m-input"
                  v-model="employee.Address"
                  tabindex="9"
                />
              </div>
            </div>

            <span class="multi-info__wrapper">
              <div class="row-input" style="width: 25%; margin-right: 6px">
                <div class="m-input__title">
                  <div class="m-tooltip">ĐT di động</div>
                </div>
                <div class="m-input__input">
                  <input
                    type="text"
                    class="m-input"
                    v-model="employee.PhoneNumber"
                    tabindex="10"
                  />
                </div>
              </div>
              <div class="row-input" style="width: 25%; margin-right: 6px">
                <div class="m-input__title">
                  <div class="m-tooltip">ĐT cố định</div>
                </div>
                <div class="m-input__input">
                  <input
                    type="text"
                    class="m-input"
                    v-model="employee.PhoneNumber"
                    tabindex="11"
                  />
                </div>
              </div>
              <div class="row-input" style="width: 25%">
                <div class="m-input__title">
                  <div class="m-tooltip">Email</div>
                </div>
                <div class="m-input__input">
                  <input
                    type="text"
                    class="m-input"
                    v-model="employee.Email"
                    tabindex="12"
                  />
                </div>
              </div>
            </span>

            <span class="multi-info__wrapper">
              <div
                class="row-input"
                style="width: 25%; margin-right: 6px; padding-bottom: 0px"
              >
                <div class="m-input__title">
                  <div class="m-tooltip">Tài khoản ngân hàng</div>
                </div>
                <div class="m-input__input">
                  <input type="text" class="m-input" tabindex="13" />
                </div>
              </div>
              <div
                class="row-input"
                style="width: 25%; margin-right: 6px; padding-bottom: 0px"
              >
                <div class="m-input__title">
                  <div class="m-tooltip">Tên ngân hàng</div>
                </div>
                <div class="m-input__input">
                  <input type="text" class="m-input" tabindex="14" />
                </div>
              </div>
              <div class="row-input" style="width: 25%; padding-bottom: 0px">
                <div class="m-input__title">
                  <div class="m-tooltip">Chi nhánh</div>
                </div>
                <div class="m-input__input">
                  <input type="text" class="m-input" tabindex="15" />
                </div>
              </div>
            </span>
          </div>
        </div>

        <div class="footer-container">
          <div class="popup-footer">
            <div class="popup-footer-button">
              <div class="btn-left">
                <MISAButton
                  :text="this.language.BUTTON.CANCEL"
                  classValue="btn left-group-button-popup"
                  :clickFunction="btnCloseOnClick"
                  tabindex="16"
                >
                </MISAButton>
              </div>

              <div class="align-right">
                <div class="right-group-button-popup">
                  <MISAButton
                    :text="this.language.BUTTON.SAVE"
                    classValue="btn first-right-button"
                    :clickFunction="btnCloseOnClick"
                    tabindex="17"
                  >
                  </MISAButton>

                  <MISAButton
                    :text="this.language.BUTTON.SAVE_AND_ADD"
                    classValue="btn second-right-button"
                    :clickFunction="btnSaveOnClick"
                    tabindex="18"
                  >
                  </MISAButton>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import axios from "axios";
// import TheToast from "@/components/layout/TheToast.vue";

import MISAButton from "@/components/base/MISAButton.vue";
import Resource from "@/scripts/resource";
import CommonJS from "@/scripts/common";
import Enum from "@/scripts/enum";
import MISACombox from "../../../node_modules/ms-combobox";

export default {
  name: "EmployeeDetail",
  components: { MISAButton, MISACombox },

  mounted() {
    // this.$data.tabElements = Object.values(this.$refs).filter((ref) =>
    //   Array.isArray(ref)
    // );
  },

  props: {
    isShow: {
      type: Boolean,
      default: false,
    },
    employeeSelected: {
      type: Object,
      default: () => ({}),
    },
    employeeSelectedId: {
      type: String,
      default: "",
    },
    formDetailMode: {
      type: Number,
      default: Enum.FORM_MODE.ADD,
    },
    departmentList: {
      type: Array,
      function() {
        return [];
      },
    },
  },
  emits: ["isShowDialog", "loadData", "update:show-toast"],

  watch: {
    // Sự kiện khi dialog được click
    isShow: function (val) {
      if (val) {
        this.$nextTick(() => {
          this.$refs.txtEmployeeCode.focus();
        });
      }
    },

    // Gán dữ liệu cho employee khi nhân viên được chọn
    employeeSelected: function (val) {
      this.employee = val;
    },

    employeeSelectedId: function (val) {
      if (val) {
        //Gọi API lấy dữ liệu nhân viên theo id
        //Hiển thị loading

        axios
          .get(
            `https://cukcuk.manhnv.net/api/v1/Employees/${this.employeeSelectedId}`
          )
          .then((res) => {
            this.employee = res.data;
          })
          .catch((err) => {
            //Nếu có lỗi, gán employee = {} và gọi api để lấy mã nhân viên mới
            console.log(err);
            this.employee = {};
            axios
              .get("https://cukcuk.manhnv.net/api/v1/Employees/NewEmployeeCode")
              .then((res) => {
                this.employee.EmployeeCode = res.data;
              })
              .catch((err) => {
                let response = err.response;
                var userMsg = err.response.data["userMsg"];
                switch (response.status) {
                  case 400:
                    break;
                  case 500:
                    break;
                  default:
                    break;
                }
                console.log(userMsg);
              });
          });

        //Ẩn loading
      } else {
        this.employee = {};
      }
    },

    "employee.FullName": function (newVal) {
      this.isInputEmpty = newVal === "";
    },
    "employee.EmployeeCode": function (newVal) {
      this.isInputEmpty = newVal === "";
    },
  },

  computed: {
  },

  methods: {
    /**
     * Sự kiện khi click vào nút đóng
     * CreatedBy: youngbachhh (22/08/2023)
     */
    btnCloseOnClick() {
      this.$emit("isShowDialog", false);
    },

    /**
     * Sự kiện khi click vào nút Cất và Lưu
     * CreatedBy: youngbachhh (22/08/2023)
     * UpdatedBy: youngbachhh (29/08/2023)
     */
    btnSaveOnClick() {
      // 1. validate dữ liệu
      // 2. build object thông tin nhân viên
      // 3. call API lưu dữ liệu
      // 3.1  Kiểm tra trạng thái form là thêm mới hay sửa
      if (this.formDetailMode == Enum.FORM_MODE.ADD) {
        this.addNewEmployee();
      } else if (this.formDetailMode == Enum.FORM_MODE.UPDATE) {
        this.updateEmployee();
      }
      

      // Nếu thêm mới thành công hiển thị toast message thông báo thành công
      // Nếu có lỗi validate hoặc lỗi từ back-end thì hiển thị thông báo tương ứng
    },

    /**
     * Hàm gọi API để thực hiện thêm mới nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     */
    addNewEmployee() {
      axios
        .post(`https://cukcuk.manhnv.net/api/v1/Employees`, this.employee)
        .then(() => {
          // Nếu thêm mới thành công hiển thị toast message thông báo thành công
          this.$emit("isShowDialog", false);
          this.$emit(
            "update:show-toast",
            Resource.VI.ERROR.SUCCESS_SAVE,
            Enum.TOAST_TYPE.SUCCESS
          );
        })
        .catch((err) => {
          this.catchError(err);
        });
    },

    /**
     * Hàm gọi API để thực hiện sửa nhân viên
     * CreatedBy: youngbachhh (29/08/2023)
     */
    updateEmployee() {
      axios
        .put(
          `https://cukcuk.manhnv.net/api/v1/Employees/${this.employeeSelectedId}`,
          this.employee
        )
        .then(() => {
          // Nếu sửa thành công hiển thị toast message thông báo thành công
          this.$emit("isShowDialog", false);
          this.$emit(
            "update:show-toast",
            Resource.VI.SUCCESS.SUCCESS_ADD,
            Enum.TOAST_TYPE.SUCCESS
          );
          
        })
        .catch((err) => {
          this.catchError(err);
        });
    },



    /**
     * Hàm xử lý khi gọi API bị lỗi
     * @param {Object} err
     * CreatedBy: youngbachhh (31/08/2023)
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
  },
  data() {
    return {
      language: Resource[CommonJS.Language],
      employee: {
        ...this.employeeSelected,
      },
      Enum,
      Resource,
      isInputEmpty: false,
      // tabElements: [], // Danh sách các phần tử tabindex
    };
  },
};
</script>

<style scoped>
@import url(../../style/component/employeeform.css);
</style>