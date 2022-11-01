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

  async createRecipe(recipeData) {
    const res = await api.post("api/recipes", recipeData);
    console.log("[createRecipe]", res.data);
    const newRecipe = new Recipe(res.data);
    AppState.recipes = [newRecipe, ...AppState.recipes];
  }

  async removeRecipe(recipeId) {
     await api.delete(`api/recipes/${recipeId}`)
    AppState.recipes = AppState.recipes.filter(r => r.id != recipeId)
  }

  async getAccountRecipes() {
    const res = await api.get("api/recipes");
    console.log(res.data);
    AppState.recipes = res.data.map((r) => new Recipe(r));
   AppState.recipes = AppState.recipes.filter((r) => r.creator.id == AppState.account.id);
  }

  async getRecipesBySearchTerm(query) {
    const res = await api.get("api/recipes")
    AppState.recipes = res.data.map(r => new Recipe(r))
    // AppState.recipes = AppState.recipes.filter(f => f.category.includes(query))
    
    AppState.recipes = AppState.recipes.filter((f) =>
      f.title.toUpperCase().includes(query.toUpperCase())
    );
  }
}

export const recipesService = new RecipesService()