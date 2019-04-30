using DaltoAPI.Command;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;


namespace DaltoAPI.Controller
{
    [Produces("application/json")]
    [Route("api/data")]
    public class MainController : ControllerBase
    {
        private readonly MainCommand mainCommand = new MainCommand();

        [HttpGet]
        [Route("get")]
        public async Task<IActionResult> GetData()
        {
            try
            {
                return Ok(await mainCommand.GetDadosDb());
            }

            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("post/{idcor}")]
        public async Task<IActionResult> Inserir(int idCor)
        {
            try
            {
                await mainCommand.Insert(idCor);
                return Ok();
            }

            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}