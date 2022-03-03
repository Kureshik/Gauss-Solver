using System.Text.RegularExpressions;

namespace GaussSolve
{
    internal class Parser
    {
        string[] txt;
        string vars;
        public Parser(string[] txt, string vars)
        {
            this.txt = txt;
            this.vars = vars;
        }
        /*  / 1x + 2y + 3z = 1
         *  | 1x + 2y + 3z = 2
         *  \ 1x + 2y + 3z = 3
         * 
         * {
         *   {
         *    {1, 2, 3}
         *    {1, 2, 3}
         *    {1, 2, 3}
         *   }
         *    
         *   {1, 2, 3}
         * }
         */
        public coeffData Parse()
        {
            float[][] c = new float[vars.Length][];
            for (int i = 0; i < vars.Length; i++)
            { c[i] = new float[vars.Length];
            }
            coeffData data = new coeffData()
            {
                coeffs = c,
                free_coeffs = new float[vars.Length]
            };

            for (int i = 0;  i < vars.Length; i++)
            {
                for (int j = 0; j < vars.Length; j++)
                {
                    Regex CoeffFinder = new Regex($@"-? ?\d?{vars[j]}");
                    string tmp = CoeffFinder.Matches(txt[i])[0].Value;

                    tmp = tmp.Replace(" ", "").Replace(vars[j].ToString(), ""); // "1" "-1" "" "-"
                    if (tmp == "" || tmp == "-") tmp += "1"; // "" || "-" -> += 1
                    float coeff = Convert.ToSingle(tmp); 
                    data.coeffs[i][j] = coeff;
                }

                Regex free_CoeffFinder = new Regex(@"-?\d+$");
                string tmp2 = free_CoeffFinder.Matches(txt[i])[0].Value;

                tmp2 = tmp2.Replace(" ", "").Replace("=", ""); // "1" "-1"
                float free_coeff = Convert.ToSingle(tmp2); // "" || "-" -> += 1
                data.free_coeffs[i] = free_coeff;
            }

            return data;
            // /-? ?\d?x/g
            // /-?\d$/g
        }
    }
}
