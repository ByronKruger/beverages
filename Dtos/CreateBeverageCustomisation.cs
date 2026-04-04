namespace Coffeeg.Dtos
{
    public record CreateBeverageCustomisation(
        int BeverageTypeId,
        List<IngredientAmount>? IngredientAmounts,
        List<ComplexIngredientAmount>? ComplexIngredientAmounts);

    public record IngredientAmount(
        int Id,
        int BeverageCustomisationId,
        int IngredientId,
        decimal Amount);

    public record ComplexIngredientAmount(
        int Id,
        int BeverageCustomisationId,
        int ComplexIngredientId,
        decimal Amount);
}
