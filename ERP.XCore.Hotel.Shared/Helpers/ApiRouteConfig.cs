using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Hotel.Shared.Helpers
{
    public static class ApiRouteConfig
    {
        public const string BASE_API_ROUTE = "/api";

        public static class Security
        {
            public const string SECURITY_ROUTE = BASE_API_ROUTE + "/seguridad";
        }

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

                public const string ROOMSTATUS_ROUTE = ROOMS_ROUTE + "/estados-de-habitacion";
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
                public const string ROLE_ROUTE = SECURITY_ROUTE + "/roles";
                public const string PERMISSION_ROUTE = SECURITY_ROUTE + "/permisos";
                public const string PERMISSIONLEVEL_ROUTE = SECURITY_ROUTE + "/niveles-de-permiso";
                public const string MODULE_ROUTE = SECURITY_ROUTE + "/modulos";
                public const string SUBMODULE_ROUTE = SECURITY_ROUTE + "/submodulos";
            }
        }

        public static class Configuration
        {
            public const string CONFIGURATION_ROUTE = BASE_API_ROUTE + "/configuracion";

            public const string FEE_ROUTE = CONFIGURATION_ROUTE + "/tarifas";
        }

        public static class Payment
        {
            public const string PAYMENT_ROUTE = BASE_API_ROUTE + "/pago";

            public const string PAYMENT_METHOD_ROUTE = PAYMENT_ROUTE + "/metodos-de-pago";
            public const string PENDING_PAYMENTS = PAYMENT_ROUTE + "/facturacion";
        }

        public static class Rack
        {
            public const string RACK_ROUTE = BASE_API_ROUTE + "/rack";

            public const string CHECKIN_ROUTE = RACK_ROUTE + "/checkin";
            public const string CLEANING_ROUTE = RACK_ROUTE + "/limpieza";
            public const string DETAIL_ROUTE = RACK_ROUTE + "/detalle";
            public const string EXTENSION_ROUTE = RACK_ROUTE + "/extension";
            public const string CANCEL_ROUTE = RACK_ROUTE + "/cancelar";
		}
    }
}

