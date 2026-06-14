using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SimpleCRUD.Data.DataContext;

namespace SimpleCRUD.Tests.Common;

public static class TestDbContextFactory
{
    public static SimpleCrudDbContext CreateContext()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<SimpleCrudDbContext>()
            .UseSqlite(connection)
            .Options;

        var context = new SimpleCrudDbContext(options);
        context.Database.EnsureCreated();

        return context;
    }
}