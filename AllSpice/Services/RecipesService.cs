namespace AllSpice.Services;
public class RecipesService
{
  private readonly RecipesRepository _recipesRepo;
  private readonly FavoritesRepository _favoritesRepo;

  public RecipesService(RecipesRepository recipesRepo, FavoritesRepository favoritesRepo)
  {
    _recipesRepo = recipesRepo;
    _favoritesRepo = favoritesRepo;
  }

  internal Recipe CreateRecipe(Recipe newRecipe)
  {
    return _recipesRepo.CreateRecipe(newRecipe);
  }

  internal List<Recipe> GetAllRecipes()
  {
    return _recipesRepo.GetAllRecipes();
  }

  internal Recipe GetById(int recipeId)
  {
    Recipe foundRecipe = _recipesRepo.GetById(recipeId);

    if (foundRecipe == null)
    {
      throw new Exception("Recipe does not exist");
    }
    return foundRecipe;
  }

  internal void RemoveRecipe(int recipeId, string accountId)
  {
    Recipe foundRecipe = GetById(recipeId);
    if (foundRecipe == null)
    {
      throw new Exception("Recipe not found");
    }
    if (recipeId == 0)
    {
      throw new Exception("This Recipe doesn't exist");
    }
    if (foundRecipe.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete recipe");
    }

    foundRecipe.Archived = true;
    _recipesRepo.RemoveRecipe(foundRecipe);
  }

  internal Recipe EditRecipe(Recipe recipeData, string accountId)
  {

    if (recipeData.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to edit this recipe");
    }

    Recipe original = GetById(recipeData.Id);
    // original.Category = recipeData.Category ?? original.Category;
    // original.Img = recipeData.Img ?? original.Img;
    original.Instructions = recipeData.Instructions ?? original.Instructions;
    // original.Title = recipeData.Title ?? original.Title;
    // original.Creator=original.Creator;
    // original.CreatorId=original.CreatorId;
    // original.FavoriteCount=original.FavoriteCount;
    // original.Archived=original.Archived;

    Recipe recipe = _recipesRepo.EditRecipe(original);
    return recipe;
  }
}