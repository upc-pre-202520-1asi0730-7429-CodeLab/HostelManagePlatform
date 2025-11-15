namespace HostelManagerPlatform.API.Hotels.Domain.Model.Commands;

public record CreateHotelCommand(
    int? Id, 
    string Name, 
    string Imagen, 
    string Address, 
    string Phone, 
    int? UsersId);