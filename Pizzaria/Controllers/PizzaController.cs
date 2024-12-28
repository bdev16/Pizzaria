using Microsoft.AspNetCore.Mvc;
using Pizzaria.Dto;
using Pizzaria.Services.Pizza;

namespace Pizzaria.Controllers
{
    public class PizzaController : Controller
    {
        private readonly IPizzaInterface _pizzaInterface;

        public PizzaController(IPizzaInterface pizzaInterface)
        {
            _pizzaInterface = pizzaInterface;
        }

        public async Task<IActionResult> Index()
        {
            var pizzas = await _pizzaInterface.GetPizzas();
            return View(pizzas);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        public async Task<IActionResult> Editar(int id)
        {
            var pizza = await _pizzaInterface.GetPizzaPorId(id);

            return View(pizza);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(PizzaCriacaoDto pizzaCriacaoDto, IFormFile imagem)
        {
            if (ModelState.IsValid)
            {
                var pizza = await _pizzaInterface.CriarPizza(pizzaCriacaoDto, imagem);
                return RedirectToAction("Index", "Pizza");
            }
            else
            {
                return View(pizzaCriacaoDto);
            }
        }
    }
}
