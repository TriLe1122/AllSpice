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
}