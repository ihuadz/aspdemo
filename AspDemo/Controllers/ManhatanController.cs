using AspDemo.Models.BLL;
using AspDemo.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Controllers
{
    public class ManhatanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            return View();
        }

        public IActionResult GetUserDataNoOrm()
        {
            ManhatanBLL manhatanBLL = new ManhatanBLL();
            return Json(manhatanBLL.GetDataNoOrm());
        }

        public IActionResult GetUserDataWithOrm()
        {
            ManhatanBLL manhatanBLL = new ManhatanBLL();
            return Json(manhatanBLL.GetDataWithOrm());
        }

        public IActionResult GetAllData()
        {
            ManhatanBLL manhatanBLL = new ManhatanBLL();
            var manhatanList = manhatanBLL.GetManhatanData();
            return Json(manhatanList);
        }

        [HttpPost]
        public IActionResult GetTableData([FromBody] PageInput<GWASListIn> input)
        {
            input ??= new PageInput<GWASListIn>();

            ManhatanBLL manhatanBLL = new ManhatanBLL();
            var tableData = manhatanBLL.GetTableData(input);
            return Json(tableData);
        }
    }
}
