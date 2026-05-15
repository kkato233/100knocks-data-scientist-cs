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
P-012: 店舗データフレーム（df_store）から横浜市の店舗だけ全項目表示せよ。

*/

Stores.AsNoTracking()
.Where(r => r.Address.Contains("横浜市"))