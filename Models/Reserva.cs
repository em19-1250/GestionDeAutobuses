namespace GestionAutobusesAPI.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public string NombrePasajero { get; set; }
        public string Cedula { get; set; }
        public int HorarioId { get; set; }
        public DateTime FechaReserva { get; set; }
    }
}
