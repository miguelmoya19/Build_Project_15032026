📌 Prueba Técnica Angular v16

Este proyecto fue desarrollado en Angular v16 como parte de una prueba técnica, aplicando buenas prácticas de arquitectura, modularización y reutilización de componentes para garantizar escalabilidad, mantenibilidad y buen rendimiento.

🚀 Características principales

Implementación de Lazy Loading para la carga modular de la aplicación.

Cada módulo cuenta con su propio:

module

routing

configuración independiente

Uso de Servicios HTTP para la comunicación con APIs.

Implementación de RxJS para el manejo reactivo de datos.

Uso de Formularios Reactivos para validación y control de entradas.

Tipado fuerte con TypeScript para mejorar la mantenibilidad del código.

Creación de Pipes personalizados para validaciones y transformaciones.

Aplicación de lógica condicional para estilos dinámicos (colores según estado).

Desarrollo de una tabla genérica reutilizable para ser utilizada en diferentes módulos.

Uso de librerías externas para mejorar la experiencia de usuario:

SweetAlert2 (Swal)

Chart.js para gráficos

🛠️ Tecnologías usadas

Angular 16

TypeScript

RxJS

Angular Reactive Forms

Bootstrap / CSS

SweetAlert2

Chart.js

▶️ Instalación y ejecución
npm install
ng serve

Luego abrir en el navegador:

http://localhost:4200/
📂 Arquitectura

El proyecto sigue una arquitectura modular usando Lazy Loading en Angular v16 para mejorar el rendimiento y la escalabilidad.

Cada módulo contiene:

Module

Routing

Components


