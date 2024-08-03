using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging;
using Dapper;


namespace GullemDapperAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientApiController : Controller
    {
        private SqliteConnection _connection = new SqliteConnection("Data Source = gullemData.db");

        [HttpGet("GetClients")]
        public async Task<IActionResult> GetClients()
        {
            const string query = "Select * from Client";
            var result = await _connection.QueryAsync<Client>(query);

            if (result.Count() == 0)
            {
                return BadRequest("ERROR");
            }

            return Ok(result);
        }


        [HttpGet("GetClient")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            const string query = "Select * from Client where Id = @id LIMIT 1";
            var result = await _connection.QueryFirstAsync<Client>(query, new{id = @id});

            if (result == null)
            {
                return BadRequest("ERROR");
            }

            return Ok(result);
        }


        [HttpPost("SaveClient")]
        public async Task<IActionResult> SaveClientAsync(Client client)
        {
            const string query = "Insert Into Client (ClientName, Residency) values(@ClientName, @Residency); Select * from Client order by Id desc Limit 1";
            var result = await _connection.QueryAsync<Client>(query, client);

            return Ok(result);
        }


        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClientAsync(int Id, Client client)
        {
            const string query = "Update Client set ClientName=@ClientName, Residency=@Residency where Id=@Id; Select * from Client where @Id limit 1";
            var result = await _connection.QueryAsync<Client>(query, new
            {
                Id = Id,
                ClientName = client.ClientName,
                Residency = client.Residency,
            });

            return Ok(result);
        }


        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient(int Id){
            
            const string query = "Delete From Client where Id = @Id; ";
            
            await _connection.QueryAsync<Client>(query, new { Id = Id,});

            return Ok();
        }
    }
}

public class Client
{
    public int ID { get; set; }
    public string? ClientName { get; set; }
    public string? Residency { get; set; }
}