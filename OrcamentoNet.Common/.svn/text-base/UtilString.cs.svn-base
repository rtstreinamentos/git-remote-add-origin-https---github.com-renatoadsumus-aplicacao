using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OrcamentoNet.Common
{
    public class UtilString
    {
        public static string RemoverAcentos(string textoComAcentos)
        {
            if (String.IsNullOrEmpty(textoComAcentos)) return String.Empty;

            Regex acentosLetraA = new Regex("[á|à|ä|â|ã]", RegexOptions.Compiled);
            Regex acentosLetraC = new Regex("[ç]", RegexOptions.Compiled);
            Regex acentosLetraE = new Regex("[é|è|ë|ê]", RegexOptions.Compiled);
            Regex acentosLetraI = new Regex("[í|ì|ï|î]", RegexOptions.Compiled);
            Regex acentosLetraO = new Regex("[ó|ò|ö|ô|õ]", RegexOptions.Compiled);
            Regex acentosLetraU = new Regex("[ú|ù|ü|û]", RegexOptions.Compiled);

            textoComAcentos = acentosLetraA.Replace(textoComAcentos, "a");
            textoComAcentos = acentosLetraC.Replace(textoComAcentos, "c");
            textoComAcentos = acentosLetraE.Replace(textoComAcentos, "e");
            textoComAcentos = acentosLetraI.Replace(textoComAcentos, "i");
            textoComAcentos = acentosLetraO.Replace(textoComAcentos, "o");
            string textoSemAcentos = acentosLetraU.Replace(textoComAcentos, "u");
            return textoSemAcentos;
        }

        public static string GerarPalavraTermoPesquisa(string termoPesquisa)
        {
            return termoPesquisa;
        }

        public static string GerarUrlParaSeo(string nomeSemTratamento)
        {
            if (String.IsNullOrEmpty(nomeSemTratamento)) return String.Empty;

            string nomeAmigavel = nomeSemTratamento.Replace(",", String.Empty);

            nomeAmigavel = nomeAmigavel.Replace("(", "-");
            nomeAmigavel = nomeAmigavel.Replace("...", String.Empty);
            nomeAmigavel = nomeAmigavel.Replace(")", "-");
            nomeAmigavel = nomeAmigavel.Replace("/", "-");
            nomeAmigavel = nomeAmigavel.Replace(".", "-");
            nomeAmigavel = nomeAmigavel.Replace("!", "-");
            nomeAmigavel = nomeAmigavel.Replace("15", "-");

            string[] listaNomesCategorias = nomeAmigavel.Split(' ');

            List<string> listaNomesCategoriasModificadas = new List<string>();
            for (int i = 0; i < listaNomesCategorias.Length; i++)
            {
                if (listaNomesCategorias[i].Length > 1) listaNomesCategoriasModificadas.Add(listaNomesCategorias[i]);
            }

            nomeAmigavel = String.Join("-", listaNomesCategoriasModificadas.ToArray());
            nomeAmigavel = nomeAmigavel.ToLower();
            nomeAmigavel = UtilString.RemoverAcentos(nomeAmigavel);

            return nomeAmigavel;
        }

        public static String[] ObterExtensoesArquivosValidos()
        {
            String[] allowedExtensions = { ".gif", ".png", ".jpeg", ".jpg", ".pdf", ".xls", ".xlsx", ".doc", ".docx", ".txt" };
            
            return allowedExtensions;
        }
    }
}
