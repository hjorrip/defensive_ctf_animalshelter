<template>
  <div class="my-5">
    <h1 class="display-4 my-4">Adopt a cute animal today!</h1>
    <div class="d-flex flex-wrap">
      <AnimalCard v-for="animal in animals"
      :key="animal.id"
      :animal="animal"/>
    </div>
  </div>
</template>

<script>
// @ is an alias to /src
import AnimalCard from "@/components/AnimalCard.vue";

export default {
  name: "Home",
  components: {
    AnimalCard,
  },
  data() {
    return {
      animals: []
    };
  },
  async created() {
    const response = await fetch("http://localhost:5000/api/animals");
    const data = await response.json();
    this.animals = data;
  }
};
</script>

<style scoped>
</style>