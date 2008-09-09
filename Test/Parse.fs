#light

open Xunit
open Lexing
open Template

[<Fact>]
let TextBlock() =
    Assert.Equal(Template([Text("Test")]), Parse.template Lex.lexer (Lexing.from_string "Test"))
