open Npgsql

let connectDB = 
  new NpgsqlConnection("Host=database;Username=dbuser;Password=dbpassword;Database=dbsample")

[<EntryPoint>]
let main argv =
    connectDB |> ignore
    0
