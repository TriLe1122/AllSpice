namespace AllSpice.Repositories;

public class FavoritesRepository : BaseRepository
{
  public FavoritesRepository(IDbConnection db) : base(db)
  {
  }

  internal Favorite CreateFavorite(Favorite newFavorite)
  {
    string sql = @"
    INSERT INTO favorites(recipeId, accountId)
    VALUES(@RecipeId, @AccountId);
    SELECT LAST_INSERT_ID()
    ;";
    int id = _db.ExecuteScalar<int>(sql, newFavorite);
    newFavorite.Id = id;
    return newFavorite;
  }

  // internal List<FavRecipe> GetFavoriteRecipes(string accountId)
  // {
  //   string sql = @"
  //   SELECT
  //   r.*,
  //   COUNT(f.id) AS FavoriteCount,
  //   f.id AS FavoriteId,
  //   a.*
  //   FROM favorites f
  //   JOIN recipes r ON r.id = f.recipeId
  //   JOIN accounts a ON a.id = r.creatorId
  //   WHERE r.accountId = @accountId
  //   GROUP BY f.id
  //   ;";
  //   return _db.Query<FavRecipe, Profile, FavRecipe>(sql, (recipe, profile) =>
  //   {
  //     recipe.Creator= profile;
  //     recipe.AccountId = profile.Id;
  //     return recipe;
  //   }, new { accountId }).ToList();
  // }

  internal List<FavRecipe> GetFavoritesByAccountId(string accountId)
  {
    string sql = @"
    SELECT
    r.*,
    COUNT(f.id) AS FavoriteCount,
    f.id AS FavoriteId,
    a.*
    FROM favorites f
    JOIN recipes r ON r.id = f.recipeId
    JOIN accounts a ON a.id = r.creatorId
    WHERE r.accountId = @accountId
    GROUP BY f.id
    ;";
    return _db.Query<FavRecipe, Profile, FavRecipe>(sql, (recipe, profile) =>
    {
      recipe.Creator = profile;
      recipe.AccountId = profile.Id;
      return recipe;
    }, new { accountId }).ToList();
  }
}