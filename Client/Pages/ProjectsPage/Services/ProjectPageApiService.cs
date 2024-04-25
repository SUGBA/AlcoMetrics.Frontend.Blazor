using System.Net.Http.Json;
using Client.Configuration.ApiConfiguration;
using Client.Pages.ProjectsPage.Models.Request;
using Client.Pages.ProjectsPage.Models.Response;
using Client.Pages.ProjectsPage.Request;

namespace Client.Pages.ProjectsPage.Services
{
    /// <summary>
    /// Сервис API для связи с AlcoMetrics.Wine.Backend, по странице ProjectPage
    /// </summary>
    public class ProjectPageApiService : IProjectPageApiService
    {
        private const string EMPTY_RESPONSE_ERROR = "В ходе создания проекта, произошла ошибка. Возможно сервис недоступен в данный момент. Попробуйте позже";

        private readonly HttpClient _httpClient;

        public ProjectPageApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Изменить имя мероприятия
        /// </summary>
        /// <param name="model"> Модель с Id проекта и новым именем </param>
        /// <returns></returns>
        public async Task<bool> ChangeProjectNameAsync(ChangeProjectNameRequest model)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var changeProjectNamePath = WineBackendConfiguration.ChangeProjectNamePath;
            var path = $"{domenPath}/{changeProjectNamePath}";

            var response = await _httpClient.PostAsJsonAsync(path, model);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }

        /// <summary>
        /// Создать таймлайн путем ввода всех параметров
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByAllParamsAsync(CreateProjectModelByAllParams request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var createProjectPath = WineBackendConfiguration.CreateProjectByAllParamasPath;
            var path = $"{domenPath}/{createProjectPath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            return await response.Content.ReadFromJsonAsync<CreateProjectResponse>() ?? new CreateProjectResponse() { Error = EMPTY_RESPONSE_ERROR };
        }

        /// <summary>
        /// Создать таймлайн путем ввода показаний ареометра
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByAreometerAsync(CreateProjectModelByAreometer request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var createProjectPath = WineBackendConfiguration.CreateProjectByAreometerPath;
            var path = $"{domenPath}/{createProjectPath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            return await response.Content.ReadFromJsonAsync<CreateProjectResponse>() ?? new CreateProjectResponse() { Error = EMPTY_RESPONSE_ERROR };
        }

        /// <summary>
        /// Создать таймлайн путем выбора сорта винограда
        /// </summary>
        /// <param name="request"> Данные для генерации таймлайна </param>
        /// <returns></returns>
        public async Task<CreateProjectResponse> CreateTimeLineByGrapeVaretyAsync(CreateProjectModelByGrapeVarety request)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var createProjectPath = WineBackendConfiguration.CreateProjectByGrapeVaretyPath;
            var path = $"{domenPath}/{createProjectPath}";

            var response = await _httpClient.PostAsJsonAsync(path, request);

            return await response.Content.ReadFromJsonAsync<CreateProjectResponse>() ?? new CreateProjectResponse() { Error = EMPTY_RESPONSE_ERROR };
        }

        /// <summary>
        /// Удалить проект
        /// </summary>
        /// <param name="id"> Идентификатор проекта </param>
        /// <returns></returns>
        public async Task<bool> DeleteProjectAsync(int id)
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var deleteProjectPath = WineBackendConfiguration.DeleteProjectPath;
            var path = $"{domenPath}/{deleteProjectPath}/{id}";

            var response = await _httpClient.PostAsync(path, null);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<bool>();
            return false;
        }

        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<string>> GetGrapeVarietiesAsync()
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getGrapeVarietiesPath = WineBackendConfiguration.GetGrapeVarietiesPath;
            var path = $"{domenPath}/{getGrapeVarietiesPath}";

            var response = await _httpClient.GetAsync(path);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<string>>() ?? Enumerable.Empty<string>();
            return Enumerable.Empty<string>();
        }

        /// <summary>
        /// Получить список мероприятий
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectResponse>?> GetListProjectsAsync()
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getProjectsPath = WineBackendConfiguration.GetProjectsPath;
            var path = $"{domenPath}/{getProjectsPath}";

            var response = await _httpClient.PostAsync(path, null);

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProjectResponse>>();
            return null;
        }
    }
}
