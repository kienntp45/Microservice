using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Iot.Class.Domain.ReadModels;
using Npgsql;

namespace Iot.Class.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext([NotNullAttribute] DbContextOptions options) : base(options)
    {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public virtual DbSet<ClassReadModel> Classes { get; set; }
    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //{
    //    base.OnConfiguring(optionsBuilder);
    //    optionsBuilder.LogTo(Console.WriteLine);
    //}
   // static ApplicationDbContext() => NpgsqlConnection.GlobalTypeMapper.MapEnum<RelationshipTypeEnum.RelationshipType>().MapEnum<StatusEnum.StatusType>();
}
