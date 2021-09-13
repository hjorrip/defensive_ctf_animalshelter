<template>
  <div class="card border-success my-3 mx-auto myCard">
    <img
      :src="animal.imgUrl"
      class="card-img-top"
      alt="Anima"
    />
    <div class="card-body">
      <div class="p-2 text-center">
        <h4 class="card-title">{{animal.name}}</h4>
      </div>
      <div class="d-flex flex-row">
        <h5 class="card-title py-2 col-2">The <span>{{animal.species}}</span></h5>
        <p class="card-text py-2 px-4">
          {{animal.description}}
        </p>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  name: "AnimalCard",
  props: {
    animal: Object
  }
};
</script>

<style scoped>
.myCard {
  max-width: 600px;
}
span {
  font-weight: lighter;
}
</style>
