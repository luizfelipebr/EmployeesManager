using EmployeesManager.Domain.Contracts.v1;
using EmployeesManager.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesAdmin.API.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "admin")]
    public class EmployeeController : ControllerBase
    {
        /// <summary>
        /// Busca todos os funcionários
        /// </summary>
        /// <param name="filter">Filtro para a lista de funcionários</param>
        /// <returns>Lista de funcionários</returns>
        [HttpGet]
        [Route("GetEmployees")]
        public ActionResult<List<EmployeeResponse>> GetAll(
            [FromServices] IEmployeeService service,
            [FromQuery] EmployeeRequestFilter filter) => (service.GetAllEmployees(filter));

        /// <summary>
        /// Insere um novo funcionário
        /// </summary>
        /// <param name="request"></param>
        /// <returns>Retorna o funcionário inserido</returns>
        [HttpPost]
        [Route("PostEmployee")]
        public async Task<ActionResult<EmployeeResponse>> Post(
            [FromServices] IEmployeeService service,
            [FromBody] EmployeePostRequest request) => (await service.CreateEmployee(request));

        /// <summary>
        /// Atualiza um funcionário
        /// </summary>
        /// <param name="id">Id do funcionário</param>
        /// <param name="request"></param>
        /// <returns>Retorna o funcionário atualizado</returns>
        [HttpPut]
        [Route("PutEmployee/{id}")]
        public async Task<ActionResult<EmployeeResponse>> Put(
            [FromRoute] Guid id,
            [FromServices] IEmployeeService service,
            [FromBody] EmployeePutRequest request) => (await service.UpdateEmployee(id, request));

        /// <summary>
        /// Deleta um funcionário
        /// </summary>
        /// <param name="id">Id do funcionário</param>
        /// <returns>Verdadeiro se sucesso</returns>
        [HttpDelete]
        [Route("DeleteEmployee/{id}")]
        public ActionResult<bool> Delete(
            [FromServices] IEmployeeService service,
            [FromRoute] Guid id) => (service.DeleteEmployee(id));
    }
}
