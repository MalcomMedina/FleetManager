using Dominio.DataAccess.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Helpers.Utils
{
    public class DataValidationResult
    {
        protected IDictionary<string, string> ValidationStatusMessages = new Dictionary<string, string>() 
        {
            { "Ok", "¡Recurso encontrado con éxito!" },
            { "Created", "¡El registro se ha creado exitosamente!" },
            { "Updated", "¡El registro se ha modificado exitosamente!" },
            { "Deleted", "¡El registro se ha eliminado exitosamente!" },
            { "Accepted", "La tarea se ha puesto en ejecución..." },
            { "NoContent", "¡No hay datos registrados en el recurso solicitado!" },
            { "BadRequest", "¡Ha ocurrido un error, asegurese de completar los campos o contáctese con un administrador!" },
            { "Unauthorized", "¡Debe iniciar sesión para realizar esta acción!" },
            { "Forbidden", "¡Usted no cuenta con los permisos necesario para realizar esta acción, contáctese con un administrador!" },
            { "NotFound", "¡El recurso que usted ha solicitado no ha sido encontrado!" },
            { "MethodNotAllowed", "¡El recurso que usted ha solicitado no se encuentra disponible!" },
            { "InternalServerError", "¡Ha ocurrido un error, contáctese con un administrador para notificar el incidente!" },
            { "NotImplemented", "¡No se reconoce el recurso que usted ha solicitado!" },
            { "ServiceUnavalible", "¡El recurso que usted ha solicitado no se encuentra disponible en estos momentos!" }
        };
        protected enum ValidationStatus //Definición por contexto de las cabeceras de respuesta de las peticiones
        {
            //2xx
            Ok,                 //Exitoso
            Created,            //Recurso Creado
            Updated,            //Personalizado
            Deleted,            //Personalizado
            Accepted,           //Petición aceptada pero aún no procesada
            NoContent,          //Petición realizada con éxito pero no hay cuerpo de respuesta

            //4xx
            BadRequest,         //Error genérico. No se puede completar la petición por error del cliente. Regularmente se envia en el cuerpo de la respuesta la instrucción acerca de que se hizo mal
            Unauthorized,       //Esto indica que el cliente requiere de una previa autorización para acceder al recurso
            Forbidden,          //No hay permisos para utilizar el recurso que solicito aunque este logueado
            NotFound,           //Recurso no encontrado
            MethodNotAllowed,   //El método-http utilizado no está disponible para el recurso solicitado

            //5xx
            InternalServerError,//Este es un error genérico. Regularmente se envia en el cuerpo de la respuesta la instrucción acerca de que salió mal.
            NotImplemented,     //Se da cuando el servidor no reconoce ni soporta el método-http usado en la petición del cliente.
            ServiceUnavalible   //El servicio no se encuentra disponible en estos momentos, típicamete esto es algo temporal
        }
    }
}
