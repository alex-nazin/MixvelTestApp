using System.ComponentModel.DataAnnotations;

namespace MixvelTestApp.Dtos
{
    /// <summary>
    /// Найденный маршрут
    /// </summary>
    public class Route
    {
        /// <summary>
        /// Идентификатор маршрута
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        [Required]
        public string Origin { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        [Required]
        public string Destination { get; set; } = null!;

        /// <summary>
        /// Дата начала путешествия
        /// </summary>
        [Required]
        public DateTime OriginDateTime { get; set; }

        /// <summary>
        /// Дата завершения путешествия
        /// </summary>
        [Required]
        public DateTime DestinationDateTime { get; set; }

        /// <summary>
        /// Цена путешествия
        /// </summary>
        [Required]
        public decimal Price { get; set; }

        /// <summary>
        /// Дата/время актуальности маршрута
        /// </summary>
        [Required]
        public DateTime TimeLimit { get; set; }
    }
}
