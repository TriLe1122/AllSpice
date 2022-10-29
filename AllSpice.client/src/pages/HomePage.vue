<template>
  <Banner />

  <section class="container">
    <div class="row justify-space-between">
      <div class="col-md-4 my-2" v-for="r in recipes" :key="r.id">
        <RecipeCard :recipe="r" />
      </div>
    </div>
  </section>
  <ActiveRecipeModal :recipe="activeRecipe" />
</template>

<script>
import { computed } from "@vue/reactivity";
import { onMounted } from "vue";
import { AppState } from "../AppState.js";
import ActiveRecipeModal from "../components/ActiveRecipeModal.vue";
import Banner from "../components/Banner.vue";
import RecipeCard from "../components/RecipeCard.vue";
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
    onMounted(() => {
      getAllRecipes();
    });
    return {
      recipes: computed(() => AppState.recipes),
      activeRecipe: computed(() => AppState.activeRecipe)
    };
  },
  components: { RecipeCard, Banner, ActiveRecipeModal }
}
</script>

<style scoped lang="scss">

</style>
