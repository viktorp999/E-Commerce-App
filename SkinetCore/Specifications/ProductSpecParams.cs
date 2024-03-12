
namespace SkinetCore.Specifications
{
    public class ProductSpecParams
    {
        private string _search;

        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
