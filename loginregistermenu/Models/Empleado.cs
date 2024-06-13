namespace loginregistermenu.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        public int PersonaID { get; set; }
        public Persona Persona { get; set; } = new Persona();
        public int PuestoID { get; set; }
        public Puesto_Empleado Puesto { get; set; } = new Puesto_Empleado();
    }
}
