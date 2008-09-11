#light

open Xunit
open Template

[<Fact>]
let TextBlock() =
    Assert.Equal("Test", Template.compile (Template [Text("Test")]))
