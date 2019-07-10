// Learn more about F# at http://fsharp.org

open System
open Npgsql
open Npgsql.FSharp

let rootConnection : string =
    Sql.host "database"
    |> Sql.port 5432
    |> Sql.username "dbuser"
    |> Sql.password "dbpassword"
    |> Sql.database "dbsample"
    |> Sql.str

let ExecuteSys(q:string ) : int= 
    rootConnection 
    |> Sql.connect
    |> Sql.query q 
    |> Sql.executeNonQuery


[<EntryPoint>]
let main argv =
    ExecuteSys("""
    CREATE table users( 
        id serial PRIMARY KEY,
        name text
    )""") |> ignore;
    printfn "User table created" 
    printfn "Hello World from F#!"
    0 // return an integer exit code
