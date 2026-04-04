namespace Coffeeg.Dtos
{
    public record UpdateBeverageCustomisation(
        int Id,
        int BeverageTypeId,
        int UserId,
        List<IngredientAmount> IngredientAmounts,
        List<ComplexIngredientAmount> ComplexIngredientAmounts);
}
