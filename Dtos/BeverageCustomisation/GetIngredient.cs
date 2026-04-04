using Coffeeg.Entities;

namespace Coffeeg.Dtos.BeverageCustomisation
{
    public record GetIngredient(
        int Id,
        string Descr,
        List<GetComplexIngredient> ComplexIngredients);

    //public class GetIngredient
    //{
    //    public int Id { get; set; }
    //    public string Descr { get; set; }
    //}
}
