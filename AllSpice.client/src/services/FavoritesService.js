import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { api } from "./AxiosService.js"

class FavoritesService{
  async favoriteRecipe(recipeId) {
    const res = await api.post("api/favorites", recipeId);

    AppState.favorites = [new FavRecipe(res.data), ...AppState.favorites]
    console.log(AppState.favorites);
  }
  
  async unFavoriteRecipe(favoriteId) {
 await api.delete(`api/favorites/${favoriteId}`)

    let index = AppState.favorites.findIndex(f => f.favoriteId == favoriteId)
    AppState.favorites.splice(index, 1)
  }
}

export const favoritesService = new FavoritesService()