using System.ComponentModel.DataAnnotations;

namespace ProviderTwo.Dtos
{
    /// <summary>
    /// Критерии поиска маршрутов
    /// </summary>
    public class ProviderTwoSearchRequest
    {
        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        [Required]
        public string Departure { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        [Required]
        public string Arrival { get; set; } = null!;

        /// <summary>
        /// Дата начала путешествия
        /// </summary>
        [Required]
        public DateTime DepartureDate { get; set; }

        /// <summary>
        /// Минимальное время актуальности маршрута
        /// </summary>
        public DateTime? MinTimeLimit { get; set; }
    }
}
