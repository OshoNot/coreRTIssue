open Npgsql.FSharp

let rootConnection : string =
    Sql.host "database"
    |> Sql.port 5432
    |> Sql.username "dbuser"
    |> Sql.password "dbpassword"
    |> Sql.database "dbsample"
    |> Sql.str

type M = {
    Name : string;
    Value : string
}

let ExecuteSQL (q:string) : unit =
    rootConnection
    |> Sql.connect
    |> Sql.query q
    |> Sql.executeTable
    |> Sql.mapEachRow (function
        | [ "name", SqlValue.String name
            "value", SqlValue.String value ] ->
          let user =
            { Name = name;
              Value = value }
          Some user
        | _ -> None)
    |> List.map (printfn "%A")
    |> ignore

[<EntryPoint>]
let main argv =
    printfn "Hello World!"
    ExecuteSQL "SELECT * FROM map"
    0
