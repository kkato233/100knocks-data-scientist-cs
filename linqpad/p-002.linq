<Query Kind="Expression">
  <Connection>
    <ID>7fb1ffc4-237b-4031-affe-6cb78afe85b6</ID>
    <NamingServiceVersion>3</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="(internal)" PublicKeyToken="no-strong-name">LINQPad.Drivers.EFCore.DynamicDriver</Driver>
    <AllowDateOnlyTimeOnly>true</AllowDateOnlyTimeOnly>
    <SqlSecurity>true</SqlSecurity>
    <AttachFileName>D:\wk\26\2026-05-12-100-net-linqpad\100knocks-data-scientist-cs\linqpad\database\sqlite.db</AttachFileName>
    <DriverData>
      <EncryptSqlTraffic>True</EncryptSqlTraffic>
      <PreserveNumeric1>True</PreserveNumeric1>
      <EFProvider>Microsoft.EntityFrameworkCore.Sqlite</EFProvider>
    </DriverData>
  </Connection>
</Query>

/*
P-002: レシート明細のデータフレーム（df_receipt）から売上日（sales_ymd）、顧客ID（customer_id）、
商品コード（product_cd）、売上金額（amount）の順に列を指定し、10件表示させよ。

*/

Receipts
.Select(r => new {
	r.Sales_ymd,
	r.Customer_id,
	r.Product_cd,
	r.Amount
}).Take(10)