using FileUploadService.Core.Entities;

namespace FileUploadService.Core.Repositories;

/// <summary>
/// Интерфейс репозитория для работы с файловым хранилищем.
/// </summary>
public interface IFileStorageRepository
{
    /// <summary>
    /// Обновляет файл в хранилище.
    /// </summary>
    /// <param name="file">Файл.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача обновления файла.</returns>
    public Task UploadAsync(UploadedFile file, CancellationToken cancellationToken = default);
}
