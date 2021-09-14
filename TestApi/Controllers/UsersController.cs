using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestApi.Models;
using TestApi.Repository;
using System.Web.Http.Cors;


namespace TestApi.Controllers
{
    [EnableCors(origins: "https://localhost:44388", headers: "*", methods: "*")]

    [RoutePrefix("api")]
    public class UsersController : ApiController
    {
        [EnableCors("*", "*", "*")]
        [HttpGet, HttpPost]
        [Route("allUsers")]
        public List<Users> GetAllUsers()
        {
            return UsersRepository.GetAllUsers();
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [Route("insertUser")]
        public List<Users> InsertUser([FromBody] Users user)
        {
            return UsersRepository.InsertUser(user);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [Route("updatetUser")]
        public List<Users> UpdateUser([FromBody] Users user)
        {
            return UsersRepository.UpdateUser(user);
        }

        [EnableCors("*", "*", "*")]
        [HttpPost]
        [Route("deletetUser")]
        public List<Users> DeleteUser([FromBody] Users user)
        {
            return UsersRepository.DeleteUser(user);
        }

    }
}
