namespace Comensal.Negocio
{
    using Comensal.Datos;

    public class blReserva
    {
        public void actualizarEstadoReserva(int idReserva,
                                            int idEstado)
        {
            var odaReserva = new daReserva();
            odaReserva.actualizarEstadoReserva(idReserva,idEstado);
        }
    }
}
