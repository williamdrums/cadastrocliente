
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CadastroCliente.Controllers
{
    [Route("v1/cidade")]
    public class CidadeController : ControllerBase
    {


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Cidade>>> Get([FromServices] DataContext context)
        {
            var cidades = await context
            .Cidades.Include(x => x.Estado)
            .AsNoTracking().ToListAsync();
            return Ok(cidades);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Cidade>> GetById(int id, [FromServices] DataContext context)
        {
            var cidade = await context
            .Cidades.Include(x => x.Estado)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
            return Ok(cidade);
        }

        [HttpGet]
        [Route("estados/{id:int}")]
        public async Task<ActionResult<List<Cidade>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var cidades = await context
            .Cidades
            .Include(x => x.Estado)
            .AsNoTracking()
            .Where(x => x.IdEstado == id)
            .ToListAsync();
            return cidades;
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Cidade>> Post(
         [FromBody] Cidade model,
         [FromServices] DataContext context
         )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Cidades.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possivel salvar cidade", e });
            }

        }


        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Cidade>> Update(
            int id,
            [FromBody] Cidade model,
            [FromServices] DataContext context
            )
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Cidade não encontrada" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Entry<Cidade>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar os dados da cidade" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Cidade>> Delete(int id, [FromServices] DataContext context)
        {
            var cidade = await context.Cidades.FirstOrDefaultAsync(x => x.Id == id);

            if (cidade == null)
            {
                return NotFound(new { message = "Cidade não encontrada" });
            }

            try
            {
                context.Cidades.Remove(cidade);
                await context.SaveChangesAsync();
                return Ok(new { message = "Cidade removida com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover a cidade" });
            }
        }
    }
}