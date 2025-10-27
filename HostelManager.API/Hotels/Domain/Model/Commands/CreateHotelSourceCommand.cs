namespace HostelManager.API.Hotels.Domain.Model.Commands;

public record CreateHotelSourceCommand(
    int? Id, 
    string Name, 
    string Imagen, 
    string Address, 
    string Phone, 
    int? UsersId
    );