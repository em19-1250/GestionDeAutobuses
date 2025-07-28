namespace GestionAutobusesAPI.Models
{
    public class Horario
    {
        public int Id { get; set; }
        public int AutobusId { get; set; }
        public int RutaId { get; set; }
        public DateTime FechaHoraSalida { get; set; }
        public DateTime FechaHoraLlegada { get; set; }
    }
}
