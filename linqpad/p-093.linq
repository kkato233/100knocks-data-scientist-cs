<Query Kind="Expression" />

/*
P-093: 商品データフレーム（df_product）では各カテゴリのコード値だけを保有し、カテゴリ名は保有していない。
カテゴリデータフレーム（df_category）と組み合わせて非正規化し、カテゴリ名を保有した新たな商品データフレームを作成せよ。

緯度（ラジアン）：\phi \\
経度（ラジアン）：\lambda \\
距離L = 6371 * arccos(sin \phi_1 * sin \phi_2
 + cos \phi_1 * cos \phi_2 * cos(\lambda_1 − \lambda_2))
*/

