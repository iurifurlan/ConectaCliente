using ConectaCliente.Data;
using ConectaCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConectaCliente.Controllers
{
    public class ClientesController : Controller
    {
        private readonly AppCont _appCont;
        public ClientesController (AppCont appCont)
        {
            _appCont = appCont;
        }
        public IActionResult Index()
        {
            var allTasks = _appCont.Clientes.ToList();
            return View(allTasks);
        }

        // Método Get / Details / Clientes
        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Cliente = await _appCont.Clientes
                .FirstOrDefaultAsync(x => x.Id == id);

            if (Cliente == null)
            {
                return BadRequest();
            }

            return View(Cliente);
        }
        public IActionResult Create()
        {
            return View();
        }

        // Método Post / Create / Cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Cliente cliente, IFormFile foto)
        {


            if (foto != null && foto.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                foto.CopyTo(memoryStream);
                cliente.FotoCliente = memoryStream.ToArray(); // Converte imagem para byte[]
            }

            _appCont.Clientes.Add(cliente); // Adiciona o cliente ao banco
            _appCont.SaveChanges(); // Salva as alterações no banco
            return RedirectToAction(nameof(Index)); // Redireciona para a listagem


            return View(cliente); // Retorna a view com erros de validação
        }

        // Método GET / Edit / Cliente
        public IActionResult Edit(int? id)
        {
            if (id == null || !_appCont.Clientes.Any(c => c.Id == id))
            {
                return NotFound();
            }

            var cliente = _appCont.Clientes.Find(id);
            return View(cliente);
        }

        // Método POST / Edit / Cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Cliente cliente, IFormFile foto)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            try
            {
                if (foto != null && foto.Length > 0)
                {
                    using var memoryStream = new MemoryStream();
                    foto.CopyTo(memoryStream);
                    cliente.FotoCliente = memoryStream.ToArray();
                }
                else
                {
                    // Mantém a foto existente se nenhuma nova for enviada
                    cliente.FotoCliente = _appCont.Clientes.AsNoTracking()
                        .FirstOrDefault(c => c.Id == cliente.Id)?.FotoCliente;
                }

                _appCont.Update(cliente);
                _appCont.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_appCont.Clientes.Any(e => e.Id == cliente.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));

            return View(cliente);
        }

        // Método GET / Delete / Cliente
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = _appCont.Clientes
                .FirstOrDefault(m => m.Id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // Método POST / Delete / Cliente
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var cliente = _appCont.Clientes.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _appCont.Clientes.Remove(cliente);
            _appCont.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }

}






 