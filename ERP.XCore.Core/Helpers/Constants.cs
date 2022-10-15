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

            public static Guid ENABLED_ID = Guid.Parse("0B7945E8-7718-4692-C72E-08DAA6EB4C41");

            public static Guid DISABLED_ID = Guid.Parse("2E72DFC0-9439-4AA0-C72F-08DAA6EB4C41");
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
    }
}
