using AutoMapper;
using DevFitness.API.Core.Entities;
using DevFitness.API.Models.InputModels;
using DevFitness.API.Models.ViewModels;
using DevFitness.API.Persistencia;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFitness.API.Controllers
{
    //api/users
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly DevFitnessDbContext _dbContext;
        private readonly IMapper _mapper;
        public UsersController(DevFitnessDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        /// <summary>
        /// Retorna detalhes de usuario
        /// </summary>
        /// <param name="id">Identificador de usuário</param>
        /// <returns>Objeto de detalhes de usuário.</returns>
        /// <response code="200">Usuario encontrado com sucesso</response>
        /// <response code="404">Usuario não encontrado.</response>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var users = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            if (users == null)
                return NotFound();

            var userViewModel = _mapper.Map<UserViewModel>(users);
            return Ok(userViewModel);
        }

        /// <summary>
        /// Cadastrar um usuario
        /// </summary>
        /// <param name="inputModel">Objeto com dados de cadastro de usuario</param>
        /// <remarks>
        /// Requisição de exemplo:
        /// {
        /// "FullName":"Gui",
        /// "Height": 1.87,
        /// "Weight":90,
        /// "BirthDate":"1996-03-27 00:00:00"
        /// }
        /// </remarks>
        /// <returns>Objeto recem-criado.</returns>
        /// <response code="201">Objeto criado com sucesso.</response>
        /// <response code="400">Dados invalidos.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] CreateUserInputModel inputModel)
        {
            //var user = new User(inputModel.FullName, inputModel.Height, inputModel.Weight, inputModel.BirthDate);
            var user = _mapper.Map<User>(inputModel);
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = user.Id }, inputModel);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateUserInputModel inputModel)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            if (user == null)
                return NotFound();
            user.Update(inputModel.Height, inputModel.Weight);

            _dbContext.SaveChanges();

            return NoContent();
        }
    }
}
