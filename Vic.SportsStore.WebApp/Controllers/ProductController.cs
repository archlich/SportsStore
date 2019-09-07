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

        private IProductsRepository repository;//constructor auto zhuru
        public ProductController(IProductsRepository productsRepository)//constructor auto zhuru
        {
            this.repository = productsRepository;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
    }
}