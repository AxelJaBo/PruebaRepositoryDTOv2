using Microsoft.AspNetCore.Mvc;
using PruebaRepositoryDTOv2.DTOs;
using PruebaRepositoryDTOv2.Repositories;

namespace PruebaRepositoryDTOv2.Controllers
{
	public class ProductController(IProductRepository repo, IProviderRepository providerRepo, IProductTypeRepository productTypeRepository, IProductReportRepository productReportRepository) : Controller
	{
		private readonly IProductRepository _repo = repo;
		private readonly IProviderRepository _providerRepo = providerRepo;
		private readonly IProductTypeRepository _productTypeRepository = productTypeRepository;
        private readonly IProductReportRepository _productReportRepository = productReportRepository;

        public async Task<IActionResult> Index()
		{
            var products = (await _repo.GetProductsAsync()).Select(p => new ProductDTO
			{
				Id = p.Id,
				Nombre = p.Nombre,
				IDProveedor = p.IDProveedor,
				IDTipo = p.IDTipo,
				Cantidad = p.Cantidad,
				FechaAlta = p.FechaAlta,
				Modelo = p.Modelo,
				Marca = p.Marca,
			}).ToList();
			return View(products);
		}

        public async Task<IActionResult> Report()
        {
            var productsReport = (await _productReportRepository.GetProductReportAsync()).Select(p => new ProductReportDTO
            {
                IDProducto = p.IDProducto,
                NombreProducto = p.NombreProducto,
                Marca = p.Marca,
                Modelo = p.Modelo,
                TipoProducto = p.TipoProducto,
                Proveedor = p.Proveedor,
                Cantidad = p.Cantidad
            }).ToList();
            return View(productsReport);
        }

        public async Task<IActionResult> Create()
        {
            var providers = (await _providerRepo.GetProvidersAsync()).Select(p => new ProviderDTO
            {
                ID = p.ID,
                Nombre = p.Nombre
            }).ToList();

            var productTypes = (await _productTypeRepository.GetProductTypesAsync()).Select(p => new ProductTypeDTO
            {
                ID = p.ID,
                Nombre = p.Nombre
            }).ToList();

            var model = new ProductDTO
            {
                Providers = providers,
                ProductTypes = productTypes
            };

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                var product = new ProductDTO()
                {
                    Nombre = productDTO.Nombre,
                    IDProveedor = productDTO.IDProveedor,
                    IDTipo = productDTO.IDTipo,
                    Cantidad = productDTO.Cantidad,
                    Modelo = productDTO.Modelo,
                    Marca = productDTO.Marca,
                };
                await _repo.AddProductAsync(product);
                return RedirectToAction("Index");
            }

            productDTO.Providers = (await _providerRepo.GetProvidersAsync()).Select(p => new ProviderDTO
            {
                ID = p.ID,
                Nombre = p.Nombre
            }).ToList();
            productDTO.ProductTypes = (await _productTypeRepository.GetProductTypesAsync()).Select(p => new ProductTypeDTO
            {
                ID = p.ID,
                Nombre = p.Nombre
            }).ToList();
            return View(productDTO);
        }
    }
}
