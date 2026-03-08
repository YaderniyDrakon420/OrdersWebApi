namespace Orders.Models;

/// <summary>
/// DTO для створення або оновлення замовлення.
/// </summary>
public class OrderCreateDto
{
    /// <summary>
    /// Номер замовлення.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Загальна сума замовлення.
    /// </summary>
    public decimal Total { get; set; }
}
