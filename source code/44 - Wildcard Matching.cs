public class Solution
{
    public bool IsMatch(string s, string p)
    {
        var match = new bool[s.Length + 1][];

        int length = s.Length;
        int lengthP = p.Length;

        for (int i = 0; i < length + 1; i++)
        {
            match[i] = new bool[lengthP + 1];
        }

        match[length][lengthP] = true;

        // ? 
        for (int i = lengthP - 1; i >= 0; i--)
        {
            if (p[i] != '*')
            {
                break;
            }
            else
            {
                match[length][i] = true;
            }
        }

        for (int i = length - 1; i >= 0; i--)
        {
            for (int j = lengthP - 1; j >= 0; j--)
            {
                if (s[i] == p[j] || p[j] == '?')
                {
                    // one one match - for example, "abc","?bc"
                    match[i][j] = match[i + 1][j + 1];
                }
                else if (p[j] == '*')
                {
                    // explain using your own words
                    // match[i + 1][j], s[i] matchs ?, s[i] cannot be ignored
                    // match[i][j+1], * does not match anything
                    match[i][j] = match[i + 1][j] || match[i][j + 1];
                }
                else
                {
                    match[i][j] = false;
                }
            }
        }

        return match[0][0];
    }
}