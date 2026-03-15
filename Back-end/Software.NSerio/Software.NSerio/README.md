📌 Backend - Prueba Técnica .NET (Arquitectura DDD)

Este proyecto corresponde al desarrollo del Backend en .NET 8, implementando Domain Driven Design (DDD) y aplicando buenas prácticas de arquitectura limpia, separación de responsabilidades y mantenibilidad del código.

El objetivo principal fue construir una API escalable, desacoplada y preparada para futuras implementaciones como seguridad, auditoría y validaciones avanzadas.

🏗️ Arquitectura utilizada

Se implementó una arquitectura basada en DDD (Domain Driven Design) separando el proyecto en múltiples capas:

Domain

Application / Services

Infrastructure

Shared

API

UnitTest

Esta estructura permite un alto nivel de mantenibilidad, testeo y escalabilidad.

⚙️ Services Application / Inyección de Dependencias

Se implementó un módulo de configuración para la inyección de dependencias:

ddInfrastructure(this IServiceCollection services, IConfiguration configuration)

Este módulo centraliza el registro de:

Repositorios

Servicios

DbContext

Configuraciones de infraestructura

Permitiendo desacoplar las dependencias entre capas.

📦 Uso de DTOs y Mapeos

Se utilizaron DTOs (Data Transfer Objects) para el retorno de información hacia el frontend.

Beneficios:

Reducir el tamaño de los objetos

Evitar exposición de entidades de dominio

Mejorar seguridad de datos

Optimizar rendimiento

Se implementaron mapeos en tiempo de ejecución para convertir entidades a DTOs y viceversa.

🗄️ Capa Infrastructure

La capa de infraestructura actúa como el núcleo de acceso a datos.

Características:

Conexión a SQL Server

Uso de Entity Framework Core

Configuración mediante carpeta Persistence

Mapeo de entidades y tipos de datos

Validaciones de columnas

Uso de Stored Procedures y Views

Implementación de Repositories

Soporte para DML y DDL

También se dejó preparada la implementación de:

Interceptores para auditoría

Registro de cambios en base de datos

Auditoría en tiempo real (no implementada pero preparada)

🔐 Seguridad

Aunque la prueba no requería autenticación, el proyecto quedó preparado para:

Implementación futura de JWT

Encriptación de datos

Manejo seguro de sesiones

Uso de librerías de seguridad mediante NuGet

🧠 Capa Domain

En la capa Domain se definió la lógica principal del negocio.

Se implementaron:

Entidades

Clases abstractas en Common

Herencia y abstracción (POO)

Rules para validaciones de negocio

ValueObjects para validaciones específicas

Email

Campos obligatorios

Reglas de dominio

Esto permite mantener la lógica desacoplada de la infraestructura.

🔄 Capa Shared

La capa Shared contiene modelos comunes utilizados en todo el proyecto.

Incluye:

Modelos de respuesta

Estructuras estándar para API

Manejo de errores

Objetos compartidos

También se implementó un Middleware global de excepciones para evitar el uso excesivo de try / catch.

Beneficios:

Manejo centralizado de errores

Código más limpio

Mejor mantenimiento

🧪 Pruebas Unitarias

Se implementó una capa de UnitTest para validar la lógica de negocio.

Características:

Pruebas sobre la capa Domain

Pruebas de repositorios

Pruebas de inserción en base de datos

Validación de reglas de negocio

Verificación de comportamiento esperado

Todas las reglas de negocio fueron verificadas mediante pruebas unitarias.

🛠️ Tecnologías usadas

.NET 8

Entity Framework Core

SQL Server

DDD

Clean Architecture

Dependency Injection

Middleware

Unit Testing

LINQ

DTO Pattern

Repository Pattern