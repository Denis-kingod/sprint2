using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inLock.webAPI.Interfaces;
using senai.inLock.webAPI.Repositories;
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

    //Adicionar o [Authorize} aqui para apenas usuarios com autenticação acessar os métodos 
    //[Authorize]

    public class JogosController : ControllerBase
    {
        private IJogosRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogosRepository();
        }
        [HttpGet]
        public IActionResult ListarTodos()
        {
            try
            {
                return Ok(_jogoRepository.ListarTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        ///<summary>
        ///Cadastra um novo jogo
        ///</summary>
        ///<param name="novoJogo">Objeto novoJogo com as informações</param>
        ///<returns>Retorna um status code 201 -Created</returns>

        //[Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult Cadastrar(JogosDomain novoJogo)
        {
            try
            {
                _jogoRepository.Cadastrar(novoJogo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
