# Indimin Challenge

## Pasos para ejecutar

```
docker-compose -f docker-compose.yml -f docker-compose.override.yml up --build
```

![image](https://github.com/michaelzapata/IndiminChallenge/blob/master/Imagenes/Contenedor.png)

en http://localhost:3000 se puede encontrar la vista en Vuejs  
en http://localhost:8001/swagger se puede encontrar la documentacion de Ciudadanos   
en http://localhost:8002/swagger se puede encontrar la documentacion de Tareas   
en http://localhost:8003/swagger se puede encontrar la documentacion de BFF   
en http://localhost:4000 se puede encontrar la app Seq para logging  
   
No llegue a hacer el alta de Tareas pero se pueden dar de alta mediante http://localhost:8002/swagger   

## Tecnologias Utilizadas
Docker  
Net Core 5.0  
Vuejs Nuxt  
MediatR  
Patron CQRS  
Patron Repositorio  
Patron Unit Of Work  
SQL Server  
MongoDB  
Swagger  
Serilog  
Seq

