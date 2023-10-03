namespace ClinicService.Services
{
    /// <summary>
    /// Интерфейс базового репозитория.
    /// Определяет стандартные контракты для работы с данными сущностей.
    /// </summary>
    /// <typeparam name="T">Тип сущности.</typeparam>
    /// <typeparam name="TId">Тип идентификатора сущности.</typeparam>
    public interface IRepository<T, TId>
    {
        /// <summary>
        /// Получить список всех сущностей.
        /// </summary>
        /// <returns>Список сущностей.</returns>
        IList<T> GetAll();

        /// <summary>
        /// Получить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность или null, если таковая не найдена.</returns>
        T GetById(TId id);

        /// <summary>
        /// Создать новую сущность.
        /// </summary>
        /// <param name="item">Сущность для создания.</param>
        /// <returns>Результат операции (например, количество затронутых записей).</returns>
        int Create(T item);

        /// <summary>
        /// Обновить существующую сущность.
        /// </summary>
        /// <param name="item">Сущность для обновления.</param>
        /// <returns>Результат операции (например, количество затронутых записей).</returns>
        int Update(T item);

        /// <summary>
        /// Удалить сущность по её идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности для удаления.</param>
        /// <returns>Результат операции (например, количество затронутых записей).</returns>
        int Delete(TId id);
    }
}
