using System.Threading.Channels;

int i = 34;
object iBoxed = i;
int? jNullable = 42;
if (iBoxed is int a && jNullable is int b)
{
    Console.WriteLine(a + b);  // output 76
}


var p = 50;
object pBoxed = p;
int? someNullabe = 500;

if (pBoxed is int x && someNullabe is int k)
{
    Console.WriteLine(x + k);
}

var d = "asd";
object dBoxed = d;
string? some = "testtt";
if (dBoxed is string kk && some is string l)
{
    Console.WriteLine(string.Concat(kk, l));
}


int[] numbers = new[] { 0, 10, 20, 30, 40, 50 };
int start = 1;
int amountToTake = 3;
var firstRange = start..(start + amountToTake);

int[] subset = numbers[firstRange];
Display(subset);  // output: 10 20 30


//  ..            All values in the collection.
//  ..end         Values from the start to the end exclusively.
//  start..       Values from the start inclusively to the end.
//  start..end    Values from the start inclusively to the end exclusively.
//  ^start..      Values from the start inclusively to the end counting from the end.
//  ..^end        Values from the start to the end exclusively counting from the end.
//  start..^end   Values from start inclusively to end exclusively counting from the end.
//  ^start..^end  Values from start inclusively to end exclusively both counting from the end.
Console.WriteLine(new string('=', 50));

var test = new int[] { 5, 10, 12, 13, 14, 22 };
//  start..end
var rr = 1..3; // 10, 12
//  ..
var tt = ..; // 5, 10, 12, 13, 14, 22
//  start..
var dd = 2..; // 12 13 14 22
//  ..end
var pp = ..(test.Length - 2); // 5 10 12 13
//  ^start..
var ff = ^2..; // 14 22
//  ..^end
var gg = ..^1; // 5 10 12 13 14
//  start..^end
var xx = 2..^1; // 12 13 14
//  ^start..^end
var oo = ^4..^1; // 12 13 14

Display(test[rr]);
Display(test[tt]);
Display(test[dd]);
Display(test[pp]);
Display(test[ff]);
Display(test[gg]);
Display(test[xx]);
Display(test[oo]);

//int margin = 1;
//var secondRange = margin..^margin;
//int[] inner = numbers[secondRange];
//Display(inner);  // output: 10 20 30 40

//string line = "one two three";
//int amountToTakeFromEnd = 5;
//Range endIndices = ^amountToTakeFromEnd..^0;
//string end = line[endIndices];
//Console.WriteLine(end);  // output: three

void Display<T>(IEnumerable<T> xs) => Console.WriteLine(string.Join(" ", xs));