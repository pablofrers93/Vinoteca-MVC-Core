namespace Vinoteca_MVC_Core.ViewModels.Product
{
    public class ProductListVm
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Variety { get; set; }
        public string Winery { get; set; }
        public double Price { get; set; }
        public double Stock { get; set; }
    }
}