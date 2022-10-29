<template>
  <div class="component">
    <!-- Button trigger modal -->
    <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
      Launch demo modal
    </button>

    <!-- Modal -->
    <div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered modal-xl">
        <div class="modal-content">
          <div class="">
            <h1 class="modal-title fs-5" id="exampleModalLabel"></h1>
            <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="modal-body container" v-if="recipe">
            <div class="row">
              <div class="col-md-5 pic" :style="{ backgroundImage: `url(${recipe.img})` }">
              </div>
              <div class="col-md-7">
                <div class="row">
                  <div class="col-md-6">
                    <h6 class="text-center">Recipe Steps</h6>
                    <p>{{recipe.instructions}}</p>
                  </div>
                  <div class="col-md-6">
                    <h6 class="text-center">Ingredients</h6>
                    <div v-for="i in ingredients" :key="i.id">
                      <IngredientList :ingredient="i" />
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
            <button type="button" class="btn btn-primary">Save changes</button>
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

.pic{
  background-size: cover;
  background-position: center;
}

</style>