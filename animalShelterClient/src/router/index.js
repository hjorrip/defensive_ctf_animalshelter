import Vue from "vue";
import VueRouter from "vue-router";
import Home from "../views/Home.vue";
import Login from "../views/Login.vue";
import Customers from "../views/Customers.vue";

Vue.use(VueRouter);

const routes = [
	{
		path: "/",
		name: "Home",
		component: Home,
	},
	{
		path: "/login",
		name: "Login",
		component: Login,
	},
	{
		path: "/customers",
		name: "Customers",
		component: Customers,
		meta: { requiresAuth: true },
	},
];

const router = new VueRouter({
	routes,
});

router.beforeEach(async(to, from, next) => {

	// Message from CEO 12AUG21: 
	// GUYS! You have to do better than this! Anyone can just type in /customers and get 
	// to our customer page without being authenticated and see all of our customer data! 
	// This is unacceptable! Fix this ASAP! 

	// Update from Dev team:
	// ** Fix 14AUG21 **
	// We have locked down the front-end client. Nobody can now access /customers without 
	// having a valid token. It's impossible to GET our customer data unauthenticated.

	if (to.meta.requiresAuth) {
		const token = localStorage.getItem('userToken')
    const response = await fetch("http://localhost:5000/api/authmanagement/validatejwt", {
      headers: {
        'Authorization': 'Bearer ' + token 
      }
    });

		if (response.status !== 200) {
			next({
				name: "Login",
			});
		} else {
			next();
		}
	} else {
		next();
	}
});

export default router;
