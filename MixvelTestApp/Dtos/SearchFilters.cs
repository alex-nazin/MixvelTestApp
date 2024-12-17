namespace MixvelTestApp.Dtos
{
    /// <summary>
    /// Фильтры поиска маршрутов
    /// </summary>
    public class SearchFilters
    {
        /// <summary>
        /// Дата завершения путешествия
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
        /// Признак поиска только в кэшированных данных
        /// </summary>
        public bool? OnlyCached { get; set; }
    }
}
