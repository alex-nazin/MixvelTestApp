using System.ComponentModel.DataAnnotations;

namespace ProviderOne.Dtos
{
    /// <summary>
    /// Результат поиска маршрутов
    /// </summary>
    public class ProviderOneSearchResponse
    {
        /// <summary>
        /// Массив маршрутов
        /// </summary>
        [Required]
        public ProviderOneRoute[] Routes { get; set; } = null!;
    }
}
