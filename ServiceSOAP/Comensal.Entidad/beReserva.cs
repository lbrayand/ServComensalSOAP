namespace Comensal.Entidad
{
    using System;
    public class beReserva
    {
        public int idReserva { get; set; }
        public int idLocal { get; set; }
        public int idMesa { get; set; }
        public DateTime fechaReserva { get; set; }
        public int idMotivo { get; set; }
    }
}
