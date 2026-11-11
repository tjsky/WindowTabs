// Adds a language field to every text in Strings.fs, empty, so it can be translated in place.
//
//   dotnet fsi tools/add-language.fsx fr
//
// The field goes after `en` in each record. An empty field shows the English text (see
// docs/localization.md), so the app keeps working while the translations are filled in.
open System
open System.IO

let path = Path.Combine(__SOURCE_DIRECTORY__,"..","WtProgram","Shared","Strings.fs")

let code =
    match fsi.CommandLineArgs |> Array.skip 1 with
    | [| code |] when code |> Seq.forall Char.IsLetter -> code
    | _ -> failwith "Usage: dotnet fsi tools/add-language.fsx <code> (letters only, as in Localization.languages)"

let text = File.ReadAllText path
if text.Contains(sprintf "%s=" code) then failwithf "Strings.fs already has a %s field" code

/// Every `{ ... }` block, with where its body starts and ends, outside string literals.
let blocks =
    let out = ResizeArray()
    let open_ = System.Collections.Generic.Stack<int>()
    let mutable i = 0
    let mutable inString = false
    while i < text.Length do
        let c = text.[i]
        if inString then
            if c='\\' then i <- i+1
            elif c='"' then inString <- false
        elif c='"' then inString <- true
        elif c='{' then open_.Push i
        elif c='}' && open_.Count>0 then out.Add(open_.Pop(),i)
        i <- i+1
    List.ofSeq out

/// The value of a field in a record body: where it starts, where it ends, and the column its
/// name starts at. Fields are separated by a semicolon or a line break at the outermost level.
let field (bodyStart:int) (bodyEnd:int) (name:string) =
    let body = text.Substring(bodyStart,bodyEnd-bodyStart)
    let mutable depth = 0
    let mutable inString = false
    let mutable i = 0
    let mutable pos = 0
    let mutable found = None
    let cut () =
        let chunk = body.Substring(pos,i-pos)
        let parts = chunk.Split([|'='|],2)
        if parts.Length=2 && parts.[0].Trim()=name && found.IsNone then
            let value = parts.[1]
            let start = bodyStart + pos + (chunk.Length - value.Length) + (value.Length - value.TrimStart().Length)
            let stop = start + value.Trim().Length
            found <- Some(start,stop,bodyStart + pos + (chunk.Length - chunk.TrimStart().Length))
        pos <- i+1
    while i < body.Length do
        let c = body.[i]
        if inString then
            if c='\\' then i <- i+1
            elif c='"' then inString <- false
        elif c='"' then inString <- true
        elif c='(' || c='[' || c='{' then depth <- depth+1
        elif c=')' || c=']' || c='}' then depth <- depth-1
        elif depth=0 && (c=';' || c='\n') then cut ()
        i <- i+1
    cut ()
    found

/// The column of the record's first field, so an inserted one lines up with it.
let indentOf (offset:int) =
    let lineStart = if offset=0 then 0 else (text.LastIndexOf('\n',offset-1) + 1)
    String(' ',offset-lineStart)

let edits =
    [ for start,stop in blocks do
        let body = text.Substring(start+1,stop-start-1)
        if body.Contains "zh=" then
            match field (start+1) (stop-1) "en" with
            | Some(_,valueEnd,firstStart) ->
                let mutable after = valueEnd
                while after<text.Length && (text.[after]=' ' || text.[after]='\t') do after <- after+1
                let insert =
                    if after<text.Length && (text.[after]=';' || text.[after]='}') then sprintf "; %s=\"\"" code
                    else sprintf "\n%s%s=\"\"" (indentOf firstStart) code
                yield valueEnd,insert
            | None -> () ]

if edits.IsEmpty then failwith "No texts were found in Strings.fs"

let out = Text.StringBuilder(text)
for offset,insert in edits |> List.sortByDescending fst do
    out.Insert(offset,insert) |> ignore
File.WriteAllText(path,out.ToString().Replace("\r\n","\n"))
printfn "Added %s to %d texts in Strings.fs" code edits.Length
