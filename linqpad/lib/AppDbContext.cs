namespace lib;

using Microsoft.EntityFrameworkCore;
using CsvHelper.Configuration.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Category
{
    public string category_major_cd { get; set; }
    public string category_major_name { get; set; }
    public string category_medium_cd { get; set; }
    public string category_medium_name { get; set; }
    public string category_small_cd { get; set; }
    public string category_small_name { get; set; }
}


public class Customer
{
    [Key]
    public string customer_id { get; set; }
    public string customer_name { get; set; }
    public string gender_cd { get; set; }
    public string gender { get; set; }
    public DateTime? birth_day { get; set; }
    public int? age { get; set; }
    public string postal_cd { get; set; }
    public string address { get; set; }
    public string application_store_cd { get; set; }
    public string application_date { get; set; }
    public string? status_cd { get; set; }
}

public class Geocode
{
    [Ignore] // CsvHelperで無視
    public int ID { get; set; }
    public string postal_cd { get; set; }
    public string prefecture { get; set; }
    public string city { get; set; }
    public string town { get; set; }
    public string street { get; set; }
    public string address { get; set; }
    public string full_address { get; set; }
    public decimal? longitude { get; set; }
    [Name(" latitude")]
    public decimal? latitude { get; set; }
}
// ※注：CSV ファイルの項目定義に合わせて " latitude" と修正

public class Product
{
    public string product_cd { get; set; }
    public string category_major_cd { get; set; }
    public string category_medium_cd { get; set; }
    public string category_small_cd { get; set; }
    public int? unit_price { get; set; }
    public int? unit_cost { get; set; }
}

public class Receipt
{
    public string sales_ymd { get; set; }
    public int? sales_epoch { get; set; }
    public string store_cd { get; set; }
    public short receipt_no { get; set; }
    public short receipt_sub_no { get; set; }
    public string customer_id { get; set; }
    public string product_cd { get; set; }
    public int? quantity { get; set; }
    public int? amount { get; set; }
}

public class Store
{
    public string store_cd { get; set; }
    public string store_name { get; set; }
    public string prefecture_cd { get; set; }
    public string prefecture { get; set; }
    public string address { get; set; }
    public string address_kana { get; set; }
    public string ?tel_no { get; set; }
    public decimal ?longitude { get; set; }
    public decimal ?latitude { get; set; }
    public decimal ?floor_area { get; set; }
}

public class AppDbContext : DbContext
{
    public DbSet<Category> Category { get; set; }
    public DbSet<Customer> Customer { get; set; }
    public DbSet<Geocode> Geocode { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<Product> Product { get; set; }
    public DbSet<Store> Store { get; set; }

    public string DbPath { get; }

    public AppDbContext(String dbPath)
    {
        DbPath = dbPath;
    }

    // デスクトップ上にSQLiteのDBファイルが作成される
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>()
            .HasKey(x => new { x.category_major_cd, x.category_medium_cd, x.category_small_cd });

        modelBuilder.Entity<Customer>()
            .HasKey(x => x.customer_id);

        modelBuilder.Entity<Geocode>()
            .HasKey(x => x.ID);

        modelBuilder.Entity<Product>()
            .HasKey(x => x.product_cd);

        modelBuilder.Entity<Receipt>()
            .HasKey(x => new { x.sales_ymd, x.store_cd, x.receipt_no, x.receipt_sub_no });

        modelBuilder.Entity<Store>()
            .HasKey(x => x.store_cd);
    }
}