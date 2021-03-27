

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CadastroCliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CadastroCliente.Data;

namespace CadastroCliente.Controllers
{
    [Route("v1/estado")]
    public class EstadoController : ControllerBase
    {


        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Estado>>> Get(
                 [FromServices] DataContext context
             )
        {
            var estados = await context.Estados.AsNoTracking().ToListAsync();
            return Ok(estados);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Estado>> GetById(int id, [FromServices] DataContext context)
        {
            var estado = await context.Estados.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(estado);
        }


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Estado>> Post(
         [FromBody] Estado model,
         [FromServices] DataContext context
         )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Estados.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Não foi possivel criar estado", e });
            }

        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<Estado>> Update(
            int id,
            [FromBody] Estado model,
            [FromServices] DataContext context
            )
        {
            if (model.Id != id)
            {
                return NotFound(new { message = "Estado não encontrado" });
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                context.Entry<Estado>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;

            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Este registro já foi atualizado" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel atualizar os dados do estado" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Estado>> Delete(int id, [FromServices] DataContext context)
        {
            var estado = await context.Estados.FirstOrDefaultAsync(x => x.Id == id);

            if (estado == null)
            {
                return NotFound(new { message = "Estado não encontrado" });
            }

            try
            {
                context.Estados.Remove(estado);
                await context.SaveChangesAsync();
                return Ok(new { message = "Estado removido com sucesso!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possivel remover o estado" });
            }
        }
    }
}