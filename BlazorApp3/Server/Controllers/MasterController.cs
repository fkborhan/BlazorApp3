using BlazorApp3.Server.Interface;
using BlazorApp3.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorApp3.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly ImasterDetail _ImasterDetail;
        public MasterController(ImasterDetail masterDetail)
        {
            _ImasterDetail = masterDetail;
        }
        [HttpGet]
        public async Task<List<BookCategory>> Get()
        {
            return await Task.FromResult(_ImasterDetail.GetTwoTables());
        }
        [HttpGet("{id}")]
        public BCShopVM Get(string id)
        {

            BCShopVM masterDelati = _ImasterDetail.GetTwoTables2(id);
            return masterDelati;

        }
        [HttpPost]
        public string AddBCShopVM(BCShopVM md2)
        {
            _ImasterDetail.AddBCShopVM(md2);
            return "1";

        }
        [HttpPut]
        public string UpdateBCShopVM(BCShopVM md)
        {
            _ImasterDetail.UpdateBCShopVM(md);
            return "2";
        }
        [HttpDelete("{id}")]
        public string RemoveBCShopVM(string id)
        {
            _ImasterDetail.RemoveBCShopVM(id);
            return "1";
        }

    }
}
