<template>
  <div class="component rounded-3 elevation-5" :style="{ backgroundImage: `url(${recipe.img})` }"
    @click="getRecipeDetails()" data-bs-toggle="modal" data-bs-target="#exampleModal">
    <div class="d-flex justify-content-between">
      <h6 class="glass-card rounded p-1 ms-2 mt-2">{{ recipe.category }}</h6>
      <i class="mdi mdi-heart text-danger"></i>
    </div>
    <div class="">
      <p class="glass-card title p-1 rounded">{{ recipe.title }}
      </p>
    </div>
  </div>


  <!-- <div class="card text-bg-dark component">
    <img :src="recipe.img" class="card-img" alt="...">
    <div class="card-img-overlay">
      <h5 class="card-title">{{ recipe.category }}</h5>
      <p class="card-text">This is a wider card with supporting text below as a natural lead-in to additional content.
        This content is a little bit longer.</p>
      <p class="card-text"><small>{{ recipe.title }}</small></p>
    </div>
  </div> -->
</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";

export default {
  props: {
    recipe: {
      type: Recipe,
      required: true
    }
  },
  setup(props) {
    return {
      async getRecipeDetails() {
        try {
          await recipesService.getRecipeDetails(props.recipe.id)
        } catch (error) {
          console.error('[]', error)
          Pop.error(error)
        }
      }
    }
  }
}
</script>


<style lang="scss" scoped>
.component {
  width: 250px;
  height: 250px;
  position: relative;

  background-size: cover;
  background-position: center;
}

.title {
  position: absolute;
  transform: translateY(8.5rem) translateX(2rem);
  max-width: 200px;
}
</style>