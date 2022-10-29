import { AppState } from "../AppState.js";
import { Ingredient } from "../models/Ingredient.js";
import { api } from "./AxiosService.js"

class IngredientsService {
  async getIngredientsByRecipeId(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}/ingredients`)
    console.log(res.data);
    AppState.ingredients = res.data.map(i => new Ingredient(i))
    // console.log(AppState.ingredients);
  }
}

export const ingredientsService = new IngredientsService()