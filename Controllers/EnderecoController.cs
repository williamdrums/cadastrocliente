using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Controllers
{
    [Route("v1/endereco")]
    public class EnderecoController : ControllerBase
    {

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Endereco>>> Get([FromServices] DataContext context)
        {
            var enderecos = await context.Enderecos
            .Include(x => x.Cidade)
            .AsNoTracking().ToListAsync();
            return Ok(enderecos);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Endereco>> GetById(int id, [FromServices] DataContext context)
        {
            var endereco = await context
            .Enderecos.Include(x => x.Cidade)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(endereco);
        }

        [HttpGet]
        [Route("cidades/{id:int}")]
        public async Task<ActionResult<List<Endereco>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var enderecos = await context
            .Enderecos
            .Include(x => x.Cidade)
            .AsNoTracking()
            .Where(x => x.IdCidade == id)
            .ToListAsync();
            return enderecos;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Endereco>> Post([FromBody] Endereco model, [FromServices] DataContext context)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Enderecos.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel salvar o endereço" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Endereco>> Update(
            int id,
            [FromBody] Endereco model,
            [FromServices] DataContext context
            )
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Endereço não encontrado" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Entry<Endereco>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar os dados do endereço" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Endereco>> Delete(int id, [FromServices] DataContext context)
        {
            var endereco = await context.Enderecos.FirstOrDefaultAsync(x => x.Id == id);

            if (endereco == null)
            {
                return NotFound(new { message = "Cidade não encontrada" });
            }

            try
            {
                context.Enderecos.Remove(endereco);
                await context.SaveChangesAsync();
                return Ok(new { message = "Endereço removido com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover o endereço" });
            }
        }
    }
}