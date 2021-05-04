using System;

namespace Core.Utils
{
    /// <summary>
    /// Classe de validação de CNPJ para documento
    /// Autor: Ronaldo Torre
    /// </summary>
    public class CNPJ
    {
        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">Int64 com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public Boolean CheckCNPJ(Int64 cnpj)
        {
            return CheckCNPJ(cnpj.ToString("D14"));
        }

        /// <summary>
        /// Informar um CNPJ completo para validação do digito verificador
        /// </summary>
        /// <param name="cnpj">string com o numero CNPJ completo com Digito</param>
        /// <returns>Boolean True/False onde True=Digito CNPJ Valido</returns>
        public Boolean CheckCNPJ(string cnpj)
        {
            string new_cnpj = "";

            for (int i = 0; i < cnpj.Length; i++)
            {
                if (isDigit(cnpj.Substring(i, 1)))
                {
                    new_cnpj += cnpj.Substring(i, 1);
                }
            }

            new_cnpj = Convert.ToInt64(new_cnpj).ToString("D14");

            if (new_cnpj.Length == 14)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">int64 com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public string CalculaDigCNPJ(Int64 cnpj)
        {
            return CalcDigCNPJ(cnpj.ToString("D12"));
        }

        /// <summary>
        /// Calcula o Digito verificador de um CNPJ informado  
        /// </summary>
        /// <param name="cnpj">string com o CNPJ contendo 12 digitos e sem o digito verificador</param>
        /// <returns>string com o digito calculado do CNPJ ou null caso o CNPJ informado for maior que 12 digitos</returns>
        public string CalcDigCNPJ(string cnpj)
        {
            string new_cnpj = "";
            string digit = "";
            int[] calc = new int[] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Int32 Aux1 = 0;
            Int32 Aux2 = 0;

            new_cnpj = cnpj.Substring(0, 12);

            if (new_cnpj.Length > 12)
            {
                return null;
            }

            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calc[i];
            }

            Aux2 = (Aux1 % 11);

            if (Aux2 < 2)
                digit += "0";
            else
                digit += (11 - Aux2).ToString();
            
            new_cnpj += digit;

            calc = new int[] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            Aux1 = 0;

            for (int i = 0; i < new_cnpj.Length; i++)
            {
                Aux1 += Convert.ToInt32(new_cnpj.Substring(i, 1)) * calc[i];
            }

            Aux2 = (Aux1 % 11);

            if (Aux2 < 2)
            {
                digit += "0";
            }
            else
            {
                digit += (11 - Aux2).ToString();
            }

            return digit;
        }

        /// <summary>
        /// Verifica se um digito informado é um numero
        /// </summary>
        /// <param name="digit">string com um caracter para verificar se é um numero</param>
        /// <returns>Boolean True/False</returns>
        private Boolean isDigit(string digit)
        {
            int n;
            return Int32.TryParse(digit, out n);
        }
    }
}