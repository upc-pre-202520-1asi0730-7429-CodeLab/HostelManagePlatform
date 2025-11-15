namespace HostelManagerPlatform.API.Hotels.Interfaces.REST.Resource;

public record CreateHotelResource(
    string Name, 
    string Imagen, 
    string Address, 
    string Phone,
    int? UsersId);