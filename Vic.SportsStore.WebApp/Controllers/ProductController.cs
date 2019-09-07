using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vic.SportsStore.Domain.Abstract;

namespace Vic.SportsStore.WebApp.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product

        public IProductsRepository ProductsRepository { get; set; }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(ProductsRepository.Products);
        }
    }
}