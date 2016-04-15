using System;
using System.Text.RegularExpressions;

namespace OrcamentoNet.Common
{
    public class ValidadorDados
    {

        /// <summary>
        /// Validação dentro de um conjunto de valores aceitos; o parâmetro recebido deve coincidir com um dos valores.
        /// </summary>
        /// <param name="conteudoRecebido">texto a ser validado</param>
        /// <param name="valoresAceitos">valores permitidos separados por |</param>
        /// <param name="ignorarMaisculas"></param>
        /// <returns>true = válido; false = inválido</returns>
        public bool ValidarConjuntoObrigatorio(string conteudoRecebido, string valoresAceitos, bool ignorarMaisculas) {

            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                valoresAceitos = valoresAceitos.Trim();
                if (conteudoRecebido == "") return false;
                if (valoresAceitos == "") return false;

                bool achou = false;
                string[] vetorValoresAceitos = valoresAceitos.Split('|');

                for (int posicao = 0; posicao < vetorValoresAceitos.Length; posicao++)
                {
                    if (ignorarMaisculas)
                    {
                        achou = (vetorValoresAceitos[posicao].ToUpper() == conteudoRecebido.ToUpper());
                    }
                    else
                    {
                        achou = (vetorValoresAceitos[posicao] == conteudoRecebido);
                    }
                    if (achou) break;
                }

                return achou;
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public bool ValidarCNPJ(string cnpj) {
            try
            {
                int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
                int soma;
                int resto;
                string digito;
                string tempCnpj;

                cnpj = cnpj.Trim();
                cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");

                if (cnpj.Length != 14)
                    return false;

                tempCnpj = cnpj.Substring(0, 12);

                soma = 0;
                for (int i = 0; i < 12; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCnpj = tempCnpj + digito;
                soma = 0;
                for (int i = 0; i < 13; i++)
                    soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];

                resto = (soma % 11);
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cnpj.EndsWith(digito);

            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }

        }

        public bool ValidarCPF(string cpf) {
            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                tempCpf = cpf.Substring(0, 9);
                soma = 0;
                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public bool ValidarData(string conteudoRecebido) {
            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;
                DateTime resultado;
                if (!DateTime.TryParse(conteudoRecebido, out resultado)) return false;

                return true;
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public bool ValidarEmail(string conteudoRecebido, int tamanhoMaximo) {
            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;
                if (conteudoRecebido.Length > tamanhoMaximo) return false;

                Regex expressaoRegular = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
                return expressaoRegular.IsMatch(conteudoRecebido);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public bool ValidarLetras(string conteudoRecebido, int tamanhoMinimo, int tamanhoMaximo) {
            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;
                if (conteudoRecebido.Length < tamanhoMinimo) return false;
                if (conteudoRecebido.Length > tamanhoMaximo) return false;

                Regex expressaoRegular = new Regex(@"[a-zA-Z]{" + tamanhoMinimo.ToString() + "," + tamanhoMaximo.ToString() + "}");
                return expressaoRegular.IsMatch(conteudoRecebido);
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Valida senha entre 8 e 24 caracteres, com pelo menos 1 letra, 1 número e 1 caracter especial
        /// </summary>
        /// <param name="conteudoRecebido">Senha a ser validada</param>
        /// <returns>True = senha válida</returns>
        public bool ValidarSenha(string conteudoRecebido) {
            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;

                Regex expressaoRegular = new Regex(@"^.*(?=.{8,24})(?=.*[a-zA-Z])(?=.*[\d])(?=.*[\W]).*$");
                if (!expressaoRegular.IsMatch(conteudoRecebido)) return false;

                return this.ValidarXSS(conteudoRecebido);
            }
            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        public bool ValidarTelefone(string conteudoRecebido, int tamanhoMaximo) {
            try
            {
                int tamanhoMinimo = 7; //arbitrado como menor comprimento possível
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;
                if (conteudoRecebido.Length < tamanhoMinimo) return false;
                if (conteudoRecebido.Length > tamanhoMaximo) return false;
                
               

                Regex expressaoRegular = new Regex(@"^[r()_/\-\.\s\d]{" + tamanhoMinimo.ToString() + "," + tamanhoMaximo.ToString() + "}");
                return expressaoRegular.IsMatch(conteudoRecebido);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Valida texto livre quanto ao tamanho e anti-XSS
        /// </summary>
        /// <param name="conteudoRecebido">Texto a ser validado</param>
        /// <param name="tamanhoMaximo">Tamanho mínimo permitido para a string</param>
        /// <param name="tamanhoMaximo">Tamanho máximo permitido para a string</param>
        /// <returns></returns>
        public bool ValidarTextoLivre(string conteudoRecebido, int tamanhoMinimo, int tamanhoMaximo) {

            try
            {
                conteudoRecebido = conteudoRecebido.Trim();
                if (conteudoRecebido == "") return false;
                if (conteudoRecebido.Length < tamanhoMinimo) return false;
                if (conteudoRecebido.Length > tamanhoMaximo) return false;

                return this.ValidarXSS(conteudoRecebido);
            }

            catch (Exception ex)
            {
                Log.GravarLog(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Verifica se uma string possui conteúdo HTML (ataques XSS)
        /// </summary>
        /// <param name="conteudoRecebido">String a ser verificada</param>
        /// <returns>True = não possui HTML</returns>
        public bool ValidarXSS(string conteudoRecebido) {
            Regex expressaoRegular = new Regex(@"((\%3C)|<)[^\n]+((\%3E)|>)");
            return !expressaoRegular.IsMatch(conteudoRecebido);
        }

        public string AcetarErrosDeDominiosDeEmail(string email)
        {
            
            return "";
        }

    }
}
