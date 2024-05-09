using Client.Pages.SettingGrapeVarietiesPage.Models;

namespace Client.Pages.SettingGrapeVarietiesPage.Services
{
    /// <summary>
    /// Интерфейс API для редактирования сортов винограда
    /// </summary>
    public interface IGrapeVarietiesApiService
    {
        /// <summary>
        /// Получить список сортов винограда
        /// </summary>
        /// <returns></returns>
        Task<List<GrapeVarietyResponse>> GetGrapeVarieties();

        /// <summary>
        /// Отредактировать сорт винограда
        /// </summary>
        /// <param name="model"> Измененная модель </param>
        /// <returns></returns>
        Task<bool> UpdateGrapeVariety(GrapeVarietyResponse model);

        /// <summary>
        /// Точка для добавления сорта винограда
        /// </summary>
        /// <param name="model"> Добавляемый сорт винограда </param>
        /// <returns></returns>
        Task<bool> AddGrapeVarietyAsync(GrapeVarietyResponse model);
    }
}
