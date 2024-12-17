using System.ComponentModel.DataAnnotations;

namespace ProviderTwo.Dtos
{
    /// <summary>
    ///  Результат поиска маршрутов
    /// </summary>
    public class ProviderTwoSearchResponse
    {
        /// <summary>
        /// Массив маршрутов
        /// </summary>
        [Required]
        public ProviderTwoRoute[] Routes { get; set; } = null!;
    }
}
