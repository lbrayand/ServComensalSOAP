namespace Comensal.Negocio
{    
    using System.Collections.Generic;
    using Comensal.Entidad;
    using Comensal.Datos;
    public class blLocal
    {
        public List<beLocal> listarLocales()
        {
            var odaLocal = new daLocal();
            return odaLocal.listarLocales();
        }

        public void registrar(beLocal obeLocal)
        {
            var odalocal = new daLocal();
            odalocal.registrar(obeLocal);
        }
    }
}
