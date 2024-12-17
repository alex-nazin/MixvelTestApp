namespace MixvelTestApp.Models
{
    /// <summary>
    /// Ключ для работы с кэшом маршрутов
    /// </summary>
    /// <param name="Origin">Начальная точка маршрута</param>
    /// <param name="Destination">Конечная точка маршрута</param>
    /// <param name="OriginDateTime">Дата начала путешествия</param>
    /// <param name="DestinationDateTime">Дата завершения маршрута</param>
    /// <param name="MaxPrice">Максимальная стоимость путешествия</param>
    public record RoutesCacheKey(
        string Origin,
        string Destination,
        DateTime OriginDateTime,
        DateTime? DestinationDateTime,
        decimal? MaxPrice)
    {
    }
}
