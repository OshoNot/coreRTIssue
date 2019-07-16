open Npgsql.FSharp

let rootConnection : string =
    Sql.host "localhost"
    |> Sql.port 5432
    |> Sql.username "dbuser"
    |> Sql.password "dbpassword"
    |> Sql.database "dbsample"
    |> Sql.str

let ExecuteSQL (q:string) : unit =
    rootConnection
    |> Sql.connect
    |> Sql.query q
    |> Sql.executeTable
    |> ignore

[<EntryPoint>]
let main argv =
    printfn "Hello World!"
    ExecuteSQL "SELECT * FROM map"
    0
