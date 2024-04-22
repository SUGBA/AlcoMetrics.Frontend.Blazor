using System.Collections.Generic;
using System.Net.Http.Json;
using System.Reflection;
using Client.Configuration.ApiConfiguration;
using Client.Pages.ProjectsPage.Models.Request;
using Client.Pages.ProjectsPage.Models.Response;

namespace Client.Pages.ProjectsPage.Services
{
    /// <summary>
    /// Сервис API для связи с AlcoMetrics.Wine.Backend, по странице ProjectPage
    /// </summary>
    public class ProjectPageApiService : IProjectPageApiService
    {
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
        /// Получить список мероприятий
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectResponse>?> GetListProjectsAsync()
        {
            var domenPath = WineBackendConfiguration.DomenPath;
            var getProjectsPath = WineBackendConfiguration.GetProjectsPath;
            var path = $"{domenPath}/{getProjectsPath}";

            var response = await _httpClient.PostAsync(path, null);

            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Credentials", "true");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "Access-Control-Allow-Origin,Content-Type");

            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<IEnumerable<ProjectResponse>>();
            return null;
        }
    }
}
