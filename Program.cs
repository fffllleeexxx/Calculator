Console.WriteLine("Введите пример (например, 2 + 3 * 4 / 2):");
string input = Console.ReadLine();

string[] elements = input.Split(' ');
List<int> operandList = new List<int>();
List<string> operatorList = new List<string>();
List<string> elementsList = new List<string>(elements);



int number1 = 0;
int number2 = 0;
string op = null;


Dictionary<string, int> operations = new Dictionary<string, int>
{
    { "+", 1},
    { "-", 1 },
    { "*", 2 },
    { "/", 2 }
};


if (elements.Length < 3)
{
    Console.WriteLine("Некорректный ввод. Пожалуйста, введите пример в формате 'число операция число'.");
    return;
}

for (int i = 0; i < elements.Length; i++)
{
    if (i % 2 == 0)
    {
        operandList.Add(Convert.ToInt32(elements[i]));
    }
    else { operatorList.Add(Convert.ToString(elements[i])); }
}

for (int i = 0; i < operatorList.Count; i++)
{
    for (int j = 0; j < operatorList.Count - 1; j++)
    {
        if (operations[operatorList[j]] == 1)
        {
            string temp = operatorList[j];
            operatorList[j] = operatorList[j + 1];
            operatorList[j + 1] = temp;
        }
    }
}
metka:
for (int i = 0; i < operatorList.Count; i++)
{

    for (int j = 1; j < elementsList.Count;)
    {
        if (operatorList[i] == elementsList[j])
        {
            op = elementsList[j];
            number2 = Convert.ToInt32(elementsList[j + 1]);
            number1 = Convert.ToInt32(elementsList[j - 1]);

            double intermediateResult = op == "*" ? number1 * number2 :
                                        op == "/" ? number1 / number2 :
                                        op == "+" ? number1 + number2 :
                                        op == "-" ? number1 - number2 :
                                        double.NaN;

            elementsList.RemoveAt(j);
            elementsList.RemoveAt(j);
            elementsList[j - 1] = Convert.ToString(intermediateResult);

            Console.WriteLine("Промежуточный результат: " + intermediateResult);
            i++;
            goto metka;
        }
        else
        {
            j += 2;
        }
    }
}


