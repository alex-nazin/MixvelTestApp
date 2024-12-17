using System.ComponentModel.DataAnnotations;

namespace ProviderOne.Dtos
{
    /// <summary>
    /// Критерии поиска маршрутов
    /// </summary>
    public class ProviderOneSearchRequest
    {
        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        [Required]
        public string From { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        [Required]
        public string To { get; set; } = null!;

        /// <summary>
        /// Дата начала путешествия
        /// </summary>
        [Required]
        public DateTime DateFrom { get; set; }

        /// <summary>
        /// Дата завершения путешествия
        /// </summary>
        public DateTime? DateTo { get; set; }

        /// <summary>
        /// Максимальная стоимость путешествия
        /// </summary>
        public decimal? MaxPrice { get; set; }
    }
}
