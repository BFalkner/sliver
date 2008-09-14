#light

open Xunit
open Element
open Template

[<Fact>]
let TextBlock() =
    Assert.Equal("Test", Template.compile (Template [Text("Test")]))
