﻿using Microsoft.EntityFrameworkCore;

using Insania.Politics.Entities;

namespace Insania.Politics.Database.Contexts;

/// <summary>
/// Контекст бд политики
/// </summary>
public class PoliticsContext : DbContext
{
    #region Конструкторы
    /// <summary>
    /// Простой конструктор контекста бд политики
    /// </summary>
    public PoliticsContext() : base()
    {

    }

    /// <summary>
    /// Конструктор контекста бд политики с опциями
    /// </summary>
    /// <param cref="DbContextOptions{PoliticsContext}" name="options">Параметры</param>
    public PoliticsContext(DbContextOptions<PoliticsContext> options) : base(options)
    {

    }
    #endregion

    #region Поля
    /// <summary>
    /// Тип организаций
    /// </summary>
    public virtual DbSet<OrganizationType> OrganizationsTypes { get; set; }

    /// <summary>
    /// Организации
    /// </summary>
    public virtual DbSet<Organization> Organizations { get; set; }

    /// <summary>
    /// Страны
    /// </summary>
    public virtual DbSet<Country> Countries { get; set; }
    #endregion

    #region Методы
    /// <summary>
    /// Метод при создании моделей
    /// </summary>
    /// <param cref="ModelBuilder" name="modelBuilder">Конструктор моделей</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Установка схемы бд
        modelBuilder.HasDefaultSchema("insania_politics");

        //Создание ограничения уникальности на псевдоним типа организации
        modelBuilder.Entity<OrganizationType>().HasAlternateKey(x => x.Alias);

        //Создание ограничения уникальности на псевдоним наименования организации
        modelBuilder.Entity<Organization>().HasAlternateKey(x => x.Name);

        //Создание ограничения уникальности на псевдоним страны
        modelBuilder.Entity<Country>().HasAlternateKey(x => x.Alias);
        
        //Создание ограничения уникальности на цвет страны на карте
        modelBuilder.Entity<Country>().HasAlternateKey(x => x.Color);
    }
    #endregion
}