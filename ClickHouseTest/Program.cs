using ClickHouse.Client.ADO;
using ClickHouse.Client.Copy;
using ClickHouse.Client.Utility;

///
///docker run --rm -e CLICKHOUSE_DB=my_database -e CLICKHOUSE_USER=username -e CLICKHOUSE_DEFAULT_ACCESS_MANAGEMENT=1 -e CLICKHOUSE_PASSWORD=password -p 8123:8123 clickhouse/clickhouse-server
///

using var connection = new ClickHouseConnection("Host=localhost;Database=my_database;Protocol=http;Port=8123;Username=username;Password=password");
// ExecuteScalarAsync is an async extension which creates command and executes it
//var version = await connection.ExecuteScalarAsync("SELECT version()");
//Console.WriteLine(version);

var version = await connection.ExecuteScalarAsync("SELECT * FROM system.tables");
Console.WriteLine(version);

//using var bulkCopyInterface = new ClickHouseBulkCopy(connection)
//{
//    DestinationTableName = "my_database.NumberField",
//    BatchSize = 100000
//};
//// Example data to insert
//var values = Enumerable.Range(0, 1000000).Select(i => new object[] { (long)i, "value" + i.ToString() });
////await bulkCopyInterface.InitAsync();
//await bulkCopyInterface.WriteToServerAsync(values);
//Console.WriteLine(bulkCopyInterface.RowsWritten);