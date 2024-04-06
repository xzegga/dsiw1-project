using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

public class Service : IService
{
    private CustomConfigurationManager _config;

    public Service()
    {
        _config = new CustomConfigurationManager();
        string c = _config.ConnectionString;
    }

    public void GetData()
    {
        string c = _config.ConnectionString;
    }

    public CompositeType GetDataUsingDataContract(CompositeType composite)
    {
        throw new NotImplementedException();
    }
}
