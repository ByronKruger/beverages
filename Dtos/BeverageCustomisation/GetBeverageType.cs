namespace Coffeeg.Dtos.BeverageCustomisation
{
    public record GetBeverageType(
        int Id,
        string Descr,
        //IReadOnlyCollection<GetIngredient> );
        List<GetIngredient> Ingredients);

    //public class GetBeverageType
    //{
    //    public int Id { get; set; }
    //    public string Descr { get; set; }
    //    //IReadOnlyCollection<GetIngredient> );
    //    public List<GetIngredient> Ingredients { get; set; }
    //}
}
