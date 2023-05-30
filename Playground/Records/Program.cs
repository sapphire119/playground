// See https://aka.ms/new-console-template for more information
using Records;

Console.WriteLine("Hello, World!");

Person person = new("pesho", "peshev");


LazyNew lazyNew = new("pesho") { Age = 25 };
Console.WriteLine(lazyNew);