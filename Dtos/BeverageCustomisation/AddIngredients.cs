namespace Coffeeg.Dtos.BeverageCustomisation
{
    public record AddIngredients (
        //int BeverageTypeId,
        string Description,
        List<string>? ComplexIngredientDescriptions
        );
}
