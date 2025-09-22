namespace FileUploadService.Core.Entities;

/// <summary>
/// Сущность обновляемого файла.
/// </summary>
public class UploadedFile : IDisposable, IAsyncDisposable
{
    private bool _disposed;

    /// <summary>
    /// Имя файла.
    /// </summary>
    public required string Name { get; init; }

    /// <summary>
    /// Расширение файла.
    /// </summary>
    public string? Extension { get; set; }

    /// <summary>
    /// Данные файла.
    /// </summary>
    public Stream? Data { get; private set; }

    /// <summary>
    /// Размер файла.
    /// </summary>
    public long Length => Data?.Length ?? 0;

    /// <summary>
    /// Наличие данных.
    /// </summary>
    public bool HasData => Data is { Length: > 0 };

    /// <inheritdoc cref="IDisposable.Dispose"/>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            Data?.Dispose();
            Data = null;
        }

        _disposed = true;
    }

    /// <inheritdoc cref="IAsyncDisposable.DisposeAsync"/>
    protected virtual async ValueTask DisposeAsync(bool disposing)
    {
        if (_disposed)
            return;

        if (Data is not null && disposing)
        { 
            await Data.DisposeAsync();
            Data = null;
        }

        _disposed = true;
    }

    /// <inheritdoc cref="IDisposable.Dispose"/>
    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <inheritdoc cref="IAsyncDisposable.DisposeAsync"/>
    public async ValueTask DisposeAsync()
    {
        await DisposeAsync(true);
        GC.SuppressFinalize(this);
    }
}
