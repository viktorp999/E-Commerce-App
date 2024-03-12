
namespace SkinetCore.Specifications
{
    public class ProductSpecParams
    {
        private const int _maxPageSize = 50;
        private string _search;
        private int _pageSize = 6;

        public int PageIndex { get; set; } = 1;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string Sort { get; set; }
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > _pageSize) ? _maxPageSize : value;
        }
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
