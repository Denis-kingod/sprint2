using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inLock.webAPI.Interfaces;
using senai_inlock_webAPI.Properties.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Properties.Domains;

namespace WebApplication1.Properties.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstudiosController : ControllerBase
    {
        private IEstudiosRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudiosRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {

            List<EstudiosDomain> listaEstudio = _estudioRepository.ListarTodos();


            return Ok(listaEstudio);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            EstudiosDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estúdio encontrado!");
            }

            return Ok(estudioBuscado);
        }
        [HttpPost]
        public IActionResult Post(EstudiosDomain novoEstudio)
        {
            _estudioRepository.Cadastrar(novoEstudio);

            return StatusCode(201);

        }
        [HttpPut("{id}")]
        public IActionResult PutUrl(int id, EstudiosDomain estudioAtualizado)
        {
            EstudiosDomain estudioBuscado = _estudioRepository.BuscarPorId(id);

            if (estudioBuscado == null)
            {
                return NotFound
                    (new
                    {
                        mensagem = "Estúdio não encontrado!",
                        erro = true
                    });
            }

            try
            {
                _estudioRepository.Atualizar(id, estudioAtualizado);

                return NoContent();

            }
            catch (Exception erro)
            {

                return BadRequest(erro);
            }
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _estudioRepository.Deletar(id);

            return StatusCode(204);
        }

    }
}
