import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { Recipe } from "../models/Recipe.js";
import { api } from "./AxiosService.js"

class FavoritesService {
  async favoriteRecipe(recipe) {


    let recipeId = {};
    recipeId.recipeId = recipe.id
    const res = await api.post("api/favorites", recipeId);

    // console.log(res.data)
    recipe.favoriteId = res.data.id
    AppState.favorites = [recipe, ...AppState.favorites]
    console.log(AppState.favorites);
  }

  async unFavoriteRecipe(favoriteId) {
    await api.delete(`api/favorites/${favoriteId}`)

    let index = AppState.favorites.findIndex(f => f.favoriteId == favoriteId)
    AppState.favorites.splice(index, 1)
    if (AppState.number) {
      AppState.recipes = AppState.recipes.filter(r => r.favoriteId != favoriteId)
    }

  }
}

export const favoritesService = new FavoritesService()