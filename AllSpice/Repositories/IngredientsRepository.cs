namespace AllSpice.Repositories;

public class IngredientsRepository : BaseRepository
{
  public IngredientsRepository(IDbConnection db) : base(db)
  {
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
    string sql = @"
           INSERT INTO ingredients(name, quantity, recipeId)
           VALUES(@Name, @Quantity, @RecipeId);
           SELECT LAST_INSERT_ID()
                ;";
    int ingredientId = _db.ExecuteScalar<int>(sql, newIngredient);
    newIngredient.Id = ingredientId;
    return newIngredient;
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    string sql = @"
    SELECT
    i.*,
    a.*
    FROM ingredients i
    JOIN accounts a ON a.id = i.creatorId
    WHERE i.recipeId = @recipeId
    ;";
    return _db.Query<Ingredient, Profile, Ingredient>(sql, (ingredient, profile) =>
    {
      ingredient.Creator = profile;
      return ingredient;
    }, new { recipeId }).ToList();
  }
}