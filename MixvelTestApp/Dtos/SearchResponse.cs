using System.ComponentModel.DataAnnotations;

namespace MixvelTestApp.Dtos
{
    /// <summary>
    /// Результат поиска маршрута
    /// </summary>
    public class SearchResponse
    {
        /// <summary>
        /// Набор найденных маршрутов
        /// </summary>
        [Required]
        public Route[] Routes { get; set; } = null!;

        /// <summary>
        /// Минимальная цена
        /// </summary>
        [Required]
        public decimal MinPrice { get; set; }

        /// <summary>
        /// Максимальная цена
        /// </summary>
        [Required]
        public decimal MaxPrice { get; set; }

        /// <summary>
        /// Минимальная продолжительность маршрута
        /// </summary>
        [Required]
        public int MinMinutesRoute { get; set; }

        /// <summary>
        /// Максимальная продолжительность маршрута
        /// </summary>
        [Required]
        public int MaxMinutesRoute { get; set; }
    }
}
