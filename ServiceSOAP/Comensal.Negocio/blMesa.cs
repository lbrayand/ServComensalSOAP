namespace Comensal.Negocio
{
    using System.Collections.Generic;
    using Comensal.Entidad;
    using Comensal.Datos;

    public class blMesa
    {
        public List<beMesa> listarMesas()
        {
            var odaMesa = new daMesa();
            return odaMesa.listarMesas();
        }

        public void registrar(beMesa obeMesa)
        {
            var odaMesa = new daMesa();
            odaMesa.registrar(obeMesa);
        }
    }
}
