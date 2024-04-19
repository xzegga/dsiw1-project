using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using MiCafesito;

public class Service : IUserService, ICategoryService, IProductService, IOrderService, IOrderDetailsService
{
    public readonly IUserService _userService;
    public readonly ICategoryService _categoryService;
    public readonly IProductService _productService;
    public readonly IOrderService _orderService;
    public readonly IOrderDetailsService _orderDetailsService;

    public Service()
    {
        _userService = new UserService();
        _categoryService = new CategoryService();
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

    #region Category Administration Methods

    public void AddCategory(Category category)
    {
        _categoryService.AddCategory(category);
    }
    public void DeleteCategory(int id)
    {
        _categoryService.DeleteCategory(id);
    }
    public List<Category> GetAllCategories()
    {
        return _categoryService.GetAllCategories();
    }

    public Category GetCategoryById(int id)
    {
        return _categoryService.GetCategoryById(id);
    }

    public void UpdateCategory(Category category)
    {
        _categoryService.UpdateCategory(category);
    }



    #endregion

    #region Product Administration Methods

    public List<Product> GetAllProduct()
    {
        return _productService.GetAllProduct();
    }

    public Product GetProductById(int id)
    {
        return _productService.GetProductById(id);
    }

    public void UpdateProduct(Product productos)
    {
        _productService.UpdateProduct(productos);
    }

    public void DeleteProducto(int id)
    {
        _productService.DeleteProducto(id);
    }

    public void AddProduct(Product productos)
    {
        _productService.AddProduct(productos);
    }

    #endregion

    #region Order Administration Methods

    public List<Order> GetAllOrders()
    {
        return _orderService.GetAllOrders();
    }

    public List<Order> GetAllOrdersByUserId(int id)
    {
        return _orderService.GetAllOrdersByUserId(id);
    }

    public Order GetOrderById(int id)
    {
        return _orderService.GetOrderById(id);
    }

    public void UpdateOrder(Order order)
    {
        _orderService.UpdateOrder(order);
    }

    public void DeleteOrder(int id)
    {
        _orderService.DeleteOrder(id);
    }

    public void AddOrder(Order order)
    {
        _orderService.AddOrder(order);
    }

    #endregion

    #region OrderDetails Administration Methods
 
    public List<OrderDetail> GetAllOrderDetailByOrderId(int id)
    {
        return _orderDetailsService.GetAllOrderDetailByOrderId(id);
    }

    public void UpdateOrderDetail(OrderDetail orderDetails)
    {
        _orderDetailsService.UpdateOrderDetail(orderDetails);
    }

    public void DeleteOrderDetail(int id)
    {
        _orderDetailsService.DeleteOrderDetail(id);
    }

    public void AddOrderDetail(OrderDetail orderDetails)
    {
        _orderDetailsService.AddOrderDetail(orderDetails);
    }

    public void DeleteOrderDetailByOrderId(int id)
    {
        _orderDetailsService.DeleteOrderDetailByOrderId(id);
    }
    #endregion
}
