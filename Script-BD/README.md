📌 Base de Datos - SQL Server

Para el proyecto se diseñó una base de datos en SQL Server, aplicando buenas prácticas de modelado, integridad de datos y optimización de consultas, pensando en la escalabilidad y mantenibilidad futura del sistema.

El diseño fue realizado considerando rendimiento, seguridad y reutilización de estructuras.

🗄️ Creación de tablas

Se crearon tablas con sus respectivas validaciones y restricciones:

Definición de tipos de datos adecuados

Uso de Primary Keys (PK) para garantizar unicidad

Uso de Foreign Keys (FK) para mantener integridad referencial

Uso de CHECK constraints para validaciones de datos

Restricciones NOT NULL cuando aplica

Normalización de datos

También se crearon tablas genéricas para ser reutilizadas desde el aplicativo.

Ejemplo:

Tablas de estados

Tablas de tipos

Tablas de parámetros

Esto permite mayor flexibilidad y menor duplicidad de información.

👁️ Vistas (Views)

Se implementaron vistas en SQL Server para simplificar consultas complejas.

Características:

Uso de JOIN entre múltiples tablas

Optimización de lectura de datos

Consultas reutilizables

Mejor organización de la lógica SQL

Las vistas permiten que el backend consuma información ya estructurada.

⚙️ Procedimientos almacenados

Se crearon Stored Procedures para manejar operaciones complejas.

Características:

Procedimientos con múltiples resultados

Ejecución de varias consultas en una sola llamada

Mejor rendimiento

Mayor control sobre la lógica de base de datos

Esto reduce la carga en el backend y mejora la eficiencia.

🔄 Transacciones

Se implementaron transacciones en operaciones INSERT y UPDATE para garantizar consistencia de datos.

Validaciones aplicadas:

Validaciones antes de insertar

Validaciones después de ejecutar

Control de errores

Rollback en caso de fallo

Esto asegura integridad y evita datos inconsistentes.

🔐 Integridad y buenas prácticas

Se aplicaron buenas prácticas en el diseño:

Uso correcto de índices

Relaciones bien definidas

Evitar duplicidad de datos

Consultas optimizadas

Preparación para crecimiento futuro

El diseño fue realizado pensando no solo en el funcionamiento actual, sino en la escalabilidad del sistema.

🛠️ Tecnologías usadas

SQL Server

Stored Procedures

Views

Constraints (PK, FK, CHECK)

Transactions

Query Optimization

Relational Modeling