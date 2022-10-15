using AuthenticationAPI.Models;
using AuthenticationAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using System.Net;
using MongoDB.Driver;

namespace AuthenticationAPI.Controllers
{
    public class UsuarioController : Controller
    {
        [Route("api/Authentication/")]
        public bool UserAuthentication([FromBody] Usuario usuario)
        {
            try
            {
                MongoDBRepository rep = new MongoDBRepository();
                bool autenticado = rep.ObterUsuario(usuario);
                if (autenticado)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            catch (Exception erro)
            {
                return false;
            }
        }
    }
}
