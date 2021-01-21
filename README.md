# API_Tickets

1. El respectivo script para la creación de la base de datos se encuentra dentro del proyecto en la carpeta Providers, se utilizó SQL Server.
2. La API la desarrolle sobre Net Core 3.0, en el appsettings.json se configura el ambiente de la base de datos donde deseean probar la API en la llave EntornoDev.
3. Las pruebas que realicé para su correcto funcionamiento las realice utilizando Postman, a continuación describo los Http Methods utilizados para sus peticiones, además cada petición la realizo con un Body de forma raw en formato JSON. De esta forma lo importante es siempre enviar un objeto JSON hacia la API por cada petición.

-- Crear ticket --
Método: POST
Petición: RutaLocal + /api/Ticket/CreateTicket
Objeto JSON:
{
    "Usuario": "UserPrueba"	
}

-- Eliminar ticket --
Método: DELETE
Petición: RutaLocal + /api/Ticket/DeleteTicket
Objeto JSON:
{
    "IdTicket": #idticket
}

-- Editar ticket --
Método: PUT
Petición: RutaLocal + /api/Ticket/EditTicket
Objeto JSON:
{
    "Usuario": "UserPrueba2",
    "Status": "Cerrado",
    "IdTicket": #idticket
}

-- Recuperar tickets --
Método: GET
Petición: RutaLocal + /api/Ticket/RetrieveTicket
Objeto JSON:
* Todos:
{
}

* Recuperar uno específico
{
    "IdTicket": #idticket	
}
