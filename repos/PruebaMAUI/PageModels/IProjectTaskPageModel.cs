using CommunityToolkit.Mvvm.Input;
using PruebaMAUI.Models;

namespace PruebaMAUI.PageModels
{
    public interface IProjectTaskPageModel
    {
        IAsyncRelayCommand<ProjectTask> NavigateToTaskCommand { get; }
        bool IsBusy { get; }
    }
}