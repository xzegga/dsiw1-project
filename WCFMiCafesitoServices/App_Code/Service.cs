using MiCafesito;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class Service :
    IUserService,
    ICategoryService,
    IProductService,
    IOrderService,
    IOrderDetailsService,
    ICartService
{
    public readonly IUserService _userService;
    public readonly ICategoryService _categoryService;
    public readonly IProductService _productService;
    public readonly IOrderService _orderService;
    public readonly IOrderDetailsService _orderDetailsService;
    public readonly ICartService _cartService;

    public Service()
    {
        _userService = new UserService();
        _categoryService = new CategoryService();
        _productService = new ProductsService();
        _orderService = new OrderService();
        _orderDetailsService = new ProductDetailService();
        _cartService = new CartService();

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

    public List<Product> GetAllProducts()
    {
        return _productService.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        return _productService.GetProductById(id);
    }

    public void UpdateProduct(Product productos)
    {
        _productService.UpdateProduct(productos);
    }

    public void DeleteProduct(int id)
    {
        _productService.DeleteProduct(id);
    }

    public void AddProduct(Product productos)
    {
        _productService.AddProduct(productos);
    }

    public List<Product> GetAllProductsByCategoryId(int id)
    {
        return _productService.GetAllProductsByCategoryId(id);
    }

    public List<Product> GetProductsFeatured()
    {
        return _productService.GetProductsFeatured();
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

    #region Cart Administration Methods

    public void AddCartItem(Cart cart)
    {
        _cartService.AddCartItem(cart);
    }

    public void DeleteCartItem(int id)
    {
        _cartService.DeleteCartItem(id);
    }

    public void DeleteCartItemsByUserId(int id)
    {
        _cartService.DeleteCartItemsByUserId(id);
    }

    public List<Cart> GetCartItemsByUserId(int id)
    {
        return _cartService.GetCartItemsByUserId(id);
    }

    public void UpdateCartItemById(int id, int quantity, double unitprice)
    {
        _cartService.UpdateCartItemById(id, quantity, unitprice);
    }

    #endregion
}

