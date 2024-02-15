import { createApp } from 'vue'
import App from './App.vue'
// import { createRouter, createWebHistory } from 'vue-router'
// import EmployeeList from './view/employee/EmployeeList.vue'
// import ReportList from './view/report/ReportList.vue'
import router from './router'


// const routes = [
//     // { path: '/', component: Home },
//     { path: '/employee', component: EmployeeList },
//     { path: '/report', component: ReportList }

// ]

// const router = createRouter({
//     // 4. Provide the history implementation to use. We are using the hash history for simplicity here.
//     history: createWebHistory(process.env.BASE_URL),
//     routes, // short for `routes: routes`
// })


createApp(App).use(router).mount('#app')
