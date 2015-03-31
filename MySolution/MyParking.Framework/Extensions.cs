using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyParking.Framework
{
    public static class Extensions
    {
        //Classe Estaticas para criar funções que não existe no C#
        public static string Right(this string value, int length)
        {
            if (!value.Equals(""))
                return value.Substring(value.Length - length);

            return "";
        }

        public static string Left(this string value, int length)
        {
            if (!value.Equals(""))
                return value.Substring(0, length);

            return "";
        }

        public static string FormataData(this string value)
        {
            if (!value.Equals(""))
            {
                DateTime data = Convert.ToDateTime(value);
                value = data.ToString("dd/MM/yyyy");
                return value;
            }
            else
                return "";
        }

        public static string TiraCaracteres(this string value)
        {
            return value.Replace("-", "").Replace(".", "").Replace("/", "").Replace("(", "").Replace(")", "").Replace(" ", "");
        }

        public static string FormataString(string mascaraString, string valor)
        {
            string novoValor = string.Empty;
            int posicao = 0;

            char[] mascara = mascaraString.ToCharArray();

            valor = Extensions.TiraCaracteres(valor);

            for (int i = 0; mascara.Length > i; i++)
            {
                if (mascara[i].Equals("#"))
                {
                    if (valor.Length > posicao)
                    {
                        novoValor = novoValor + valor[posicao];
                        posicao++;
                    }
                    else
                        break;
                }
                else
                {
                    if (valor.Length > posicao)
                        novoValor = novoValor + mascara[i];
                    else
                        break;
                }
            }
            return novoValor;
        }

        public static bool CPFValido(string CPF)
        {
            int[] mt1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] mt2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string TempCPF;
            string Digito;
            int soma;
            int resto;

            CPF = CPF.Trim();
            CPF = CPF.Replace(".", "").Replace("-", "");

            if (CPF.Length != 11)
                return false;

            TempCPF = CPF.Substring(0, 9);
            soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt1[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = resto.ToString();
            TempCPF = TempCPF + Digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(TempCPF[i].ToString()) * mt2[i];

            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            Digito = Digito + resto.ToString();

            return CPF.EndsWith(Digito);
        }
    }
}
