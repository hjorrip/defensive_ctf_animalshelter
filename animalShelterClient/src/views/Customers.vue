<template>
  <div class="my-5">
    <h1 class="display-4 my-4">Customers at the shelter</h1>
    <table class="table table-striped w-75 mx-auto my-5">
      <thead>
        <tr>
          <th>First name</th>
          <th>Last name</th>
          <th>Phone Number</th>
          <th>Email</th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="customer in customers" :key="customer.id">
          <td>{{customer.firstName}}</td>
          <td>{{customer.lastName}}</td>
          <td>{{customer.email}}</td>
          <td>{{customer.phoneNr}}</td>
        </tr>
      </tbody>
    </table>
  </div>
</template>

<script>
export default {
  name: "Customers",
  data() {
    return {
      customers: []
    };
  },
  async created() {
    const token = localStorage.getItem('userToken')
    const response = await fetch("http://api.animalshelter.hkn:5000/api/customers", {
      headers: {
        'Authorization': 'Bearer ' + token 
      }
    });
    const data = await response.json();
    this.customers = data;
  }
};
</script>