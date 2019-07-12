# Span benchmark

This sample runs a benchmark, illustrating some unexpected results. The benchmark 
explores 3 approaches for parsing a text file. Each approach is run twice, 
once parsing a single row of 252 bytes from the file, and then again parsing 50 rows of 252 bytes. 

## Approaches:

#### WithoutSpan
Parses the file in a traditional fashion by using a __StreamReader__, and __Substring__ for each field.

#### WithSpan
Parses the file using __Span&lt;byte&gt;__ and then __Slice__ and __encoding.GetString(ReadOnlySpan&lt;byte&gt;)__ for each field.

#### WithSpan (StringFirst)
Parses the file by first converting the byte array to a string, and then referencing it using a  __Span&lt;char&gt;__ and then __Slice__ for each field.

## Expectation
From what I understand from Span, I would expect the approaches using Span to exhibit a significantly lower amount of allocated memory
and possibly a considerable lower mean execution time.

## Actual Results
Although when parsing 1 row from the text file, the results confirm the expectation (less allocated memory and lower mean exeuction time),
the second run parsing 50 rows from the same text file shows a far smaller difference, making it almost negligible.

|               Method | RowCount |        Mean |   Gen 0 |  Gen 1 | Gen 2 | Allocated |
|--------------------- |--------- |------------:|--------:|-------:|------:|----------:|
|             WithSpan |        1 |    638.2 ns |  0.2298 | 0.0010 |     - |   1.41 KB |
| WithSpan_StringFirst |        1 |    521.7 ns |  0.3147 | 0.0010 |     - |   1.94 KB |
|          WithoutSpan |        1 |  1,260.6 ns |  0.9270 | 0.0095 |     - |    5.7 KB |
|             WithSpan |       50 | 31,935.7 ns | 11.4746 |      - |     - |   70.7 KB |
| WithSpan_StringFirst |       50 | 24,503.3 ns | 15.5029 | 1.1902 |     - |  95.34 KB |
|          WithoutSpan |       50 | 26,990.0 ns | 16.3574 | 0.2747 |     - | 100.64 KB |

## How To Run
Set build configuration to __Release__ and run the solution. Let the benchmark run and observe the results in the console.