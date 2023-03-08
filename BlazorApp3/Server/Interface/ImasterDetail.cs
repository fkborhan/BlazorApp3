using BlazorApp3.Server.BookItems;
using BlazorApp3.Shared;

namespace BlazorApp3.Server.Interface
{
    public interface ImasterDetail
    {
        public string AddBCShopVM(BCShopVM md2);
        public string RemoveBCShopVM(string id);
        public string UpdateBCShopVM(BCShopVM md);
        public List<BookCategory> GetTwoTables();
        public BCShopVM GetTwoTables2(string id);
        //public string GenerateCode();
        //public string Child_Exists(string id);

    }
}
