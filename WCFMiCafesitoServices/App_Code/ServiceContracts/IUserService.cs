using System;
using System.Collections.Generic;
using System.ServiceModel;

[ServiceContract]
public interface IUserService
{
    [OperationContract]
    List<User> GetAllUsers();

    [OperationContract]
    User GetUserById(int id);

    [OperationContract]
    int Login(string email, string password);

    [OperationContract]
    void UpdateUser(User user);

    [OperationContract]
    void DeleteUser(int id);

    [OperationContract]
    void AddUser(User user);

    [OperationContract]
    void ResetPassword(string email, string password, string newPassword, string confirmPassword);

}
