-- Insertando productos en la categor�a de Cafeteras de Espresso
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Cafeteras de espresso', 'M�quina de caf� para hacer espresso con sistema de bombeo y vaporizador de leche integrado.', 299.99, 3, 1);

-- Insertando productos en la categor�a de Molinillos de Caf�
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Molinillos de caf�', 'Molinillo el�ctrico para moler granos de caf� con diferentes niveles de molido.', 79.99, 4, 1);

-- Insertando productos en la categor�a de M�todos de Infusi�n Directa
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Prensa Francesa', 'Cafetera de �mbolo para preparar caf� de infusi�n directa con filtrado de prensa.', 24.99, 5, 1),
    ('Aeropress', 'Dispositivo de preparaci�n de caf� de infusi�n directa que utiliza presi�n de aire.', 29.99, 5, 1),
    ('Moka Pot', 'Cafetera de aluminio para preparar caf� espresso en la estufa.', 34.99, 5, 1);

-- Insertando productos en la categor�a de M�todos de Filtrado
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Chemex', 'Cafetera de vidrio con filtro de papel grueso para preparar caf� de sabor limpio.', 45.99, 6, 1),
    ('V60', 'Cono de goteo de cer�mica con espirales internas para preparar caf� de filtro.', 19.99, 6, 1),
    ('Kalita Wave', 'Dripper de caf� de acero inoxidable con fondo plano y canales de extracci�n.', 29.99, 6, 1),
    ('Clever Dripper', 'Dripper de caf� con v�lvula de drenaje que permite el control del tiempo de extracci�n.', 24.99, 6, 1);

-- Insertando productos en la categor�a de Otros M�todos Especiales
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Sif�n de vac�o (vac pot)', 'M�todo de preparaci�n de caf� que utiliza vac�o y presi�n para infusionar el caf�.', 69.99, 7, 1);

-- Insertando productos en la categor�a de Accesorios
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Portafiltro', 'Dispositivo para sostener el filtro y el caf� molido en la preparaci�n de espresso.', 15.99, 8, 1),
    ('Tamper', 'Herramienta para compactar uniformemente el caf� molido en el portafiltro.', 19.99, 8, 1),
    ('Jarra de leche (lechera)', 'Recipiente de acero inoxidable para calentar y espumar la leche.', 24.99, 8, 1),
    ('Term�metro para leche', 'Term�metro para medir la temperatura de la leche al vaporizarla.', 9.99, 8, 1),
    ('B�scula de precisi�n', 'B�scula digital precisa para medir la cantidad de caf� y agua.', 29.99, 8, 1),
    ('Cucharas dosificadoras', 'Cucharas medidoras para dosificar la cantidad de caf�.', 5.99, 8, 1),
    ('Cepillo de limpieza para molinillo', 'Cepillo especializado para limpiar el molinillo de caf�.', 7.99, 8, 1),
    ('Filtros de papel (para Chemex, V60, etc.)', 'Filtros de papel para m�todos de filtrado como Chemex y V60.', 5.99, 8, 1),
    ('Cepillo de limpieza para cafetera de espresso', 'Cepillo dise�ado para limpiar los residuos de caf� en la cafetera de espresso.', 6.99, 8, 1),
    ('Tazas y vasos para caf�', 'Tazas y vasos dise�ados para servir caf�.', 12.99, 8, 1);

-- Insertando productos en la categor�a de Insumos
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Filtros de repuesto', 'Paquete de filtros de repuesto compatibles con m�ltiples m�todos de preparaci�n de caf�.', 8.99, 9, 1),
    ('Productos de limpieza para cafeteras y molinillos', 'Productos de limpieza especializados para mantener las cafeteras y los molinillos en �ptimas condiciones.', 12.99, 9, 1);
