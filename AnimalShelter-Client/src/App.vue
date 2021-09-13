<template>
  <div id="app">
    <div id="nav" class="navbar justify-content-around">
      <div class="d-flex flex-column align-items-center logo">
        <img
          class="icon-paw"
          src="./assets/green-paw.png"
          alt="The Animal Shelter"
        />
        <h4>The Animal Shelter</h4>
      </div>
      <div class="d-flex align-items-center">
        <router-link to="/">Home</router-link> 
        <router-link to="/login" v-show="!loggedIn">Log In</router-link>
        <router-link to="/customers" v-show="loggedIn">Customers</router-link>
        <button class="btn btn-outline-secondary" @click="logout" v-show="loggedIn">
          LOG OUT
        </button>
      </div>
    </div>
    <router-view class="container" @login="login" />
  </div>
</template>

<script>
export default {
  comments: true,
  name: "App",
  data() {
    return {
      loggedIn: false,
    };
  },
  methods: {
    login(details) {
      this.loggedIn = details
    },
    logout() {
      this.loggedIn = false;
      localStorage.removeItem('userToken')
      this.$router.push("/").catch(()=>{});
    },
  },
};
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #444;
}

#nav {
  padding: 16px;
  border-bottom: #444 1px solid;
}

#nav a {
  font-weight: bold;
  font-size: 18px;
  text-decoration: none;
  color: #333;
  margin: 0 24px;
}

#nav a.router-link-exact-active {
  color: #4f9a94;
}
.logo {
  cursor: default;
}
.logo h4 {
  color: #1a6b66;
  font-weight: bold;
}
.logo img {
  height: 32px;
  width: auto;
  margin: 8px;
  color: pink;
}
</style>
