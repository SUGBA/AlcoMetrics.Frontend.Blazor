using Client.Pages.ProjectsPage.Models.Request;
using Client.Pages.ProjectsPage.Models.Response;

namespace Client.Pages.ProjectsPage.Services
{
    /// <summary>
    /// Интерфейс API для связи с AlcoMetrics.Wine.Backend, по странице ProjectPage
    /// </summary>
    public interface IProjectPageApiService
    {
        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<ProjectResponse>?> GetListProjectsAsync();

        /// <summary>
        /// Изменить имя проекта
        /// </summary>
        /// <param name="model"> Модель с id изменяегого проекта и новым именем </param>
        /// <returns></returns>
        Task<bool> ChangeProjectNameAsync(ChangeProjectNameRequest model);

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        Task<bool> DeleteProjectAsync(int id);
    }
}
