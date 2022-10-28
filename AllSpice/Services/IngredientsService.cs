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
}