import { AppState } from "../AppState.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"


class RecipesService {
  async getAllRecipes() {
    const res = await api.get('api/recipes')
    // console.log(res.data);
    AppState.recipes = res.data.map(r => new Recipe(r), ...AppState.recipes)
    // console.log(AppState.recipes);
  }

  async getRecipeDetails(recipeId) {
    const res = await api.get(`api/recipes/${recipeId}`)
    // console.log(res.data);
    AppState.activeRecipe = new Recipe(res.data)
    console.log(AppState.activeRecipe);
  }
}

export const recipesService = new RecipesService()