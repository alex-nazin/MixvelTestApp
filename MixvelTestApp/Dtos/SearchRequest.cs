using System.ComponentModel.DataAnnotations;

namespace MixvelTestApp.Dtos
{
    /// <summary>
    /// Запрос на агрегированный поиск маршрутов
    /// </summary>
    public class SearchRequest
    {
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
        /// Фильтры поиска
        /// </summary>
        public SearchFilters? Filters { get; set; }
    }
}
