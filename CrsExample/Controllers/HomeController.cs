using CrsExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CqrsExample.CQRS.Product.Command;
using CqrsExample.CQRS.Product.Query;
using MediatR;

namespace CrsExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        public HomeController(ILogger<HomeController> logger,IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult CreateProduct()
        {
            return View();
        }
        [HttpPost] 
        public async Task<IActionResult> CreateProductResult(ProductCreateCommandRequest request)
        {
            ProductCreateCommandResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult>  GetAllProducts()
        {
            ProductGetAllQueryResponse response = await _mediator.Send(new ProductGetAllQueryRequest());
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult>  ProductGetById(Guid id)
        {
            ProductGetByIdQueryResponse response = await _mediator.Send(new ProductGetByIdQueryRequest() {Id = id});
            return View(response);
        }
        [HttpGet]
        public IActionResult UpdateProductForm(Guid id)
        {
            ViewBag.Id = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  UpdateProduct(ProductUpdateCommandRequest request)
        {
            ProductUpdateCommandResponse response = await _mediator.Send(request);
            return View(response);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            ProductDeleteCommandResponse response = await _mediator.Send(new ProductDeleteCommandRequest() {Id = id});
            return View(response);
        }

    }
}
