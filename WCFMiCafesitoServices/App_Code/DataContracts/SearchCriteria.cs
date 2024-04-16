using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

[DataContract]
public class SearchCriteria
{
    [DataMember]
    public CriteriaType Criteria { get; set; }

    [DataMember]
    public string Value { get; set; }
}

public enum CriteriaType
{
    Id,
    Email,
    Name,
    Estatus,
    Role
}