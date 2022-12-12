using Npgsql;

internal class Program
{
    private static void Main(string[] args)
    {
        // 接続文字列
        string connectionStr = "Server=localhost;Port=5432;Username=postgres;Password=test;Database=test;";

        // 実行するクエリ
        string queryStr = "SELECT ";
        queryStr += "* ";
        queryStr += "FROM ";
        queryStr += "public.test";

        try
        {
            // DB接続用のインスタンスを生成
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionStr))
            {
                // DB接続開始
                connection.Open();

                Console.WriteLine("DB接続成功!");

                // クエリ実行用のインスタンスを生成
                using (NpgsqlCommand command = new NpgsqlCommand(queryStr, connection))
                {
                    // クエリ実行
                    using (NpgsqlDataReader reader = command.ExecuteReader())
                    {
                        // 実行結果を全行読み込む
                        while (reader.Read())
                        {
                            // idカラムの結果を表示
                            Console.WriteLine("id：" + reader["id"]);
                        }
                    }
                }
            }
        }
        // 例外処理
        catch (Exception ex)
        {
            Console.WriteLine("DB接続失敗\n" + ex);
        }
        
    }
}