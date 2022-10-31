<template>
  <Banner />
<button data-bs-target="#recipeFormModal" data-bs-toggle="modal" class="btn btn-success ms-3 mt-3">
  CreateRecipe
</button>

  <section class="container">
    <div class="row justify-space-between">
      <div class="col-md-4 my-2" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </section>
  <ActiveRecipeModal :recipe="activeRecipe" />
<RecipeForm/>
</template>

<script>
import { onAuthLoaded } from "@bcwdev/auth0provider-client";
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import ActiveRecipeModal from "../components/ActiveRecipeModal.vue";

import Banner from "../components/Banner.vue";
import RecipeCard from "../components/RecipeCard.vue";
import RecipeForm from "../components/RecipeForm.vue";
import { accountService } from "../services/AccountService.js";
import { recipesService } from "../services/RecipesService.js";
import Pop from "../utils/Pop.js";
export default {
  setup() {
    async function getAllRecipes() {
      try {
        await recipesService.getAllRecipes();
      }
      catch (error) {
        console.error("[getting all recipes]", error);
        Pop.error(error);
      }
    }
    async function getAllFavorites() {
      try {
        if (AppState.account) {
          await accountService.getAllFavorites()
        }
      } catch (error) {
        console.error('[]', error)
        Pop.error(error)
      }
    }

    onMounted(() => {
      getAllRecipes();
    });

    onAuthLoaded(() => {
      getAllFavorites()
    });

    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe)
    };
  },
  components: { RecipeCard, Banner, ActiveRecipeModal, RecipeForm }
}
</script>

<style scoped lang="scss">

</style>
