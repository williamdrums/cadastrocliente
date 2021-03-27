
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Data;

namespace CadastroCliente.Controllers
{
    [Route("v1/cliente")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cliente>>> Get([FromServices] DataContext context)
        {

            var clientes = await context.Clientes
            .Include(x => x.Endereco)
            .AsNoTracking()
            .ToListAsync();
            return Ok(clientes);

        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> GetbyId(int id, [FromServices] DataContext context)
        {
            var cliente = await context.Clientes
            .Include(x => x.Endereco)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(cliente);
        }
        [HttpGet]
        [Route("endereco/{id:int}")]
        public async Task<ActionResult<List<Cliente>>> GetByEndereco([FromServices] DataContext context, int id)
        {
            var clientes = await context
            .Clientes
            .Include(x => x.Endereco)
            .AsNoTracking()
            .Where(x => x.IdEndereco == id)
            .ToListAsync();
            return clientes;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cliente>> Post([FromBody] Cliente model, [FromServices] DataContext context)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Clientes.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel salvar cliente" });
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Update(
        int id,
        [FromBody] Cliente model,
        [FromServices] DataContext context)
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Entry<Cliente>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar os dados do cliente" });
            }

        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Cliente>> Delete(int id, [FromServices] DataContext context)
        {
            var cliente = await context.Clientes.FirstOrDefaultAsync(x => x.Id == id);

            if (cliente == null)
            {
                return NotFound(new { message = "Cliente não encontrado" });
            }

            try
            {
                context.Clientes.Remove(cliente);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cliente removido com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover cliente" });
            }
        }
    }
}