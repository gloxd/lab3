open System
open System.IO

// Задание 1: Максимальные цифры через Seq.map
let getMaxDigitsSeq (numbers: int list) : int list =
    numbers
    |> Seq.map (fun number ->
        number.ToString()
        |> Seq.map (fun c -> int c - int '0')
        |> Seq.max)
    |> Seq.toList

// Задание 2: Суммарная длина строк через Seq.fold
let getTotalLengthFold (strings: string list) : int =
    strings
    |> Seq.fold (fun acc str -> acc + str.Length) 0

// Задание 3: Первый по алфавиту файл в каталоге
let getFirstFileAlphabetically (directoryPath: string) : string option =
    try
        if Directory.Exists(directoryPath) then
            Directory.GetFiles(directoryPath)
            |> Seq.map Path.GetFileName
            |> Seq.filter (fun name -> name <> null)
            |> Seq.sort
            |> Seq.tryHead
        else
            printfn "Указанный каталог не существует"
            None
    with
    | ex -> 
        printfn "Ошибка при чтении каталога: %s" ex.Message
        None

// Функция для ввода чисел
let inputNumbers () =
    printf "Введите натуральные числа через пробел: "
    let input = Console.ReadLine()
    input.Split(' ')
    |> Array.filter (fun s -> s <> "")
    |> Array.map int
    |> Array.toList

// Функция для ввода строк
let inputStrings () =
    printf "Введите строки через пробел: "
    let input = Console.ReadLine()
    input.Split(' ')
    |> Array.filter (fun s -> s <> "")
    |> Array.toList

[<EntryPoint>]
let main argv =
    // Задание 1
    printfn "=== ЗАДАНИЕ 1: Максимальные цифры через Seq.map ==="
    let numbers = inputNumbers()
    let maxDigits = getMaxDigitsSeq numbers
    printfn "Исходный список чисел: %A" numbers
    printfn "Максимальные цифры: %A" maxDigits
    printfn ""
    
    // Задание 2
    printfn "=== ЗАДАНИЕ 2: Суммарная длина строк через Seq.fold ==="
    let strings = inputStrings()
    let totalLength = getTotalLengthFold strings
    printfn "Исходный список строк: %A" strings
    printfn "Суммарная длина строк: %d" totalLength
    printfn ""
    
    // Задание 3
    printfn "=== ЗАДАНИЕ 3: Первый по алфавиту файл в каталоге ==="
    printf "Введите путь к каталогу: "
    let path = Console.ReadLine()
    
    match getFirstFileAlphabetically path with
    | Some file -> printfn "Первый файл по алфавиту: %s" file
    | None -> printfn "Не удалось найти файлы в указанном каталоге"
    
    0