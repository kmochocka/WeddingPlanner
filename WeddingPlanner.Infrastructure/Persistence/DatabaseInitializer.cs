using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;

namespace WeddingPlanner.Infrastructure.Persistence;

public static class DatabaseInitializer
{
    public static void EnsureDatabaseCreated(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? "Data Source=App_Data/weddingplanner.db";

        using var connection = new SqliteConnection(connectionString);
        connection.Open();

        foreach (var commandText in SchemaCommands)
        {
            using var command = connection.CreateCommand();
            command.CommandText = commandText;
            command.ExecuteNonQuery();
        }
    }

    private static readonly string[] SchemaCommands =
    [
        """
        CREATE TABLE IF NOT EXISTS Appointments (
            Id INTEGER NOT NULL CONSTRAINT PK_Appointments PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            Description TEXT NOT NULL,
            StartTime TEXT NOT NULL,
            EndTime TEXT NOT NULL,
            IsReminderSent INTEGER NOT NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS Budgets (
            Id INTEGER NOT NULL CONSTRAINT PK_Budgets PRIMARY KEY AUTOINCREMENT,
            TotalAmount TEXT NOT NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS Expenses (
            Id INTEGER NOT NULL CONSTRAINT PK_Expenses PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Amount TEXT NOT NULL,
            Category TEXT NOT NULL,
            IsPaid INTEGER NOT NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS Guests (
            Id INTEGER NOT NULL CONSTRAINT PK_Guests PRIMARY KEY AUTOINCREMENT,
            FirstName TEXT NOT NULL,
            LastName TEXT NOT NULL,
            IsConfirmed INTEGER NOT NULL,
            HasPlusOne INTEGER NOT NULL,
            WeddingTableId INTEGER NULL,
            TableId INTEGER NULL,
            SeatNumber INTEGER NULL,
            SeatNumberPlusOne INTEGER NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS Tables (
            Id INTEGER NOT NULL CONSTRAINT PK_Tables PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Shape TEXT NOT NULL,
            Capacity INTEGER NOT NULL,
            PositionX REAL NOT NULL,
            PositionY REAL NOT NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS Tasks (
            Id INTEGER NOT NULL CONSTRAINT PK_Tasks PRIMARY KEY AUTOINCREMENT,
            Title TEXT NOT NULL,
            IsCompleted INTEGER NOT NULL,
            AssignedPerson TEXT NULL,
            DueDate TEXT NULL
        )
        """,
        """
        CREATE TABLE IF NOT EXISTS WeddingTables (
            Id INTEGER NOT NULL CONSTRAINT PK_WeddingTables PRIMARY KEY AUTOINCREMENT,
            Name TEXT NOT NULL,
            Capacity INTEGER NOT NULL,
            TableType TEXT NOT NULL
        )
        """
    ];
}
