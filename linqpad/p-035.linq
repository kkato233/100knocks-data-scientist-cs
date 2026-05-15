<Query Kind="Expression" />

/*
P-035: レシート明細データフレーム（df_receipt）に対し、顧客ID（customer_id）ごとに売上金額（amount）
を合計して全顧客の平均を求め、平均以上に買い物をしている顧客を抽出せよ。ただし、顧客IDが"Z"から始まるのものは非会員を表すため、
除外して計算すること。なお、データは10件だけ表示させれば良い。

var_sample <- function(x){ var(x)*(length(x)-1)/length(x) }
std_sample <- function(x){ sqrt(var_sample(x)) }

*/

