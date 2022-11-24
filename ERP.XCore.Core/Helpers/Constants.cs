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
    }
}
