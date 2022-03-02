using ImagensProjeto.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImagensProjeto.Controllers
{
    public class ProdutoController : Controller
    {

        private readonly ImagensProjeto.Data.AppContext _appContext;

        public ProdutoController(ImagensProjeto.Data.AppContext appContext)
        {
            _appContext = appContext; 
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var allProdutos = await _appContext.Produtos.ToListAsync();
            return View(allProdutos); 
        }

        [HttpGet]

        public IActionResult Create()
        {
            return View();      
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Produto produto, IList<IFormFile> Img)
        {
            // tratar imagem
            IFormFile uploadedImage = Img.FirstOrDefault();
            MemoryStream ms = new MemoryStream();
            if (Img.Count > 0)
            {
                uploadedImage.OpenReadStream().CopyTo(ms);
                produto.Foto = ms.ToArray();
            }

            _appContext.Produtos.Add(produto);
            await _appContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
