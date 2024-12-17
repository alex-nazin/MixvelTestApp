namespace MixvelTestApp.Models
{
    /// <summary>
    /// Модель фильтра для поиска маршрутов
    /// </summary>
    public class SearchFiltersModel
    {
        /// <summary>
        /// Дата завершения маршрута
        /// </summary>
        public DateTime? DestinationDateTime { get; set; }

        /// <summary>
        /// Максимальная стоимость путешествия
        /// </summary>
        public decimal? MaxPrice { get; set; }

        /// <summary>
        /// Минимальное значение даты/времени, до которой маршрут должен быть актуальным
        /// </summary>
        public DateTime? MinTimeLimit { get; set; }

        /// <summary>
        /// Признак поиска только кэшированных маршрутов
        /// </summary>
        public bool? OnlyCached { get; set; }
    }
}
