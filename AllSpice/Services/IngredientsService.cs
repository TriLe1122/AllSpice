namespace AllSpice.Services;
public class IngredientsService{
  private readonly IngredientsRepository _ingredientsRepo;

  public IngredientsService(IngredientsRepository ingredientsRepo)
  {
    _ingredientsRepo = ingredientsRepo;
  }

  internal Ingredient CreateIngredient(Ingredient newIngredient)
  {
  return _ingredientsRepo.CreateIngredient(newIngredient);
  }

  internal List<Ingredient> GetIngredientsByRecipe(int recipeId)
  {
    return _ingredientsRepo.GetIngredientsByRecipe(recipeId);
  }

  internal Ingredient GetById(int ingredientId)
  {
    Ingredient foundIngredient = _ingredientsRepo.GetById(ingredientId);

    if (foundIngredient == null)
    {
      throw new Exception("Recipe does not exist");
    }
    return foundIngredient;
  }

  internal void RemoveIngredient(int ingredientId, string accountId)
  {
    Ingredient foundIngredient = GetById(ingredientId);
    if (foundIngredient == null)
    {
      throw new Exception("ingredient not found");
    }
    if (ingredientId == 0)
    {
      throw new Exception("ingredient doesn't exist");
    }
    if (foundIngredient.CreatorId != accountId)
    {
      throw new Exception("Unauthorized to delete ingredient");
    }
    _ingredientsRepo.RemoveIngredient(foundIngredient);
  }
}