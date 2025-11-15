namespace HostelManagerPlatform.API.Hotels.Interfaces.REST.Resource;

public record HotelResource(
    int Id, 
    string Name, 
    string Imagen, 
    string Address, 
    string Phone,
    int? UsersId);