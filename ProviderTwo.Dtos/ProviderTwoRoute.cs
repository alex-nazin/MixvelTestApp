using System.ComponentModel.DataAnnotations;

namespace ProviderTwo.Dtos
{
    /// <summary>
    /// Одиночный маршрут
    /// </summary>
    public class ProviderTwoRoute
    {
        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        [Required]
        public ProviderTwoPoint Departure { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        [Required]
        public ProviderTwoPoint Arrival { get; set; } = null!;

        /// <summary>
        /// Стоимость путешествия
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Время актуальности маршрута
        /// </summary>
        [Required]
        public DateTime TimeLimit { get; set; }
    }
}
