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

            public static Guid ENABLED_ID = Guid.Parse("E3245CA6-17D9-42BB-A671-08DA9C06C7E9");

            public static Guid DISABLED_ID = Guid.Parse("14A541C3-C87B-4940-A672-08DA9C06C7E9");
        }
    }
}
