using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Hotel.Shared.Helpers
{
    public static class RouteConfig
    {
        public const string BASE_API_ROUTE = "/api";
        
        public static class Select
        {
            public const string SELECT_ROUTE = "/select";
        }

        public static class Management
        {
            public const string MANAGEMENT_ROUTE = BASE_API_ROUTE + "/admin";

            public static class General
            {
                public const string GENERAL_ROUTE = MANAGEMENT_ROUTE + "/generales";

                public const string STATUS_ROUTE = GENERAL_ROUTE + "/estados";
                public const string DOCUMENT_TYPE_ROUTE = GENERAL_ROUTE + "/tipos-de-documentos";
                public const string UBIGEO_ROUTE = GENERAL_ROUTE + "/ubigeo";
            }

            public static class Business
            {
                public const string BUSINESS_ROUTE = MANAGEMENT_ROUTE + "/empresas";

                public const string COMPANY_ROUTE = BUSINESS_ROUTE + "/empresas";
                public const string COMPANY_HEADQUARTER_ROUTE = BUSINESS_ROUTE + "/sedes";
                public const string POINT_OF_SALE_ROUTE = BUSINESS_ROUTE + "/pos";
                public const string CUSTOMER_ROUTE = BUSINESS_ROUTE + "/cliente";
                public const string EMPLOYEE_ROUTE = BUSINESS_ROUTE + "/colaboradores";
                public const string WORK_AREA_ROUTE = BUSINESS_ROUTE + "/areas";
                public const string WORK_POSITION_ROUTE = BUSINESS_ROUTE + "/cargos";

            }

            public static class Rooms
            {
                public const string ROOMS_ROUTE = MANAGEMENT_ROUTE + "/habitaciones";
                public const string ROOMSTATUS_ROUTE = ROOMS_ROUTE + "/estado-habitacion";
                public const string ROOM_ROUTE = ROOMS_ROUTE + "/habitaciones";
                public const string ROOMTYPE_ROUTE = ROOMS_ROUTE + "/tipos-de-habitacion";
            }

            public static class Guests
            {
                public const string GUESTS_ROUTE = MANAGEMENT_ROUTE + "/huespedes";

                public const string GUEST_ROUTE = GUESTS_ROUTE + "/huespedes";
            }

            public static class Security
            {
                public const string SECURITY_ROUTE = MANAGEMENT_ROUTE + "/seguridad";

                public const string USER_ROUTE = SECURITY_ROUTE + "/usuarios";
                public const string PERMISSION_ROUTE = SECURITY_ROUTE + "/permsiso";
                public const string PERMISSIONLEVEL_ROUTE = SECURITY_ROUTE + "/nivel-permsiso";
                public const string MODULE_ROUTE = SECURITY_ROUTE + "/modulo";
                public const string SUBMODULE_ROUTE = SECURITY_ROUTE + "/sub-modulo";
            }
        }
    }
}

