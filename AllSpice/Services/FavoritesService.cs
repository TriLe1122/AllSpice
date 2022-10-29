namespace AllSpice.Services;
public class FavoritesService
{
  private readonly FavoritesRepository _favoritesRepo;

  private readonly RecipesService _rs;

  public FavoritesService(FavoritesRepository favoritesRepo, RecipesService rs)
  {
    _favoritesRepo = favoritesRepo;
    _rs = rs;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    Recipe recipe = _rs.GetById(newFavorite.RecipeId);
    recipe.Id = newFavorite.RecipeId;
    return _favoritesRepo.CreateFavorite(newFavorite);
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