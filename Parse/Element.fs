#light

type element =
    | Text of string
    | Anchor of string * string
    | OrderedList of element list
    | UnorderedList of element list
    | Component of unit
