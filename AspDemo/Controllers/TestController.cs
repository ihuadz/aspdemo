using System;
using Microsoft.AspNetCore.Mvc;

namespace AspDemo.Controllers;

public class TestController : Controller
{
  public IActionResult Index()
  {
    return View();
  }

  public IActionResult Index2()
  {
    //return Content("this is Index2 content");
    return Json(new { id = 1, name = "test" });
  }

  public IActionResult Index3()
  {
    //return Content("this is Index2 content");
    return View("Hello", new { id = 1, name = "index3" });
  }
}
