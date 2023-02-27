

using _01.Index;

var privateProtected = new PrivateProtectedBase();


Console.WriteLine(privateProtected);
//using named arguments
var derived = new Derived(age: 5, name: "Some Other name");

Console.WriteLine(privateProtected);
Console.WriteLine(derived);