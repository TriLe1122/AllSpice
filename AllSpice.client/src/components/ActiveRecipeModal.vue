<template>
  <div class="component">
    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
          <div class="">
            <h1 class="modal-title fs-5" id="exampleModalLabel"></h1>

          </div>
          <div class=" container rounded" v-if="recipe">
            <div class="row">
              <div class="col-md-5 p-0 pic" :style="{ backgroundImage: `url(${recipe.img})` }">
                <!-- <img :src="recipe.img" class="pic rounded-start" alt=""> -->
              </div>
              <div class="col-md-7 details" :style="{ backgroundImage: `url(${recipe.img})` }">
                <div class="row details">
                  <div class="col-md-12 d-flex">
                    <h3 class="text-center">{{ recipe.title }}</h3>
                    <p class="bg-success rounded p-2 m-2">{{ recipe.category }}</p>
                  </div>
                  <div class="col-md-6">
                    <h6 class="text-center bg-danger p-2">Recipe Steps</h6>
                    <p class="bg-primary">{{ recipe.instructions }}</p>
                  </div>
                  <div class="col-md-6">
                    <h6 class="text-center">Ingredients</h6>
                    <div v-for="i in ingredients" :key="i.id">
                      <IngredientList :ingredient="i" />
                    </div>
                  </div>
                </div>
                <p class="text-end align-items-baseline">
                  published
                </p>
              </div>

            </div>
          </div>

        </div>
      </div>
    </div>

  </div>
</template>


<script>

import { computed } from "@vue/reactivity";
import { watchEffect } from "vue";
import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";
import IngredientList from "./IngredientList.vue";


export default {
  props: {
    recipe: {
      type: Recipe,
    }
  },
  setup(props) {
    async function getIngredientsByRecipeId() {
      try {
        if (AppState.activeRecipe) {
          let recipeId = AppState.activeRecipe.id;
          await ingredientsService.getIngredientsByRecipeId(recipeId);
        }
      }
      catch (error) {
        console.error("[]", error);
        Pop.error(error);
      }
    }
    watchEffect(() => {
      getIngredientsByRecipeId();

    });
    return {
      ingredients: computed(() => AppState.ingredients)
    };
  },
  components: { IngredientList }
}
</script>


<style lang="scss" scoped>
.pic {
  background-size: cover;
  background-position: center;
  height: 80vh;
  width: 474px;
  object-fit: cover;
}

.details {
  background-color: rgba(20, 15, 15, 0.88);
  backdrop-filter: blur(10px);
  background-size: cover;
  background-position: center;
  height: 80vh;
}
</style>