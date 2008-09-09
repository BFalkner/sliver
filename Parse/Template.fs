#light

type node =
    | Text of string
    
type template = Template of node list
