// (* File MicroC/MicroCC.fs *)

// module MicroCC

// let args = System.Environment.GetCommandLineArgs();;

// let _ = printf "Micro-C backwards compiler v 1.0.0.0 of 2012-02-13\n";;

// let _ = 
//    if args.Length > 1 then
//       let source = args.[1]
//       let stem = if source.EndsWith(".c")
//                  then source.Substring(0,source.Length-2) 
//                  else source
//       let target = stem + ".out"
//       printf "Compiling %s to %s\n" source target;
//       try ignore (Contcomp.contCompileToFile (Parse.fromFile source) target)
//       with Failure msg -> printf "ERROR: %s\n" msg
//    else
//       printf "Usage: microcc <source file>\n";;


let fromFile = Parse.fromFile
let compileToFile = Contcomp.contCompileToFile

let argv = System.Environment.GetCommandLineArgs()

let args = Array.filter ((<>) "-g") argv

let _ = printfn "Micro-C Stack VM compiler v 1.2.0 of 2022-5-12"

let _ =
    if args.Length > 1 then
        let source = args.[1]

        let stem =
            if source.EndsWith(".c") then
                source.Substring(0, source.Length - 2)
            else
                source

        let target = stem + ".out"

        printfn "Compiling %s ......\n" source

        try
            (let instrs = compileToFile (fromFile source) stem
             // printf "StackVM code:\n%A\n" instrs;
             printfn "Numeric code saved in file:\n\t%s\nPlease run with VM." target)
        with
        | Failure msg -> printfn "ERROR: %s" msg
        | exn -> printfn "ERROR: %s" exn.Message
    else
        printfn "Usage: microc.exe <source file>"
