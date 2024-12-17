using System.ComponentModel.DataAnnotations;

namespace ProviderOne.Dtos
{
    /// <summary>
    /// Одиночный маршрут
    /// </summary>
    public class ProviderOneRoute
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
        [Required]
        public DateTime DateTo { get; set; }

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
