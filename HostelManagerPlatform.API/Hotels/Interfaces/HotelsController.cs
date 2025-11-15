using System.Net.Mime;
using HostelManagerPlatform.API.Hotels.Domain.Model.Queries;
using HostelManagerPlatform.API.Hotels.Domain.Model.Services;
using HostelManagerPlatform.API.Hotels.Interfaces.REST.Resource;
using HostelManagerPlatform.API.Hotels.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace HostelManagerPlatform.API.Hotels.Interfaces;

/// <summary>
/// Controlador de Hotel .
/// </summary>
/// <param name="hotelCommandService">El Servicio de Comandos de Hotel </param>
/// <param name="hotelQueryService">El Servicio de Consultas de Hotel </param>
[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Hotels")]
public class HotelsController(
    IHotelCommandService hotelCommandService,
    IHotelQueryService hotelQueryService)
    : ControllerBase
{
    // --------------------------------------------------------------------------------------
    // CREAR HOTEL (POST)
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Crea un nuevo Hotel . 
    /// </summary>
    /// <param name="re">CreateHotelRe re</param>
    /// <returns>
    /// Una respuesta con el Hotel  creado (201 Created), o un error (400 Bad Request).
    /// </returns>
    [HttpPost]
    [SwaggerOperation(
        Summary = "Crea un nuevo Hotel ",
        Description = "Crea un Hotel  con los datos de nombre, dirección, imagen, teléfono y UsersId",
        OperationId = "CreateHotel")]
    [SwaggerResponse(201, "El Hotel  fue creado", typeof(HotelResource))]
    [SwaggerResponse(400, "El Hotel  no pudo ser creado")]
    public async Task<ActionResult> CreateHotel([FromBody] CreateHotelResource resource)
    {
        var createHotelCommand = CreateHotelCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await hotelCommandService.Handle(createHotelCommand);
        
        if (result is null) return BadRequest();
        
        // Retorna 201 Created y el recurso creado
        return CreatedAtAction(
            nameof(GetHotelById), 
            new { id = result.Id }, 
            HotelResourceFromEntityAssembler.ToResourceFromEntity(result)
        );
    }
    
    // --------------------------------------------------------------------------------------
    // OBTENER POR ID (GET {id})
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Obtiene un Hotel  por su ID. 
    /// </summary>
    /// <param name="id">El ID del Hotel </param>
    /// <returns>
    /// Una respuesta con el Hotel  (200 OK), o no encontrado (404 Not Found).
    /// </returns>
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Obtiene un Hotel  por id",
        Description = "Obtiene un Hotel  para un identificador dado",
        OperationId = "GetHotelById")]
    [SwaggerResponse(200, "El Hotel  fue encontrado", typeof(HotelResource))]
    [SwaggerResponse(404, "Hotel  no encontrado")]
    public async Task<ActionResult> GetHotelById(int id)
    {
        var getHotelByIdQuery = new GetHotelByIdQuery(id);
        var result = await hotelQueryService.Handle(getHotelByIdQuery);
        
        if (result is null) return NotFound();
        
        var resource = HotelResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }

    // --------------------------------------------------------------------------------------
    // OBTENER TODOS O FILTRAR POR ADMIN ID (GET con query params)
    // --------------------------------------------------------------------------------------

    /// <summary>
    /// Obtiene todos los Hotel  o los filtra por el ID del administrador (UsersId). 
    /// </summary>
    /// <param name="adminId">ID del administrador/usuario asociado. Si se omite, retorna todos.</param>
    /// <returns>
    /// Una respuesta con la lista de Hotel  (200 OK).
    /// </returns>
    [HttpGet]
    [SwaggerOperation(
        Summary = "Obtiene Hotel , opcionalmente filtrados por Admin ID",
        Description = "Si se proporciona AdminId, filtra. Si no, retorna todos los hoteles.",
        OperationId = "GetHotelFromQuery")]
    [SwaggerResponse(200, "Resultado(s) fue/fueron encontrado(s)", typeof(IEnumerable<HotelResource>))]
    public async Task<ActionResult> GetHotelFromQuery([FromQuery] int? adminId)
    {
        IEnumerable<HostelManagerPlatform.API.Hotels.Domain.Model.Aggregates.Hotel> result;
        
        if (adminId.HasValue)
        {
            // Filtrar por Admin ID
            var query = new GetAllHotelByAdminIdQuery(adminId.Value);
            result = await hotelQueryService.Handle(query);
        }
        else
        {
            // Obtener todos
            var query = new GetAllHotelQuery();
            result = await hotelQueryService.Handle(query);
        }
        
        // Convertir entidades a recursos REST
        var resources = result.Select(HotelResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}