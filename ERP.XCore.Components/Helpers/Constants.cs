using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP.XCore.Components.Helpers
{
    public static class Constants
    {
        public static class Dialog
        {
            public const string OK_BUTTON_TEXT = "Entendido";
            public const string CANCEL_BUTTON_TEXT = "Cancelar";
            public const string CONFIRM_BUTTON_TEXT = "Confirmar";
            public const string SAVE_BUTTON_TEXT = "Guardar";

            public const string DELETE_TITLE_TEXT = "¿Desea eliminar el registro?";
            public const string DELETE_MESSAGE_TEXT = "Esta acción es irreversible.";

            public static DialogOptions DEFAULT_DIALOG_FORM_OPTIONS = new()
            {
                FullWidth = true,
            };
        }
    }
}
