using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MiCafesito
{
    [ServiceContract]
    public interface IRolesService
    {
        [OperationContract]
        List<Role> GetAllRoles();
    }
}