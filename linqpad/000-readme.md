## 環境構築手順

``` cs
var file = "test";
```

## Sqlite データベースの初期化

https://sqlitebrowser.org/dl/
から SQLiteBrwoser をダウンロードする

## Sqlite データベースの管理ツール

```
 1. 公式サイトを開く: https://www.sqlite.org/download.html
 2. Precompiled Binaries for Windows から
sqlite-tools-win-x64-*.zip をダウンロード
 3. ZIP を展開して、sqlite3.exe を C:\sqlite\ などに置く
 4. そのフォルダを PATH に追加
 5. コマンドプロンプトで実行: sqlite3 sample.db
```

sqlite3 sample.db を実行するとき 対象のDBファイルが存在しない場合は新規作成される。

