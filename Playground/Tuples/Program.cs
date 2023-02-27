using Tuples;

var givenAge = 5;
var givenName = "pesho";
var givenSchool = "some";
var (age, name, school) = (givenAge, givenName, givenSchool);

if ((age, name, school) == (givenAge, givenName, givenSchool))
{
    Console.WriteLine($"{name} is {age} years old, and studies as {school}");
}


