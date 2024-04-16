using System.Runtime.Serialization;

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