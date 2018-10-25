public class Solution
{
    public string CountOfAtoms(string formula)
    {

        string result = string.Empty;
        // "K4(ON(SO3)2)2"
        int open_brackets = 0;
        var d = new Dictionary<string, int>();
        var name_stack = new Stack<string>();
        var value_stack = new Stack<int>();

        for (int i = 0; i < formula.Length; i++)
        {
            string atom = string.Empty;
            //(H2O)2
            if (formula[i] == '(')
            {
                open_brackets++;
                name_stack.Push("(");
                value_stack.Push(-1);
            }
            else if (formula[i] == ')')
            {
                open_brackets--;

                i++;
                while (i < formula.Length && char.IsDigit(formula[i]))
                {
                    atom += formula[i];
                    i++;
                }

                i--;
                int mul = atom.Length > 0 ? int.Parse(atom) : 1;

                if (open_brackets > 0)
                {
                    var temp_name_stack = new Stack<string>();
                    var temp_value_stack = new Stack<int>();

                    while (name_stack.Count > 0 && name_stack.Peek() != "(")
                    {
                        temp_name_stack.Push(name_stack.Pop());
                        temp_value_stack.Push(value_stack.Pop() * mul);
                    }

                    name_stack.Pop();
                    value_stack.Pop();

                    while (temp_name_stack.Count > 0)
                    {
                        name_stack.Push(temp_name_stack.Pop());
                        value_stack.Push(temp_value_stack.Pop());
                    }
                }
                else
                {
                    while (name_stack.Count > 0 && name_stack.Peek() != "(")
                    {
                        if (d.ContainsKey(name_stack.Peek()))
                        {
                            d[name_stack.Pop()] += mul * value_stack.Pop();
                        }
                        else
                        {
                            d.Add(name_stack.Pop(), mul * value_stack.Pop());
                        }
                    }

                    name_stack.Pop();
                    value_stack.Pop();
                }
            }


            else if (char.IsLetter(formula[i]) && char.IsUpper(formula[i]))
            {
                atom += formula[i];
                i++;

                while (i < formula.Length && char.IsLower(formula[i]))
                {
                    atom += formula[i];
                    i++;
                }

                string value = "";

                while (i < formula.Length && char.IsDigit(formula[i]))
                {
                    value += formula[i];
                    i++;
                }

                i--;
                int m = value.Length > 0 ? int.Parse(value) : 1;
                if (open_brackets > 0)
                {
                    name_stack.Push(atom);
                    value_stack.Push(m);
                }
                else
                {
                    if (d.ContainsKey(atom))
                    {
                        d[atom] += m;
                    }
                    else
                    {
                        d.Add(atom, m);
                    }
                }
            }
        }

        while (name_stack.Count > 0)
        {
            if (d.ContainsKey(name_stack.Peek()))
            {
                d[name_stack.Pop()] += value_stack.Pop();
            }
            else
            {
                d.Add(name_stack.Pop(), value_stack.Pop());
            }
        }

        d.OrderBy((x) => x.Key).ToList().ForEach(y =>
        {
            result += y.Key;
            if (y.Value > 1)
            {
                result += y.Value;
            }
        });

        return result;
    }


}