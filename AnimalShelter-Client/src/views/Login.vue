<template>
  <div class="my-5">
    <h1 class="display-4 my-4">Log into staff portal</h1>
    <form action @submit.prevent="onSubmit" class="w-25 mx-auto my-5">
      <div class="form-floating mb-3">
        <input
          v-model="login.email"
          type="email"
          class="form-control"
          id="floatingInput"
          placeholder="name@example.com"
          required
        />
        <label for="floatingInput">Email address</label>
      </div>
      <div class="form-floating">
        <input
          v-model="login.password"
          type="password"
          class="form-control"
          id="floatingPassword"
          placeholder="Password"
          required
        />
        <label for="floatingPassword">Password</label>
      </div>
      <p class="text-danger text-opacity-75 my-2">{{errorMessage}}</p>
      <input
        type="submit"
        value="LOG IN"
        class="btn btn btn-outline-success my-4"
      />
    </form>
  </div>
<!--  Our CEO has asked us to implement a client-side registration that also (rightfully!) shames the user with a 
funny animation if he tries to use 'Season-Year' type passwords. Must be implemented before the end of this year. 

Assigned to: 
RichardTCottons@theanimalshelter.com
SusanBRay@theanimalshelter.com
RobertBBrowder@theanimalshelter.com
HeatherDRobertson@theanimalshelter.com 
-->
</template>

<script>

export default {
  comments: true,
  name: "Login",
  data() {
    return {
      login: {
        email: '',
        password: '',
      },
      errorMessage: ''
    };
  },
  methods: {
   async onSubmit() {
        const requestOptions = {
          method: "POST",
          headers: { "Content-Type": "application/json" },
          body: JSON.stringify(this.login)
        };
        const response = await fetch("http://localhost:5000/api/authmanagement/login", requestOptions);
        const data = await response.json();

        if (data.success) { 
          localStorage.setItem('userToken', data.token)
          this.$emit("login", true) ;
          this.$router.push("/");
        } else { 
          this.errorMessage = data.errors[0]
        }
    },
  },
};
</script>

<style scoped>
</style>




            
