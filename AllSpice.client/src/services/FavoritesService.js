import { AppState } from "../AppState.js";
import { FavRecipe } from "../models/FavRecipe.js";
import { api } from "./AxiosService.js"

class FavoritesService{
  async favoriteRecipe(recipeId) {
    const res = await api.post("api/favorites", recipeId);

    AppState.favorites = [new FavRecipe(res.data), ...AppState.favorites]
    console.log(AppState.favorites);
}
}

export const favoritesService = new FavoritesService()