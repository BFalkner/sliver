#light

open Xunit
open Lexing
open Template

[<Fact>]
let TextBlock() =
    Assert.Equal(Template([Text("Test")]), Parser.template Lexer.lexer (Lexing.from_string "Test"))
