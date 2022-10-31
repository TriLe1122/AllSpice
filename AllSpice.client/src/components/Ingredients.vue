<template>
  <div class="d-flex">
    <i class="mdi mdi-close text-danger me-3"  @click="removeIngredient()"></i>
    <p>
      {{ ingredient.quantity }} {{ingredient.name}}
    </p>
  </div>
</template>


<script>
import { computed } from "@vue/reactivity";
import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { ingredientsService } from "../services/IngredientsService.js";
import Pop from "../utils/Pop.js";
export default {
  props: {
    ingredient: {
      type: Ingredient,
      required: true
    }
  },
  setup(props) {
    return {
      account: computed(() => AppState.account),
      ingredients: computed(() => AppState.ingredients),
      async removeIngredient() {
        try {
          const yes = await Pop.confirm();
          if (!yes) {
            return;
          }
          await ingredientsService.removeIngredient(props.ingredient.id);
          Pop.success(
            `ingredient removed.`
          );
        } catch (error) {
          Pop.error(error);
        }
      },


    }
  }
}
</script>


<style lang="scss" scoped>

</style>