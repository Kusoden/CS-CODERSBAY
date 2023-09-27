int firstNum = 138;
int secondNum = 235;

int sum = firstNum + secondNum;
int product = firstNum * secondNum;
int quotient = firstNum / secondNum;
int difference = firstNum - secondNum;

Console.WriteLine("+---+---+---+---+---+---+---+");




Console.WriteLine($"{firstNum} + {secondNum} = {firstNum + secondNum}");
Console.WriteLine($"{firstNum} - {secondNum} = {firstNum - secondNum}");
Console.WriteLine($"{firstNum} * {secondNum} = {firstNum * secondNum}");
Console.WriteLine($"{firstNum} / {secondNum} = {(double)firstNum / secondNum:F2}");

Console.WriteLine();

double firstFractNum = 10.5;
double secondFractNum = 3.2;

Console.WriteLine($"{firstFractNum:F2} + {secondFractNum:F2} = {(firstFractNum + secondFractNum):F2}");
Console.WriteLine($"{firstFractNum:F2} - {secondFractNum:F2} = {(firstFractNum - secondFractNum):F2}");
Console.WriteLine($"{firstFractNum:F2} * {secondFractNum:F2} = {(firstFractNum * secondFractNum):F2}");
Console.WriteLine($"{firstFractNum:F2} / {secondFractNum:F2} = {(firstFractNum / secondFractNum):F2}");
Console.WriteLine("+---+---+---+---+---+---+---+");