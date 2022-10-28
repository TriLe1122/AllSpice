namespace AllSpice.Services;
public class FavoritesService{
  private readonly FavoritesRepository _favoritesRepo;

  public FavoritesService(FavoritesRepository favoritesRepo)
  {
    _favoritesRepo = favoritesRepo;
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    return _favoritesRepo.CreateFavorite(newFavorite);
  }

 
}