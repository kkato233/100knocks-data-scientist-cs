#! dotnet run
#:property PublishAot=false
#:package CsvHelper@33.1.0
// AppDbContext.cs をインクルード
#:project ./lib/lib.csproj

// データを CSV ファイルから取得する定義＆読み込み
using CsvHelper.Configuration.Attributes;
using System.IO;
using System.Globalization;
using CsvHelper;
using lib;

static List<T> LoadFromCsvFile<T>(string fileName) 
{
    using (var reader = new StreamReader(fileName))
    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
    {
        try {
            var records = csv.GetRecords<T>();
            return records.ToList();
        } catch(Exception exp) {
            throw new Exception("file=" + fileName, exp);
        }
    }
}

/*
 * データベースのインポート
*/
string inDir = "../work";

var df_customer = LoadFromCsvFile<Customer>($"{inDir}/customer.csv");
var df_category = LoadFromCsvFile<Category>($"{inDir}/category.csv");
var df_product = LoadFromCsvFile<Product>($"{inDir}/product.csv");
var df_receipt = LoadFromCsvFile<Receipt>($"{inDir}/receipt.csv");
var df_store = LoadFromCsvFile<Store>($"{inDir}/store.csv");
var df_geocode = LoadFromCsvFile<Geocode>($"{inDir}/geocode.csv");

var db = new AppDbContext("./database/sqlite.db");

if (db.Customer.Count() == 0) {
    db.Customer.AddRange(df_customer);
    db.Category.AddRange(df_category);
    db.Product.AddRange(df_product);
    db.Receipt.AddRange(df_receipt);
    db.Store.AddRange(df_store);
    db.SaveChanges();
}
if (db.Geocode.Count() == 0) {
    db.Geocode.AddRange(df_geocode);
    db.SaveChanges();
}