namespace MixvelTestApp.Models
{
    /// <summary>
    /// Модель запроса поиска
    /// </summary>
    public class SearchRequestModel
    {
        /// <summary>
        /// Начальная точка маршрута
        /// </summary>
        public string Origin { get; set; } = null!;

        /// <summary>
        /// Конечная точка маршрута
        /// </summary>
        public string Destination { get; set; } = null!;

        /// <summary>
        /// Дата начала путешествия
        /// </summary>
        public DateTime OriginDateTime { get; set; }

        /// <summary>
        /// Фильтры поиска
        /// </summary>
        public SearchFiltersModel? Filters { get; set; }
    }
}
