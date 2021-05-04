using System;

namespace Core.Utils
{
    /// <summary>
    /// Classe de validação de CNPJ para documento
    /// Autor: Ronaldo Torre
    /// </summary>
    public class CPF
    {
        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">Int64 com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public Boolean CheckCPF(Int64 cpf)
        {
            return CheckCPF(cpf.ToString("D11"));
        }

        /// <summary>
        /// Informar um CPF completo para validação do digito verificador
        /// </summary>
        /// <param name="cpf">string com o numero CPF completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CPF Valido</returns>
        public Boolean CheckCPF(string cpf)
        {
            string new_cpf = "";

            for (int i = 0; i < cpf.Length; i++)
            {
                if (isDigit(cpf.Substring(i, 1)))
                {
                    new_cpf += cpf.Substring(i, 1);
                }
            }

            new_cpf = Convert.ToInt64(new_cpf).ToString("D11");

            if (new_cpf.Length > 11)
            {
                return false;
            }

            if (CalcDigCPF(new_cpf.Substring(0, 9)) == new_cpf.Substring(9, 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">int64 com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public string CalcDigCPF(Int64 cpf)
        {
            return CalcDigCPF(cpf.ToString("D9"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CPF informado  
        /// </summary>
        /// <param name="cpf">string com o CPF contendo 9 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CPF ou null caso o cpf informado for maior que 9 digitos</returns>
        public string CalcDigCPF(string cpf)
        {
            string new_cpf = "";
            string digit = "";
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            new_cpf += cpf.Substring(0, 9);

            if (new_cpf.Length > 9)
            {
                return null;
            }

            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (10 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            if (Aux2 > 9)
                digit += "0";
            else
                digit += Aux2.ToString();
            
            new_cpf += digit;

            Aux1 = 0;

            for (int i = 0; i < new_cpf.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cpf.Substring(i, 1)) * (11 - i);
            }

            Aux2 = 11 - (Aux1 % 11);

            if (Aux2 > 9)
                digit += "0";
            else
                digit += Aux2.ToString();

            return digit;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digit">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        private static Boolean isDigit(string digit)
        {
            int n;
            return Int32.TryParse(digit, out n);
        }

    }
}