namespace Application.DTOs.Pet;

public class PetRegisterDto
{
    public string Name { get; set; }
    public string Species { get; set; }
    public string Breed { get; set; }
    public DateOnly BirthDate { get; set; }
    public string Gender { get; set; }
    //Aqui por ejemploo hare la relacion de veterinarios
    //de aqui cargarian los veterinarios actual de la cuenta 
    //Ojito cambiar 
    public List<int> VeterinarianIds { get; set; } = new();    //aqui otro caso de uso que podemos 
    //contemplar debe existir dos due;o, necesito encontrar una forma de de 
    //de vincular dicha mascota POR AHORA 
    //Solo me abstendre de poner el id 
    //lo recomendable es de tener una especie de  placeholder
    public int OwnerId { get; set; }
    
}