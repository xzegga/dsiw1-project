-- Insertando productos en la categoría de Cafeteras de Espresso
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Cafeteras de espresso', 'Máquina de café para hacer espresso con sistema de bombeo y vaporizador de leche integrado.', 299.99, 3, 1);

-- Insertando productos en la categoría de Molinillos de Café
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Molinillos de café', 'Molinillo eléctrico para moler granos de café con diferentes niveles de molido.', 79.99, 4, 1);

-- Insertando productos en la categoría de Métodos de Infusión Directa
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Prensa Francesa', 'Cafetera de émbolo para preparar café de infusión directa con filtrado de prensa.', 24.99, 5, 1),
    ('Aeropress', 'Dispositivo de preparación de café de infusión directa que utiliza presión de aire.', 29.99, 5, 1),
    ('Moka Pot', 'Cafetera de aluminio para preparar café espresso en la estufa.', 34.99, 5, 1);

-- Insertando productos en la categoría de Métodos de Filtrado
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Chemex', 'Cafetera de vidrio con filtro de papel grueso para preparar café de sabor limpio.', 45.99, 6, 1),
    ('V60', 'Cono de goteo de cerámica con espirales internas para preparar café de filtro.', 19.99, 6, 1),
    ('Kalita Wave', 'Dripper de café de acero inoxidable con fondo plano y canales de extracción.', 29.99, 6, 1),
    ('Clever Dripper', 'Dripper de café con válvula de drenaje que permite el control del tiempo de extracción.', 24.99, 6, 1);

-- Insertando productos en la categoría de Otros Métodos Especiales
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Sifón de vacío (vac pot)', 'Método de preparación de café que utiliza vacío y presión para infusionar el café.', 69.99, 7, 1);

-- Insertando productos en la categoría de Accesorios
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Portafiltro', 'Dispositivo para sostener el filtro y el café molido en la preparación de espresso.', 15.99, 8, 1),
    ('Tamper', 'Herramienta para compactar uniformemente el café molido en el portafiltro.', 19.99, 8, 1),
    ('Jarra de leche (lechera)', 'Recipiente de acero inoxidable para calentar y espumar la leche.', 24.99, 8, 1),
    ('Termómetro para leche', 'Termómetro para medir la temperatura de la leche al vaporizarla.', 9.99, 8, 1),
    ('Báscula de precisión', 'Báscula digital precisa para medir la cantidad de café y agua.', 29.99, 8, 1),
    ('Cucharas dosificadoras', 'Cucharas medidoras para dosificar la cantidad de café.', 5.99, 8, 1),
    ('Cepillo de limpieza para molinillo', 'Cepillo especializado para limpiar el molinillo de café.', 7.99, 8, 1),
    ('Filtros de papel (para Chemex, V60, etc.)', 'Filtros de papel para métodos de filtrado como Chemex y V60.', 5.99, 8, 1),
    ('Cepillo de limpieza para cafetera de espresso', 'Cepillo diseñado para limpiar los residuos de café en la cafetera de espresso.', 6.99, 8, 1),
    ('Tazas y vasos para café', 'Tazas y vasos diseñados para servir café.', 12.99, 8, 1);

-- Insertando productos en la categoría de Insumos
INSERT INTO [dbo].[Productos] ([Nombre], [Descripcion], [Precio], [ID_Categoria], [Estado]) 
VALUES 
    ('Filtros de repuesto', 'Paquete de filtros de repuesto compatibles con múltiples métodos de preparación de café.', 8.99, 9, 1),
    ('Productos de limpieza para cafeteras y molinillos', 'Productos de limpieza especializados para mantener las cafeteras y los molinillos en óptimas condiciones.', 12.99, 9, 1);
