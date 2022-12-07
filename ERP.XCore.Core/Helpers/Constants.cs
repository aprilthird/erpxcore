using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Core.Helpers
{
    public static class Constants
    {
        public static class Seed
        {
            public static bool ENABLED = true;
        }

        public static class Status
        {
            public const string DEFAULT_ENTITY = "General";

            public static Guid ENABLED_ID = Guid.Parse("5118D440-BBCA-4ED2-CA43-08DABDDDAA3B");

            public static Guid DISABLED_ID = Guid.Parse("E63B8DFF-FA4C-40C8-CA44-08DABDDDAA3B");
        }

        public static class Permission
        {
            public static string CREATE = "Crear";
            public static string READ = "Leer";
            public static string UPDATE = "Editar";
            public static string DELETE = "Eliminar";

            public static Guid READING_ID = Guid.Parse("C6BBA607-B515-44F3-6282-08DAA6EB4D62");

            public static Guid WRITING_ID = Guid.Parse("02342ED8-FC30-4E95-6283-08DAA6EB4D62");
        }

        public static class Message
        {
            public static class Error
            {
                public const string MESSAGE = "Ocurrió un problema al procesar su consulta";
                public const string TITLE = "Error";
            }

            public static class Info
            {
                public const string MESSAGE = "Mensaje informativo";
                public const string TITLE = "Info";
            }

            public static class Success
            {
                public const string MESSAGE = "Tarea realizada satisfactoriamente";
                public const string TITLE = "Éxito";
            }

            public static class Validation
            {
                public const string COMPARE = "El campo '{PropertyName}' no coincide con '{ComparisonValue}'.";
                public const string COMPARE_PASSWORD = "El campo debe coincidir con la contraseña.";
                public const string EMAIL_ADDRESS = "El campo '{PropertyName}' no es un correo electrónico válido.";
                public const string CREDIT_CARD = "El campo '{PropertyName}' no es un número de tarjeta válido.";
                public const string EQUAL = "El campo '{PropertyName}' debe tener un valor igual {ComparisonValue}.";
                public const string NOT_EQUAL = "El campo '{PropertyName}' debe tener un valor diferente a {ComparisonValue}.";
                public const string GREATER_THAN = "El campo '{PropertyName}' debe tener un valor mayor a {ComparisonValue}.";
                public const string GREATER_THAN_OR_EQUAL = "El campo '{PropertyName}' debe tener un valor mayor o igual a {ComparisonValue}.";
                public const string LESS_THAN = "El campo '{PropertyName}' debe tener un valor menor a {ComparisonValue}.";
                public const string LESS_THAN_OR_EQUAL = "El campo '{PropertyName}' debe tener un valor menor o igual a {ComparisonValue}.";
                public const string MAX_LENGTH = "El campo '{PropertyName}' debe tener {ComparisonValue} caracteres como máximo. Ingresaste {TotalLength} caracteres.";
                public const string MIN_LENGTH = "El campo '{PropertyName}' debe tener {ComparisonValue} caracteres como mínimo. Ingresaste {TotalLength} caracteres.";
                public const string LENGTH = "El campo '{PropertyName}' debe tener {MinLength} caracteres. Ingresaste {TotalLength} caracteres.";
                public const string LENGTH_RANGE = "El campo '{PropertyName}' debe tener {MinLength}-{MaxLength} caracteres. Ingresaste {TotalLength} caracteres.";
                public const string INCLUSIVE_BETWEEN = "El campo '{PropertyName}' debe tener un valor entre {From}-{To}. Ingresaste {Value}.";
                public const string EXCLUSIVE_BETWEEN = "El campo '{PropertyName}' debe tener un valor entre {From}-{To} (exclusivo). Ingresaste {Value}.";
                public const string REGULAR_EXPRESSION = "El campo '{PropertyName}' no es válido.";
                public const string SCALED_PRECISION = "El campo '{PropertyName}' no debe tener más de {ExpectedPrecision} dígitos ni más de {ExpectedScale} decimales. Ingresaste {Digits} dígitos con {ActualScale} decimales.";
                public const string REQUIRED = "El campo '{PropertyName}' es obligatorio.";
                public const string NOT_VALID = "El campo '{PropertyName}' no es válido.";
                public const string FILE_EXTENSIONS = "El campo '{PropertyName}' solo acepta archivos con los formatos: {1}.";
            }
        }
    }
}
