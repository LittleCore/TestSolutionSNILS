using System;

namespace testSolution
{
    class SNILSValidateChecker
    {

        public Boolean SNILSValidate(String snils)
        {
            OnlyDigits(snils);
            String workSnils = snils;
            Boolean result = false;

            if (workSnils.Length == 9)
            {
                if (SNILSContolCalc(workSnils) > -1)
                {
                    result = true;
                }
            }
            else if (workSnils.Length == 11)
            {
                int controlSum = SNILSContolCalc(workSnils);
                int strControlSum = int.Parse(workSnils.Substring(9, 2));
                if (controlSum == strControlSum)
                {
                    result = true;
                }
            }
            else
            {
                throw new Exception(String.Format("Некорректный СНИЛС. {0} цифр. (Должно быть 9 или 11 цифр.)", workSnils.Length));
            }

            return result;
        }

        public int SNILSContolCalc(String snils)
        {
            OnlyDigits(snils);
            String workSnils = snils;

            if (workSnils.Length != 9 && workSnils.Length != 11)
            {
                throw new Exception(String.Format("Некорректный СНИЛС. {0} цифр. (Должно быть 9 или 11 цифр.)", workSnils.Length));
            }

            if (workSnils.Length == 11)
            {
                workSnils = workSnils.Substring(0, 9);
            }

            int totalSum = 0;
            for (int i = workSnils.Length - 1, j = 0; i >= 0; i--, j++)
            {
                int digit = int.Parse(workSnils[i].ToString());
                totalSum += digit * (j + 1);
            }

            return SNILSCheckControlSum(totalSum);
        }

        private int SNILSCheckControlSum(int _controlSum)
        {
            int result;
            if (_controlSum < 100)
            {
                result = _controlSum;
            }
            else if (_controlSum <= 101)
            {
                result = 0;
            }
            else
            {
                int balance = _controlSum % 101;
                result = SNILSCheckControlSum(balance);
            }
            return result;
        }

        public String OnlyDigits(String source)
        {
            String result = String.Empty;

            foreach (Char ch in source)
            {
                if (Char.IsDigit(ch))
                {
                    result += ch;
                }
            }

            return result;
        }
    }
}
