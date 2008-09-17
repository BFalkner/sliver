#light

open System.Text
open System.IO
open Element

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
        Some(Template(Parser.template Lexer.lexer (Lexing.from_text_reader Encoding.ASCII (new StreamReader(path + name)))))
    else
        None
