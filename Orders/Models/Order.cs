using System;

namespace Orders.Models;

/// <summary>
/// Представляє замовлення в системі.
/// </summary>
public class Order
{
    /// <summary>
    /// Унікальний ідентифікатор замовлення.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Номер замовлення.
    /// </summary>
    public string Number { get; set; }

    /// <summary>
    /// Загальна сума замовлення.
    /// </summary>
    public decimal Total { get; set; }

    /// <summary>
    /// Дата створення замовлення.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    public Order(int id, string number, decimal total, DateTime createdAt)
    {
        Id = id;
        Number = number;
        Total = total;
        CreatedAt = createdAt;
    }
}