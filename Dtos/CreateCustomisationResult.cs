namespace Coffeeg.Dtos
{
    public record CreateCustomisationResult(
        //string Descr, // beverage type descr
        int Id, // beverage type id
        List<CreateCustomisationIngredient> IngredientAmounts,
        List<CreateCustomisationComplexIngredient> ComplexIngredientAmounts
        );
    //public class CreateCustomisationResult
    //{
    //    public string Descr { get; set; }
    //    public List<CreateCustomisationIngredient> IngredientAmounts { get; set; } = new List<CreateCustomisationIngredient>();
    //    public List<CreateCustomisationComplexIngredient> ComplexIngredientAmounts { get; set; } = new List<CreateCustomisationComplexIngredient>();
    //}

    public record CreateCustomisationComplexIngredient(
        //string Descr,
        int Id,
        decimal Amount);

    //public class CreateCustomisationComplexIngredient
    //{
    //    public string Descr { get; set; }
    //    public decimal Amount { get; set; }
    //}

    public record CreateCustomisationIngredient(
        //string Descr,
        int Id,
        decimal Amount);

    //public class CreateCustomisationIngredient
    //{
    //    public string Descr { get; set; }
    //    public decimal Amount { get; set; }
    //}
}
