using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    
        [ServiceContract]
        public interface IProducto
        {
            [OperationContract]
            [ServiceKnownType(typeof(ML.Producto))]
            SL_WCF.Result GetAll();

            [OperationContract]
            SL_WCF.Result Add(ML.Producto producto);
    }

        


}
