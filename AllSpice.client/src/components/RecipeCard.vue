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

</template>


<script>
import { Recipe } from "../models/Recipe.js";
import { favoritesService } from "../services/FavoritesService.js";
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
      },

       async favoriteRecipe() {
        try {
          const recipeId = {
            recipeId: props.recipe.id,
          };
          await favoritesService.favoriteRecipe(recipeId);
          Pop.success("Favorited");
        } catch (error) {
          Pop.error(error);
        }
      },
    }
  }
}
</script>


<style lang="scss" scoped>
.component {
  width: 350px;
  height: 350px;
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