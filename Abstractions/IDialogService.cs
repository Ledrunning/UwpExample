using System.Threading.Tasks;

namespace UwpExample.Abstractions
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string message);
    }
}