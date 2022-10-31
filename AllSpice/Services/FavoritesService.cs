namespace AllSpice.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepo;
  private readonly RecipesRepository _recipeRepo;

  private readonly RecipesService _rs;

  public FavoritesService(FavoritesRepository favoritesRepo, RecipesRepository recipeRepo, RecipesService rs)
  {
    _favoritesRepo = favoritesRepo;
    _recipeRepo = recipeRepo;
    _rs = rs;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    Favorite favoriteRecipe = _favoritesRepo.GetFavoriteByAccountAndRecipe(newFavorite);
    if (favoriteRecipe != null)
    {
      throw new Exception("already favorited");
    }
    Favorite favorite = _favoritesRepo.CreateFavorite(newFavorite);
    return favorite;
  }

  internal void RemoveFavorite(int favoriteId, string accountId)
  {
    Favorite foundFavorite = GetFavoriteById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("invalid id");
    }
    _favoritesRepo.RemoveFavorite(foundFavorite);
  }

  internal Favorite GetFavoriteById(int favoriteId)
  {
    Favorite foundFavorite = _favoritesRepo.GetFavoritesById(favoriteId);
    if (foundFavorite == null)
    {
      throw new Exception("invalid id");
    }
    return foundFavorite;
  }
}