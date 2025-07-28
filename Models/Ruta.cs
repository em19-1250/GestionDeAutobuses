namespace GestionAutobusesAPI.Models
{
    public class Ruta
    {
        public int Id { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public double DistanciaKm { get; set; }
    }
}
