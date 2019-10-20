using System.Collections.Generic;
using System.Linq;
using API.Context;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        
        Context1 context = new Context1();

        //Listando os usuários
        [HttpGet]
        public IActionResult ListUsers(){
            List<UsuarioModel> usersList = context.tbl_usuario.ToList(); 
            return Ok(usersList);
        }

        //Listando por Id
        [HttpGet("{id}")]
        public IActionResult SearchById(int id){
            return Ok(context.tbl_usuario.FirstOrDefault(x => x.Usuario_id == id));
        }

        [HttpPost]
        public IActionResult Register(UsuarioModel user){
            context.tbl_usuario.Add(user);
            context.SaveChanges();
            return Ok();
        }

        //Delete passando o objeto.
        [HttpDelete]
        public IActionResult DeleteUser(UsuarioModel user){
            context.tbl_usuario.Remove(user);
            context.SaveChanges();
            return Ok();
        }

        //Delete por Id
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id){
            if(id > 0){
                UsuarioModel deletedUser = context.tbl_usuario.SingleOrDefault(x => x.Usuario_id == id);
                context.tbl_usuario.Remove(deletedUser);
                context.SaveChanges();
                return Ok();
            }
            return Ok();
        }

        //Update pelo id
        [HttpPut("update/{id}")]
        public IActionResult UpdateAnUser(int id, UsuarioModel user){
            if(id > 0){
                UsuarioModel updatedUser = context.tbl_usuario.SingleOrDefault(x => x.Usuario_id == id);
                if(user.Usuario_nome != null){
                    updatedUser.Usuario_nome = user.Usuario_nome;
                }
                if(user.Usuario_email != null){
                    updatedUser.Usuario_email = user.Usuario_email;
                }
                if(user.Usuario_senha != null){
                    updatedUser.Usuario_senha = user.Usuario_senha;
                }
                context.SaveChanges();
                return Ok();    
            }
            return Ok();
        }
    }
}