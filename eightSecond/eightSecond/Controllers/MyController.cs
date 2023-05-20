using eightSecond.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eightSecond.Controllers
{
    [ApiController]
    [Route("/api/Lera")]
    public class MyController : Controller
    {
        private readonly ILogger<MyController> _logger;
        private readonly Ilerax _userRepository;

        public MyController(ILogger<MyController> logger, Ilerax genericRepository)
        {
            _logger = logger;
            _userRepository = genericRepository;
        }

        /// <summary>
        /// Get All Users
        /// </summary>
        [ProducesResponseType(typeof(IEnumerable<LeraX>), 200)]
        [HttpGet]
        public IEnumerable<LeraX> Get()
        {
            return _userRepository.GetAll();
        }

        /// <summary>
        /// Add User my description change
        /// </summary>
        /// <response code="200">User updated</response>
        /// <response code="400">User not added</response>
        [HttpPost]
        [ProducesResponseType(typeof(LeraX), 200)]
        public LeraX AddUser(LeraX user)
        {
            try
            {
                _userRepository.Add(user);
                return user;
            }
            catch
            {
                Response.StatusCode = 404;
            }

            return user;
        }

        /// <summary>
        /// Get User by Id
        /// </summary>
        /// <param name="id" example="101">The User id</param>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(LeraX), 200)]
        public LeraX GetUser(int id)
        {
            return _userRepository.GetById(id);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpPut]
        [ProducesResponseType(typeof(LeraX), 200)]
        public LeraX EditUser(LeraX user)
        {
            _userRepository.Update(user);

            return user;
        }


        /// <summary>
        /// Delete User by Id
        /// </summary>
        /// <param name="id" example="101">The User id</param>
        /// <response code="200">User found</response>
        /// <response code="400">User not found</response>
        [HttpDelete("{id:int}")]
        [ProducesResponseType(typeof(LeraX), 200)]
        public LeraX DeleteUser(int id)
        {
            LeraX user = _userRepository.GetById(id);
            if (user == null)
            {
                return user;
            }
            _userRepository.Remove(user);
            return user;
        }
    }
}
