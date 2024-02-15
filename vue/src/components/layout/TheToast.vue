<template>
    <div class="m-toast__wrapper">
        <div class="m-toast-box" :class="{
            'is-show-toast': showToast,
        }">
            <div class="m-toast-item m-toast-error" :class="{ 'is-show-toast': messageType == Enum.TOAST_TYPE.ERROR }">
                <div class="icon__wrapper">
                    <div class="icon__error--blank-20"></div>
                </div>
                <div class="m-toast-text">{{ message }}</div>

                <div class="icon icon__wrapper" @click="closeToast">
                    <div class="icon__close" ></div>
                </div>
            </div>

            <div class="m-toast-item m-toast-warning" :class="{ 'is-show-toast': messageType == Enum.TOAST_TYPE.WARNING }">
                <div class="icon__wrapper">
                    <div class="icon__warning--blank-20"></div>
                </div>
                <div class="m-toast-text">{{ message }}</div>
                <div class="icon icon__wrapper" @click="closeToast">
                    <div class="icon__close" ></div>
                </div>
            </div>

            <div class="m-toast-item m-toast-success" :class="{ 'is-show-toast': messageType == Enum.TOAST_TYPE.SUCCESS }">
                <div class="icon__wrapper">
                    <div class="icon__success--blank-20"></div>
                </div>
                <div class="m-toast-text">{{ message }}</div>
                <div class="icon icon__wrapper" @click="closeToast">
                    <div class="icon__close" ></div>
                </div>
            </div>

            <div class="m-toast-item m-toast-info" :class="{ 'is-show-toast': messageType == Enum.TOAST_TYPE.INFO }">
                <div class="icon__wrapper">
                    <div class="icon__warning--blank-20"></div>
                </div>
                <div class="m-toast-text">{{ message }}</div>
                <div class="icon icon__wrapper" @click="closeToast">
                    <div class="icon__close" ></div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import Enum from "@/scripts/enum";

export default {
    props: ["message", "messageType", "showToast"],
    emits: ["closeToast"],
    methods: {
        /**
         * Hàm xử lý khi click vào nút đóng toast
         * CreatedBy: youngbachhh (22/08/2023)
         */
        closeToast() {
            this.$emit("closeToast");
            
        },
    },
    watch: {
        /**
         * Theo dõi sự thay đổi của prop showToast
         * @param {*} val
         * CreatedBy: youngbachhh (22/08/2023)
         */
        showToast: function (val) {
            if (val) {
                setTimeout(() => {
                    this.$emit("closeToast");
                }, 3000);
            }
        },
    },
    data() {
        return {
            Enum,
        };
    },
};
</script>
