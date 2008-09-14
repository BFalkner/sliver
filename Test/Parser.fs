#light

open Xunit
open Lexing
open Element

[<Fact>]
let TextBlock() =
    Assert.Equal([Text("Test")], Parser.template Lexer.lexer (Lexing.from_string "Test"))
