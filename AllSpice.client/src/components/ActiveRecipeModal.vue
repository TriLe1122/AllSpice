<template>
  <!-- Modal -->
  <div class="modal fade" id="exampleModal" aria-labelledby="exampleModalLabel" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered modal-xl ">
      <div class="modal-content all">
        <div class="">
        </div>
        <div class="d-flex" v-if="recipe">
          <div class="col-4">
            <img :src="recipe?.img" alt="" class="imgcol rounded-start " @error="badImg" />
            <button type="button" class="btn-close closebtn " data-bs-dismiss="modal" aria-label="Close"></button>
          </div>
          <div class="p-4">
            <div class="d-flex">
              <h4 class="ms-4">{{ recipe?.title }} </h4>
              <div class="bg-grey mb-4 px-2 rounded-5 ms-3 mt-1">{{ recipe?.category }}</div>
            </div>
            <div class="d-flex justify-content-around ms-4">
              <div class="position-absolute selectable no-select end-0 top-0 deleteicon rounded-3">
                <i class="mdi mdi-delete fs-3" @click="removeRecipe()" data-bs-dismiss="modal" v-if="account.id == recipe.creatorId"></i>
              </div>
              <div class="col-6 ms-2 bg-grey rounded">
                <div class="bg-dark text-center rounded-top p-2">
                  <h5 class="mt-1">Steps</h5>
                </div>
                <div class="px-3 pb-2 box">
                  {{ recipe?.instructions }}
                </div>
              </div>
              <div class="col-6 ms-3 bg-grey rounded">
                <div class="bg-dark text-center rounded-top p-2">
                  <h5 class="mt-1">Ingredients</h5>
                </div>
                <div class="px-3 pb-2 box" v-for="i in ingredients" :key="i.id">
                  <Ingredients :ingredient="i" />
                </div>
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
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
import Ingredients from "./Ingredients.vue";
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
        Pop.error(error);
      }
    }
    watchEffect(() => {
      AppState.activeRecipe;
      getIngredientsByRecipeId();
    });
    return {
      ingredients: computed(() => AppState.ingredients),
      account: computed(() => AppState.account),
      async removeRecipe() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          const recipeId = AppState.activeRecipe.id;
          await recipesService.removeRecipe(recipeId);
          Pop.success(
            `Recipe removed.`
          );
        } catch (error) {
          Pop.error(error);
        }
      },
    };
  },
  components: { Ingredients }
}
</script>
<style lang="scss" scoped>
.modal-content {
  position: relative;
}

.closebtn {
  transform: translateY(-35rem) translateX(69em);
  position: absolute;
}

.box {
  height: 395px;
  overflow: auto;
}

.imgcol {
  height: 80vh;
  width: 400px;
  object-fit: cover;
}

.deleteicon {
  transform: translateY(32.8rem) translateX(-0.4rem);
}
</style>