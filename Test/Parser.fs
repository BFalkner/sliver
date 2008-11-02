#light

open Xunit
open Lexing
open Element

let Parse s =
    Parser.template Lexer.lexer (Lexing.from_string s)

[<Fact>]
let TextTest() =
    Assert.Equal([Text("Text Test")], Parse "Text Test")

[<Fact>]
let AnchorTest() =
    Assert.Equal([Anchor("http://google.com/", "http://google.com/")], Parse "<http://google.com/>")
    
[<Fact>]
let AnchorWithTextTest() =
    Assert.Equal([Anchor("Google Search Engine", "http://google.com/")], Parse "\"Google Search Engine\" <http://google.com/>")

[<Fact>]
let OrderedListTest() =
    Assert.Equal([OrderedList([Text("Blah"); Text("Meh")])], Parse "# Blah\n# Meh")
    
[<Fact>]
let UnorderedListTest() =
    Assert.Equal([UnorderedList([Text("Blah"); Text("Meh")])], Parse "* Blah\n* Meh")

[<Fact>]
let ComponentTest() =
    Assert.Equal([Component()], Parse "[post:blah]")
