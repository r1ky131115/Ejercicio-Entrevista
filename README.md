# Ejercicio-Entrevista
Programa pedido en entrevista tecnica

Hacer una interfaz gráfica que permita el ingreso de un numero de orden (en la base de datos están en la Tabla Orders) y que dispare una búsqueda con un botón o similar.

Cuando se presiona el boton buscar, si es una orden no válida o existente, informar al usuario en la interfaz.

Si es una orden válida, mostrar en la interfaz el nombre de la compañía del cliente (Customers.CompanyName) y la direccion (Customers.Address), y debajo mostrar en una grilla o similar los nombres de los productos pertenecientes a esa orden (Products.ProductName), Precio Unitario y Cantidad, y una columna extra que indique en cuantas órdenes (distintas a la consultada) figura ese producto.

Las consultas a la base de datos deben realizarse con stored procedures.

La conexión entre la interfaz gráfica y la base de datos debe pasar por un servicio o aplicación de backend con la tecnología, lenguaje y arquitectura que el programador decida.
