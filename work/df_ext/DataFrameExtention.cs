namespace df_ext;

using Microsoft.Data.Analysis;
public static class DataFrameExtention {
    /// <summary>
    /// カラム名を指定してDataFrameを作成する
    /// </summary>
    /// <param name="df">データフレーム</param>
    /// <param name="columnNames">取得するカラム名を複数指定する</param>
    /// <returns></returns>
    public static DataFrame SelectWithColumn(this DataFrame df, params string[] columnNames) {
        DataFrameColumn[] columns = new DataFrameColumn[columnNames.Length];
        for(int i = 0; i < columnNames.Length; i++) {
            columns[i] = df.Columns[columnNames[i]];
        }
        return new DataFrame(columns);
    }

    /// <summary>
    /// カラム名を変更する
    /// </summary>
    /// <param name="df"></param>
    /// <param name="oldColumnName"></param>
    /// <param name="newColumnName"></param>
    /// <returns></returns>
    public static DataFrame ChangeColumnName(this DataFrame df, string oldColumnName, string newColumnName) {
        DataFrameColumn[] columns = new DataFrameColumn[df.Columns.Count];
        for(int i = 0; i < df.Columns.Count; i++) {
            
            if(df.Columns[i].Name == oldColumnName) {
                columns[i] = df.Columns[i].Clone();
                columns[i].SetName(newColumnName);
            } else {
                columns[i] = df.Columns[i];
            }
        }
        return new DataFrame(columns);
    }
}
