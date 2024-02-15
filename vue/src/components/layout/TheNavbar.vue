<template>
    <div class="navbar">
        <!-- <script src="https://unpkg.com/vue@3"></script>
        <script src="https://unpkg.com/vue-router@4"></script> -->

        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__overall"></div>
            </div>
            <div class="menu-text">Tổng quan</div>
        </div>
        <router-link class="menu-item" to="/employee">
            <div class="icon__wrapper">
                <div class="icon icon__money"></div>
            </div>
            <div class="menu-text">Tiền mặt</div>
        </router-link>
        <router-link class="menu-item" to="/report">
            <div class="icon__wrapper">
                <div class="icon icon__spending"></div>
            </div>
            <div class="menu-text">Tiền gửi</div>
        </router-link>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__buying"></div>
            </div>
            <div class="menu-text">Mua hàng</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__selling"></div>
            </div>
            <div class="menu-text">Bán hàng</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__management"></div>
            </div>
            <div class="menu-text">Quản lý hoá đơn</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__warehouse"></div>
            </div>
            <div class="menu-text">Kho</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__tool"></div>
            </div>
            <div class="menu-text">Công cụ dụng cụ</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__asset"></div>
            </div>
            <div class="menu-text">Tài sản cố định</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__tax"></div>
            </div>
            <div class="menu-text">Thuế</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__price"></div>
            </div>
            <div class="menu-text">Giá thành</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__synthetic"></div>
            </div>
            <div class="menu-text">Tổng hợp</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__budget"></div>
            </div>
            <div class="menu-text">Ngân sách</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__report"></div>
            </div>
            <div class="menu-text">Báo cáo</div>
        </div>
        <div class="menu-item">
            <div class="icon__wrapper">
                <div class="icon icon__analysis"></div>
            </div>
            <div class="menu-text">Phân tích tài chính</div>
        </div>
    </div>
</template>

<script>
export default {

}
</script>

<style scoped>
@import url(../../style/layout/navbar.css);
</style>