import { AppState } from '../AppState'
import { FavRecipe } from "../models/FavRecipe.js"
import { Recipe } from "../models/Recipe.js"
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getAllFavorites() {
    const res = await api.get('account/favorites')
    console.log(res.data);
    AppState.recipes = res.data.map(r => new Recipe(r))
    console.log(AppState.accountFavorites);
  }

  async getMyFavorites() {
    const res = await api.get('account/favorites')
    // console.log(res.data);
    AppState.favorites = res.data.map(r => new Recipe(r))
    // console.log(AppState.accountFavorites);
    AppState.recipes.map(r => {
      let fav = AppState.favorites.find(f => f.id == r.id)
      if (fav) {
        r.favorited = true;
        r.favoriteId = fav.favoriteId
      }
    }) 

  }
}

export const accountService = new AccountService()
