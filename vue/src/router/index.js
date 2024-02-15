import { createRouter, createWebHistory } from 'vue-router'
import EmployeeList from '../view/employee/EmployeeList.vue'
import ReportList from '../view/report/ReportList.vue'

const routes = [
    // { path: '/', component: Home },
    { path: '/employee', component: EmployeeList },
    { path: '/report', component: ReportList }

]

const router = createRouter({
    // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
    history: createWebHistory(process.env.BASE_URL),
    routes, // short for `routes: routes`
})


export default router
