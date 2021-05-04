using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utils
{
    /// <summary>
    /// Classe de validação de CNPJ para documento
    /// Autor: Ronaldo Torre
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Verificar se o documento é valido
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public string CheckDocument(string document)
        {
            string doc = document.Trim().Replace(".", "").Replace("-", "").Replace("/", "");
            string element = string.Empty;
            bool aux = false;

            if (doc.Length == 11) 
            {
                element = "CPF";
                aux = new CPF().CheckCPF(doc);
            }
            else if (doc.Length == 14) 
            {
                element = "CNPJ";
                aux = new CNPJ().CheckCNPJ(doc);
            }

            if(aux == false)
                return $"{element}: {document} is Inválid!";
            else
                return $"{element}: {document} is Ok!";
        }

        /// <summary>
        /// Validar documento e calcular o digito
        /// </summary>
        /// <param name="document"></param>
        /// <returns></returns>
        public string CalcDigit(string document)
        {
            string doc = document.Trim().Replace(".", "").Replace("-","").Replace("/","");
            string ret = string.Empty;

            if (doc.Length == 11)
                ret = new CPF().CalcDigCPF(doc);
            else if (doc.Length == 14)
                ret = new CNPJ().CalcDigCNPJ(doc);

            return ret;
        }
    }
}