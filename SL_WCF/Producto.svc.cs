using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Producto : IProducto
    {

        public SL_WCF.Result GetAll()
        {
            ML.Result resultProducto = BL.Producto.GetAll();
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex, Objects = resultProducto.Objects };
        }

        public SL_WCF.Result Add(ML.Producto producto)
        {
            ML.Result resultProducto = BL.Producto.Add(producto);
            return new Result { Correct = resultProducto.Correct, ErrorMessage = resultProducto.ErrorMessage, Ex = resultProducto.Ex };
        }
    }

}
