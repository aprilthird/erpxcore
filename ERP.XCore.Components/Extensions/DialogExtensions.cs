using ERP.XCore.Components.Helpers;
using MudBlazor;

namespace ERP.XCore.Components.Extensions
{
    public static class DialogExtensions
    {
		public static async Task<bool> ShowDialogAlertAsync(this IDialogService dialogService, string title, string message, string yesText = Constants.Dialog.OK_BUTTON_TEXT, DialogOptions? options = null)
        {
            return (await dialogService.ShowMessageBox(title, message, yesText, null, null, options) ?? false);
        }

		public static async Task<bool> ShowDialogConfirmAsync(this IDialogService dialogService, string title, string message, string yesText = Constants.Dialog.CONFIRM_BUTTON_TEXT, string noText = Constants.Dialog.CANCEL_BUTTON_TEXT, DialogOptions? options = null)
        {
            return (await dialogService.ShowMessageBox(title, message, yesText, noText, null, options) ?? false);
        }

        public static async Task<bool> ShowDeleteConfirmAsync(this IDialogService dialogService, string title = Constants.Dialog.DELETE_TITLE_TEXT, string message = Constants.Dialog.DELETE_MESSAGE_TEXT, string yesText = Constants.Dialog.CONFIRM_BUTTON_TEXT, string noText = Constants.Dialog.CANCEL_BUTTON_TEXT, DialogOptions? options = null)
        {
			return (await dialogService.ShowMessageBox(title, message, yesText, noText, null, options) ?? false);
		}
	}
}
