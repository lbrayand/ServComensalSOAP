namespace ServiceSOAP
{
    using System.Collections.Generic;
    using System.Web.Services;
    using Comensal.Entidad;
    using Comensal.Negocio;

    /// <summary>
    /// Descripción breve de ComensalSOAP
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ComensalSOAP : System.Web.Services.WebService
    {
        [WebMethod]
        public List<beLocal> listarLocales()
        {
            var oblLocal = new blLocal();
            return oblLocal.listarLocales();
        }

        [WebMethod]
        public string registrarLocal(string nombreLocal,
                              string dirección,
                              int numAforo,
                              int numPisos)
        {
            var obeLocal = new beLocal();
            obeLocal.nombreLocal = nombreLocal;
            obeLocal.direccion = dirección;
            obeLocal.numAforo = numAforo;
            obeLocal.numPisos = numPisos;

            var oblLocal = new blLocal();
            oblLocal.registrar(obeLocal);

            return "Registro de Local OK";
        }

        [WebMethod]
        public List<beMesa> listarMesas()
        {
            var oblMesa = new blMesa();
            return oblMesa.listarMesas();
        }

        [WebMethod]
        public string registrarMesa(string ubicacion,
                                    int numMesa,
                                    int numCapacidad)
        {
            var obeMesa = new beMesa();
            obeMesa.ubicacion = ubicacion;
            obeMesa.numMesa = numMesa;
            obeMesa.numCapacidad = numCapacidad;

            var oblMesa = new blMesa();
            oblMesa.registrar(obeMesa);

            return "Registro de Mesa OK";
        }

        [WebMethod]
        public string actualizarEstadoReserva(int idReserva,
                                           int idEstado)
        {
            var oblReserva = new blReserva();
            oblReserva.actualizarEstadoReserva(idReserva, idEstado);

            return "Se actualizó estado de Reserva";
        }
    }
}
