USE [MiCafesitoEnlinea]
GO
/****** Object:  UserDefinedTableType [dbo].[CartDetailType]    Script Date: 5/20/2024 11:48:54 PM ******/
CREATE TYPE [dbo].[CartDetailType] AS TABLE(
	[ID_Producto] [int] NULL,
	[Cantidad] [int] NULL,
	[PrecioUnitario] [float] NULL
)
GO
/****** Object:  Table [dbo].[Carrito]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Carrito](
	[ID_Carrito] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NOT NULL,
	[ID_Producto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Carrito] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorias]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorias](
	[ID_Categoria] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
	[Descripcion] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Categoria] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesPedidos]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesPedidos](
	[ID_Detalle] [int] IDENTITY(1,1) NOT NULL,
	[ID_Pedido] [int] NULL,
	[ID_Producto] [int] NULL,
	[Cantidad] [int] NULL,
	[PrecioUnitario] [decimal](10, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Detalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[ID_Pedido] [int] IDENTITY(1,1) NOT NULL,
	[ID_Usuario] [int] NULL,
	[FechaPedido] [datetime] NULL,
	[Estado] [varchar](20) NULL,
	[Factura] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Pedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[ID_Producto] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](100) NOT NULL,
	[Descripcion] [varchar](255) NULL,
	[Precio] [decimal](10, 2) NOT NULL,
	[ID_Categoria] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Destacado] [bit] NOT NULL,
	[ImageUrl] [nvarchar](255) NULL,
 CONSTRAINT [PK__Producto__9B4120E2053AA4FC] PRIMARY KEY CLUSTERED 
(
	[ID_Producto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ID_Rol] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Rol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[ID_Usuario] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Fecha_Nacimiento] [date] NULL,
	[Email] [varchar](100) NOT NULL,
	[Password] [varbinary](500) NULL,
	[Telefono] [varbinary](500) NULL,
	[Estado] [char](1) NOT NULL,
	[Fecha_Registro] [datetime] NOT NULL,
	[ID_Rol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[ID_Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY],
UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT (getdate()) FOR [FechaPedido]
GO
ALTER TABLE [dbo].[Pedidos] ADD  DEFAULT ('Pendiente') FOR [Estado]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF__Productos__Estad__403A8C7D]  DEFAULT ((1)) FOR [Estado]
GO
ALTER TABLE [dbo].[Productos] ADD  CONSTRAINT [DF_Productos_Destacado]  DEFAULT ((0)) FOR [Destacado]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT (getdate()) FOR [Fecha_Registro]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Producto] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Productos] ([ID_Producto])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Producto]
GO
ALTER TABLE [dbo].[Carrito]  WITH CHECK ADD  CONSTRAINT [FK_Carrito_Usuarios] FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Carrito] CHECK CONSTRAINT [FK_Carrito_Usuarios]
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD FOREIGN KEY([ID_Pedido])
REFERENCES [dbo].[Pedidos] ([ID_Pedido])
GO
ALTER TABLE [dbo].[DetallesPedidos]  WITH CHECK ADD  CONSTRAINT [FK__DetallesP__ID_Pr__49C3F6B7] FOREIGN KEY([ID_Producto])
REFERENCES [dbo].[Productos] ([ID_Producto])
GO
ALTER TABLE [dbo].[DetallesPedidos] CHECK CONSTRAINT [FK__DetallesP__ID_Pr__49C3F6B7]
GO
ALTER TABLE [dbo].[Pedidos]  WITH CHECK ADD FOREIGN KEY([ID_Usuario])
REFERENCES [dbo].[Usuarios] ([ID_Usuario])
GO
ALTER TABLE [dbo].[Productos]  WITH CHECK ADD  CONSTRAINT [FK__Productos__ID_Ca__412EB0B6] FOREIGN KEY([ID_Categoria])
REFERENCES [dbo].[Categorias] ([ID_Categoria])
GO
ALTER TABLE [dbo].[Productos] CHECK CONSTRAINT [FK__Productos__ID_Ca__412EB0B6]
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([ID_Rol])
REFERENCES [dbo].[Roles] ([ID_Rol])
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarCarrito]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarCarrito]
    @ID_Carrito INT,
    @Cantidad INT,
    @PrecioUnitario FLOAT
AS
BEGIN
    BEGIN TRY
        UPDATE dbo.Carrito
        SET 
            Cantidad = @Cantidad,
            PrecioUnitario = @PrecioUnitario
        WHERE 
            ID_Carrito = @ID_Carrito;
    END TRY
    BEGIN CATCH
        THROW 51000, 'Error al actualizar el item seleccionado', 1;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarCategoria]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para actualizar los detalles de una categoría existente
CREATE PROCEDURE [dbo].[SP_ActualizarCategoria]
    @ID_Categoria INT,
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    UPDATE Categorias
    SET Nombre = @Nombre,
        Descripcion = @Descripcion
    WHERE ID_Categoria = @ID_Categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarDetallePedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para actualizar los detalles de un detalle de pedido existente
CREATE PROCEDURE [dbo].[SP_ActualizarDetallePedido]
    @ID_Detalle INT,
    @ID_Pedido INT,
    @ID_Producto INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(10, 2)
AS
BEGIN
    UPDATE DetallesPedidos
    SET ID_Pedido = @ID_Pedido,
        ID_Producto = @ID_Producto,
        Cantidad = @Cantidad,
        PrecioUnitario = @PrecioUnitario
    WHERE ID_Detalle = @ID_Detalle;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarItemCarritoCantidad]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ActualizarItemCarritoCantidad]
    @ID_Carrito INT,
    @Cantidad INT
AS
BEGIN
    BEGIN TRY
        UPDATE dbo.Carrito
        SET 
            Cantidad = @Cantidad
        WHERE 
            ID_Carrito = @ID_Carrito;
    END TRY
    BEGIN CATCH
        THROW 51000, 'Error al actualizar el item seleccionado', 1;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para actualizar los detalles de un pedido existente
CREATE PROCEDURE [dbo].[SP_ActualizarPedido]
    @ID_Pedido INT,
    @ID_Usuario INT,
    @Factura VARCHAR(50)
AS
BEGIN
    UPDATE Pedidos
    SET ID_Usuario = @ID_Usuario,
        Factura = @Factura
    WHERE ID_Pedido = @ID_Pedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarProducto]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

	
-- SP para actualizar los detalles de un producto existente
CREATE PROCEDURE [dbo].[SP_ActualizarProducto]
    @ID_Producto INT,
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(255),
    @Precio DECIMAL(10, 2),
    @ID_Categoria INT,
	@Image_URL VARCHAR(255)
AS
BEGIN
    UPDATE Productos
    SET Nombre = @Nombre,
        Descripcion = @Descripcion,
        Precio = @Precio,
        ID_Categoria = @ID_Categoria,
		ImageUrl = @Image_URL
    WHERE ID_Producto = @ID_Producto;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarRol]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para actualizar los detalles de un rol existente
CREATE PROCEDURE [dbo].[SP_ActualizarRol]
    @ID_Rol INT,
    @Nombre VARCHAR(50)
AS
BEGIN
    UPDATE Roles
    SET Nombre = @Nombre
    WHERE ID_Rol = @ID_Rol;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ActualizarUsuario]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ActualizarUsuario] 
@ID_Usuario INT,
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(50),
    @FechaNacimiento DATE,
    @Telefono VARCHAR(25),
	@Estado CHAR(1),
	@ID_Rol INT,
    @Patron VARCHAR(100)
AS
BEGIN
    DECLARE @TelefonoEncriptado VARBINARY(500);

    SET @TelefonoEncriptado = ENCRYPTBYPASSPHRASE(@Patron, @Telefono);

    UPDATE Usuarios 
    SET Nombre = @Nombre,
        Apellido = @Apellido,
        Fecha_Nacimiento = @FechaNacimiento,
        Telefono = @TelefonoEncriptado,
		ID_Rol = @ID_Rol,
		Estado = @Estado
    WHERE ID_Usuario = @ID_Usuario;

    IF @@ROWCOUNT > 0
        SELECT 1 AS Modificado;    -- Indicar que se realizó la modificación
    ELSE
        SELECT 0 AS Modificado;    -- Indicar que no se encontró el usuario para modificar
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_BuscarProductoPorAtributo]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- Busqueda de productos por nombre, descripcion, precio y/o categoría
CREATE PROCEDURE [dbo].[SP_BuscarProductoPorAtributo]
    @CriterioBusqueda VARCHAR(100),
    @TipoBusqueda VARCHAR(20)
AS
BEGIN
    IF @TipoBusqueda = 'Nombre'  -- Si se busca por nombre
    BEGIN
        SELECT * FROM Productos WHERE Nombre LIKE '%' + @CriterioBusqueda + '%';
    END
    ELSE IF @TipoBusqueda = 'Descripcion'  -- Si se busca por descripción
    BEGIN
        SELECT * FROM Productos WHERE Descripcion LIKE '%' + @CriterioBusqueda + '%';
    END
    ELSE IF @TipoBusqueda = 'Precio'  -- Si se busca por precio
    BEGIN
        SELECT * FROM Productos WHERE Precio = CAST(@CriterioBusqueda AS DECIMAL(10, 2));
    END
    ELSE IF @TipoBusqueda = 'ID_Categoria'  -- Si se busca por ID de categoría
    BEGIN
        SELECT * FROM Productos WHERE ID_Categoria = CAST(@CriterioBusqueda AS INT);
    END
    ELSE
    BEGIN
        RAISERROR ('Tipo de búsqueda no válido.', 16, 1);
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_CrearUsuario]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para insertar usuario
CREATE PROCEDURE [dbo].[SP_CrearUsuario]
	@Nombre VARCHAR(50),
	@Apellido VARCHAR(50),
	@FechaNacimiento DATE,
	@Email VARCHAR(100),
	@Password VARCHAR(25),
	@Telefono VARCHAR(25),
	@Estado CHAR(1),
	@ID_Rol INT,
	@Patron VARCHAR(100)
AS
BEGIN
	DECLARE @PasswordEncriptado VARBINARY(500);
	DECLARE @TelefonoEncriptado VARBINARY(500);
	DECLARE @new_id INT;
		
	SET @PasswordEncriptado = ENCRYPTBYPASSPHRASE(@Patron, @Password);
	SET @TelefonoEncriptado = ENCRYPTBYPASSPHRASE(@Patron, @Telefono);

	INSERT INTO Usuarios (Nombre, Apellido, Fecha_Nacimiento, Email, Password, Telefono, ID_Rol, Estado)
	VALUES (
		@Nombre, 
		@Apellido,
		@FechaNacimiento, 
		@Email, 
		@PasswordEncriptado, 
		@TelefonoEncriptado,
		@ID_Rol,
		@Estado
	);

	SET @new_id = SCOPE_IDENTITY();
		
	IF @new_id IS NOT NULL
		SELECT @new_id AS ID_Usuario;			
	ELSE
		SELECT 0 AS ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCarrito]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EliminarCarrito]
    @ID_Carrito INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM dbo.Carrito
        WHERE ID_Carrito = @ID_Carrito;
    END TRY
    BEGIN CATCH
        -- Handle errors
        THROW 51000, 'Error al eliminar el item seleccionado', 1;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCarritoByUserID]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_EliminarCarritoByUserID]
    @ID_Usuario INT
AS
BEGIN
    BEGIN TRY
        DELETE FROM dbo.Carrito
        WHERE ID_Usuario = @ID_Usuario;
    END TRY
    BEGIN CATCH
        THROW 51000, 'Error al vaciar el carrito de compras', 1;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarCategoria]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para eliminar una categoría por su ID
CREATE PROCEDURE [dbo].[SP_EliminarCategoria]
    @ID_Categoria INT
AS
BEGIN
    DELETE FROM Categorias 
    WHERE ID_Categoria = @ID_Categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarDetallePedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para eliminar un detalle de pedido por su ID
CREATE PROCEDURE [dbo].[SP_EliminarDetallePedido]
    @ID_Detalle INT
AS
BEGIN
    DELETE FROM DetallesPedidos 
    WHERE ID_Detalle = @ID_Detalle;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarDetallesPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarDetallesPedido]
(
    @ID_Pedido INT
)
AS
BEGIN
    SET NOCOUNT ON;

    -- Borrar los detalles del pedido
    DELETE FROM DetallesPedidos
    WHERE ID_Pedido = @ID_Pedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para eliminar un pedido y sus detalles asociados por su ID
CREATE PROCEDURE [dbo].[SP_EliminarPedido]
    @ID_Pedido INT
AS
BEGIN
    BEGIN TRANSACTION; -- Inicia una transacción

    -- Eliminar detalles de pedido asociados al pedido
    DELETE FROM DetallesPedidos 
    WHERE ID_Pedido = @ID_Pedido;

    -- Eliminar el pedido
    DELETE FROM Pedidos 
    WHERE ID_Pedido = @ID_Pedido;

    COMMIT; -- Confirma la transacción
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarProducto]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para eliminar un producto por su ID
CREATE PROCEDURE [dbo].[SP_EliminarProducto]
    @ID_Producto INT
AS
BEGIN
    DELETE FROM Productos 
    WHERE ID_Producto = @ID_Producto;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarRol]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para eliminar un rol por su ID
CREATE PROCEDURE [dbo].[SP_EliminarRol]
    @ID_Rol INT
AS
BEGIN
    DELETE FROM Roles 
    WHERE ID_Rol = @ID_Rol;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_EliminarUsuario]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_EliminarUsuario]
    @ID_Usuario INT
AS
BEGIN
    DELETE FROM Usuarios 
    WHERE ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarCarrito]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[SP_InsertarCarrito]
    @ID_Usuario INT,
    @ID_Producto INT,
    @Cantidad INT,
    @PrecioUnitario FLOAT
AS
BEGIN
    BEGIN TRY
        INSERT INTO dbo.Carrito (ID_Usuario, ID_Producto, Cantidad, PrecioUnitario)
        VALUES (@ID_Usuario, @ID_Producto, @Cantidad, @PrecioUnitario);
    END TRY
    BEGIN CATCH
        -- Handle errors

        THROW 51000, 'Error al agregar el item al carrito', 1;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarCategoria]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- CATEGORIAS
-- SP para insertar una nueva categoría
CREATE PROCEDURE [dbo].[SP_InsertarCategoria]
    @Nombre VARCHAR(50),
    @Descripcion VARCHAR(100)
AS
BEGIN
    INSERT INTO Categorias (Nombre, Descripcion)
    VALUES (@Nombre, @Descripcion);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarDetallePedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para insertar un nuevo detalle de pedido
CREATE PROCEDURE [dbo].[SP_InsertarDetallePedido]
    @ID_Pedido INT,
    @ID_Producto INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(10, 2)
AS
BEGIN
    INSERT INTO DetallesPedidos (ID_Pedido, ID_Producto, Cantidad, PrecioUnitario)
    VALUES (@ID_Pedido, @ID_Producto, @Cantidad, @PrecioUnitario);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PEDIDOS

-- SP para insertar un nuevo pedido
CREATE PROCEDURE [dbo].[SP_InsertarPedido]
    @ID_Usuario INT,
    @Factura VARCHAR(50)
AS
BEGIN
    INSERT INTO Pedidos (ID_Usuario, Factura)
    VALUES (@ID_Usuario, @Factura);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarProducto]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- PRODUCTOS
-- SP para insertar un nuevo producto
CREATE PROCEDURE [dbo].[SP_InsertarProducto]
    @Nombre VARCHAR(100),
    @Descripcion VARCHAR(255),
    @Precio DECIMAL(10, 2),
    @ID_Categoria INT,
	@Image_URL VARCHAR(255)
AS
BEGIN
    INSERT INTO Productos (Nombre, Descripcion, Precio, ID_Categoria, ImageUrl)
    VALUES (@Nombre, @Descripcion, @Precio, @ID_Categoria, @Image_URL);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertarRol]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- SP para insertar un nuevo rol
CREATE PROCEDURE [dbo].[SP_InsertarRol]
    @Nombre VARCHAR(50)
AS
BEGIN
    INSERT INTO Roles (Nombre)
    VALUES (@Nombre);
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_LeerUsuario]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para leer usuario
CREATE PROCEDURE [dbo].[SP_LeerUsuario]
    @ID_Usuario INT,
    @Patron VARCHAR(100)
AS
BEGIN
    SELECT 
        u.ID_Usuario,
        u.Nombre,
        u.Apellido,
        u.Fecha_Nacimiento,
        u.Email,
		CONVERT(VARCHAR(25), DECRYPTBYPASSPHRASE(@Patron, u.Telefono)) AS Telefono,
		u.ID_Rol,
		r.Nombre,
        u.Estado,
        u.Fecha_Registro
    FROM 
        Usuarios as u
		Inner join dbo.Roles as r on u.ID_Rol = r.ID_rol
    WHERE 
        ID_Usuario = @ID_Usuario;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCarritoByUserID]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ListarCarritoByUserID]
    @ID_Usuario INT
AS
BEGIN
    SELECT 
        ID_Carrito,
        ID_Usuario,
        ID_Producto,
        Cantidad,
        PrecioUnitario
    FROM 
        dbo.Carrito
    WHERE 
        ID_Usuario = @ID_Usuario;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarCategorias]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todas las categorías
CREATE PROCEDURE [dbo].[SP_ListarCategorias]
AS
BEGIN
    SELECT *
    FROM Categorias;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarDetallesPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los detalles de un pedido
CREATE PROCEDURE [dbo].[SP_ListarDetallesPedido]
    @ID_Pedido INT
AS
BEGIN
    SELECT *
    FROM DetallesPedidos
    WHERE ID_Pedido = @ID_Pedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarPedidos]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarPedidos]
AS
BEGIN
    SELECT *
    FROM Pedidos
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarPedidosByUserID]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los productos
CREATE PROCEDURE [dbo].[SP_ListarPedidosByUserID]
 @ID_Usuario INT
AS
BEGIN
    SELECT *
    FROM Pedidos
	WHERE ID_Usuario = @ID_Usuario
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarProductos]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los productos
CREATE PROCEDURE [dbo].[SP_ListarProductos]
AS
BEGIN
    SELECT *
    FROM Productos;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarProductosByCategoryID]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los productos
CREATE PROCEDURE [dbo].[SP_ListarProductosByCategoryID]
	@ID_Categoria INT
AS
BEGIN
    SELECT *
    FROM Productos
	WHERE ID_Categoria = @ID_Categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarProductosDestacados]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los productos
CREATE PROCEDURE [dbo].[SP_ListarProductosDestacados]
AS
BEGIN
    SELECT *
    FROM Productos
	WHERE Destacado = 1;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarRoles]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para listar todos los roles
CREATE PROCEDURE [dbo].[SP_ListarRoles]
AS
BEGIN
    SELECT *
    FROM Roles;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ListarUsuarios]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_ListarUsuarios]
    @Patron VARCHAR(100)
AS
BEGIN
    SET NOCOUNT ON;

    SELECT 
        u.ID_Usuario,
        u.Nombre,
        u.Apellido,
        u.Fecha_Nacimiento,
        u.Email,
		CONVERT(VARCHAR(25), DECRYPTBYPASSPHRASE(@Patron, u.Telefono)) AS Telefono,
		u.ID_Rol,
		r.Nombre as NombreRole,
        u.Estado,
        u.Fecha_Registro
     FROM 
        dbo.Usuarios as u
		Inner join dbo.Roles as r on u.ID_Rol = r.ID_rol

END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerCategoria]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para obtener los detalles de una categoría por su ID
CREATE PROCEDURE [dbo].[SP_ObtenerCategoria]
    @ID_Categoria INT
AS
BEGIN
    SELECT * 
    FROM Categorias 
    WHERE ID_Categoria = @ID_Categoria;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerPedido]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para obtener los detalles de un pedido por su ID
CREATE PROCEDURE [dbo].[SP_ObtenerPedido]
    @ID_Pedido INT
AS
BEGIN
    SELECT * 
    FROM Pedidos 
    WHERE ID_Pedido = @ID_Pedido;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerProducto]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para obtener los detalles de un producto por su ID
CREATE PROCEDURE [dbo].[SP_ObtenerProducto]
    @ID_Producto INT
AS
BEGIN
    SELECT * 
    FROM Productos 
    WHERE ID_Producto = @ID_Producto;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ObtenerRol]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para obtener los detalles de un rol por su ID
CREATE PROCEDURE [dbo].[SP_ObtenerRol]
    @ID_Rol INT
AS
BEGIN
    SELECT * 
    FROM Roles 
    WHERE ID_Rol = @ID_Rol;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ResetearContrasena]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para resetear contraseña
CREATE PROCEDURE [dbo].[SP_ResetearContrasena]
    @Email VARCHAR(100),
    @PasswordActual VARCHAR(25),
    @NuevaContrasena VARCHAR(25),
    @VerificarContrasena VARCHAR(25),
    @Patron VARCHAR(100)
AS
BEGIN
	DECLARE @ID_Usuario INT;
	IF @NuevaContrasena = @VerificarContrasena
		BEGIN
			SELECT @ID_Usuario = ID_Usuario
			FROM Usuarios
			WHERE Email = @Email AND CONVERT(VARCHAR(100), DECRYPTBYPASSPHRASE(@Patron, Password)) = @PasswordActual;
    
			IF @ID_Usuario IS NOT NULL
				BEGIN
					DECLARE @NuevaContrasenaEncriptada VARBINARY(500);
					SET @NuevaContrasenaEncriptada = ENCRYPTBYPASSPHRASE(@Patron, @NuevaContrasena);

					UPDATE Usuarios
					SET Password = @NuevaContrasenaEncriptada
					WHERE ID_Usuario = @ID_Usuario;

					SELECT 'Contraseña actualizada exitosamente.' AS message, 'exito' as tipo;
				END
		ELSE
			BEGIN
				SELECT 'Las contraseñas no coinciden.' AS message, 'error' as tipo; 
			END;
		END
	ELSE
		BEGIN 
			SELECT 'Contraseña actual inválida.' AS message, 'error' as tipo;
		END;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_ValidarUsuario]    Script Date: 5/20/2024 11:48:54 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- SP para validar usuario
CREATE PROCEDURE [dbo].[SP_ValidarUsuario]
	@Email VARCHAR(100),
	@Password VARCHAR(25),
	@Patron VARCHAR(100)
AS
BEGIN
    DECLARE @ID_Usuario INT;

    SELECT @ID_Usuario = ID_Usuario
	FROM Usuarios
    WHERE Email = @Email AND CONVERT(VARCHAR(25), DECRYPTBYPASSPHRASE(@Patron, Password)) = @Password;

    IF @ID_Usuario IS NOT NULL
		BEGIN
			SELECT @ID_Usuario AS ID_Usuario;
		END
    ELSE
		BEGIN
			SELECT 0 AS ID_Usuario;
		END;
END;
GO
