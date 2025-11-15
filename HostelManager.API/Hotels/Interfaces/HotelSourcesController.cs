using System.Net.Mime;
using HostelManager.API.Hotels.Domain.Model.Queries;
using HostelManager.API.Hotels.Domain.Model.Services;
using HostelManager.API.Hotels.Interfaces.REST.Resource;
using HostelManager.API.Hotels.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HostelManager.API.Hotels.Interfaces;

/// <summary>
/// Controlador de Hotel Sources.
/// </summary>
/// <param name="hotelSourceCommandService">El Servicio de Comandos de Hotel Source</param>
/// <param name="hotelSourceQueryService">El Servicio de Consultas de Hotel Source</param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Hotels")]
public class HotelsController(
    IHotelSourceCommandService hotelSourceCommandService,
    IHotelSourceQueryService hotelSourceQueryService)
    : ControllerBase
{
    // --------------------------------------------------------------------------------------
    // CREAR HOTEL (POST)
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Crea un nuevo Hotel Source. 
    /// </summary>
    /// <param name="resource">CreateHotelSourceResource resource</param>
    /// <returns>
    /// Una respuesta con el Hotel Source creado (201 Created), o un error (400 Bad Request).
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Crea un nuevo Hotel Source",
        Description = "Crea un Hotel Source con los datos de nombre, dirección, imagen, teléfono y UsersId",
        OperationId = "CreateHotelSource")]
    [SwaggerResponse(201, "El Hotel Source fue creado", typeof(HotelSourceResource))]
    [SwaggerResponse(400, "El Hotel Source no pudo ser creado")]
    public async Task<ActionResult> CreateHotelSource([FromBody] CreateHotelSourceResource resource)
    {
        var createHotelSourceCommand = CreateHotelSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await hotelSourceCommandService.Handle(createHotelSourceCommand);
        
        if (result is null) return BadRequest();
        
        // Retorna 201 Created y el recurso creado
        return CreatedAtAction(
            nameof(GetHotelSourceById), 
            new { id = result.Id }, 
            HotelSourceResourceFromEntityAssembler.ToResourceFromEntity(result)
        );
    }
    
    // --------------------------------------------------------------------------------------
    // OBTENER POR ID (GET {id})
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Obtiene un Hotel Source por su ID. 
    /// </summary>
    /// <param name="id">El ID del Hotel Source</param>
    /// <returns>
    /// Una respuesta con el Hotel Source (200 OK), o no encontrado (404 Not Found).
    /// </returns>
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Obtiene un Hotel Source por id",
        Description = "Obtiene un Hotel Source para un identificador dado",
        OperationId = "GetHotelSourceById")]
    [SwaggerResponse(200, "El Hotel Source fue encontrado", typeof(HotelSourceResource))]
    [SwaggerResponse(404, "Hotel Source no encontrado")]
    public async Task<ActionResult> GetHotelSourceById(int id)
    {
        var getHotelSourceByIdQuery = new GetHotelSourceByIdQuery(id);
        var result = await hotelSourceQueryService.Handle(getHotelSourceByIdQuery);
        
        if (result is null) return NotFound();
        
        var resource = HotelSourceResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    // --------------------------------------------------------------------------------------
    // OBTENER TODOS O FILTRAR POR ADMIN ID (GET con query params)
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Obtiene todos los Hotel Sources o los filtra por el ID del administrador (UsersId). 
    /// </summary>
    /// <param name="adminId">ID del administrador/usuario asociado. Si se omite, retorna todos.</param>
    /// <returns>
    /// Una respuesta con la lista de Hotel Sources (200 OK).
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Obtiene Hotel Sources, opcionalmente filtrados por Admin ID",
        Description = "Si se proporciona AdminId, filtra. Si no, retorna todos los hoteles.",
        OperationId = "GetHotelSourcesFromQuery")]
    [SwaggerResponse(200, "Resultado(s) fue/fueron encontrado(s)", typeof(IEnumerable<HotelSourceResource>))]
    public async Task<ActionResult> GetHotelSourcesFromQuery([FromQuery] int? adminId)
    {
        IEnumerable<HostelManager.API.Hotels.Domain.Model.Aggregates.HotelSource> result;
        
        if (adminId.HasValue)
        {
            // Filtrar por Admin ID
            var query = new GetAllHotelSourceByAdminIdQuery(adminId.Value);
            result = await hotelSourceQueryService.Handle(query);
        }
        else
        {
            // Obtener todos
            var query = new GetAllHotelSourceQuery();
            result = await hotelSourceQueryService.Handle(query);
        }
        
        // Convertir entidades a recursos REST
        var resources = result.Select(HotelSourceResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}