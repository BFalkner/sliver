#light

open System.Text
open System.IO
open Element
open Lexer
open Parser

type template = Template of element list

let compile (Template l) =
    let compile_node n =
        match n with
        | Text t -> t
    List.map compile_node l
    |> String.concat ""

let private path = @"C:\wikidata\"

let (|LoadTemplate|_|) name =
    if File.Exists (path + name) then
        new StreamReader(path + name)
        |> Lexing.from_text_reader Encoding.ASCII
        |> Parser.template Lexer.lexer
        |> Template
        |> Some
    else
        None
