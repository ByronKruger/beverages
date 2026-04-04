using System.Text.Json.Serialization;

namespace Coffeeg.Entities
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Descr { get; set; }
        public bool IsComplex { get; set; }
        [JsonIgnore]
        public ICollection<BeverageType> BeverageTypes { get; set; } = new List<BeverageType>();

        public ICollection<ComplexIngredient> ComplexIngredients { get; set; } = new List<ComplexIngredient>();

    }
}
