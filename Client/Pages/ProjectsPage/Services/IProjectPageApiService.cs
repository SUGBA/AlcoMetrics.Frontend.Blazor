using Client.Pages.ProjectsPage.Models.Request;
using Client.Pages.ProjectsPage.Models.Response;
using Client.Pages.ProjectsPage.Request;

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

        /// <summary>
        /// Создать таймлайн путем ввода всех параметров
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByAllParamsAsync(CreateProjectModelByAllParams request);

        /// <summary>
        /// Создать таймлайн путем ввода показаний ареометра
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByAreometerAsync(CreateProjectModelByAreometer request);

        /// <summary>
        /// Создать таймлайн путем выбора сорта винограда
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        Task<CreateProjectResponse> CreateTimeLineByGrapeVaretyAsync(CreateProjectModelByGrapeVarety request);

        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<string>> GetGrapeVarietiesAsync();
    }
}
