<Query Kind="Expression" />

/*
P-009: 以下の処理において、出力結果を変えずにORをANDに書き換えよ。

df_store.Where( r => r.prefecture_cd != "13" && r.floor_area <= 900)
.DisplayTable()


*/

