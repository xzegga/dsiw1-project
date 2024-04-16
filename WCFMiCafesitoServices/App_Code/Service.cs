using System;
using System.Collections.Generic;
using System.Data;


public class Service : IUserService
{
    public readonly IUserService _userService;

    public Service()
    {
        _userService = new UserService();
    }

    #region User Administration Methods

    public void AddUser(User user)
    {
        _userService.AddUser(user);
    }

    public void DeleteUser(int id)
    {
        _userService.DeleteUser(id);
    }

    public List<User> GetAllUsers()
    {
        return _userService.GetAllUsers();
    }

    public User GetUserById(int id)
    {
        return _userService.GetUserById(id);
    }

    public int Login(string user, string password)
    {
        return _userService.Login(user, password);
    }

    public void ResetPassword(string email, string password, string newPassword, string confirmPassword)
    {
        _userService.ResetPassword(email, password, newPassword, confirmPassword);
    }

    public void UpdateUser(User user)
    {
        _userService.UpdateUser(user);
    }

    #endregion
}
