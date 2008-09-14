#light

open Element

type template = Template of element list

let compile (Template l) =
    let compile_node n =
        match n with
        | Text t -> t
    List.map compile_node l
    |> String.concat ""
