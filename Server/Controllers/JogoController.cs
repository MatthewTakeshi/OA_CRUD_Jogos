using Desafio_CRUD.Server;
using Microsoft.AspNetCore.Mvc;
using Desafio_CRUD.Shared;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

[ApiController]
[Route("[controller]")]
public class JogoController : Controller
{
    private readonly AppDbContext db;
    
    public JogoController(AppDbContext db)
    {
        this.db = db;
    }


    [HttpGet]
    [Route("List")]
    public async Task<IActionResult> Get()
    {
        var Jogos = await db.Jogos.ToListAsync();
        return Ok(Jogos);
    }

    [HttpGet]
    [Route("GetById")]
    public async Task<IActionResult> Get([FromQuery] string id)
    {
        var Joguinho = await db.Jogos.SingleOrDefaultAsync(x => x.ID == Convert.ToInt32(id));
        return Ok(Joguinho);
    }

    [HttpPost]
    [Route("Create")]
    public async Task<ActionResult> Post([FromBody] Jogo Joguinho)
    {
        try
        {
            var new_Jogo = new Jogo
            {
                ID = Joguinho.ID,
                Nome = Joguinho.Nome,
            };

            db.Add(new_Jogo);
            await db.SaveChangesAsync();
            return Ok();
        }
        catch(Exception e)
        {
            return View(e);
        }
    }

    [HttpPut]
    [Route("Update")]
    public async Task<IActionResult> Put([FromBody] Jogo Jogo_Modificado)
    {
        db.Entry(Jogo_Modificado).State = EntityState.Modified;
        try
        {
            await db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            throw (ex);
        }
        return NoContent();
    }

    [HttpDelete]
    [Route("Delete/{id}")]
    public async Task<ActionResult<Jogo>> Delete(int id)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var Joguinho = await db.Jogos.FindAsync(id);
        if (Joguinho == null)
        {
            return NotFound();
        }
        db.Jogos.Remove(Joguinho);
        await db.SaveChangesAsync();
        return Joguinho;
    }

    private bool Jogo_Exist(int id)
    {
        return db.Jogos.Any(e => e.ID == id);
    }


}