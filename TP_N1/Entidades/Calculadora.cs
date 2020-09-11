using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public static class Calculadora
    {
        /// <summary>
        /// Realiza la operacion matematica de dos numeros
        /// </summary>
        /// <param name="num1">Primer operando</param>
        /// <param name="num2">Segundo operando</param>
        /// <param name="operador">Operador aritmentico</param>
        /// <returns>El resultado de la operacion de acuerdo al operador recibido, en caso que el operador sea invalido realizara una suma</returns>
        public static double Operar (Numero num1, Numero num2, string operador)
        {
            char operadorAux;
            if(char.TryParse(operador, out operadorAux))
            {
                switch (Calculadora.ValidarOperador(operadorAux))
                {
                    case "-":
                        {
                            return num1 - num2;
                        }
                    case "/":
                        {
                            return num1 / num2;
                        }
                    case "*":
                        {
                            return num1 * num2;
                        }
                    default:
                        {
                            return num1 + num2;
                        }
                }
            }
            else
            {
                return num1 + num2;
            }
        }
        /// <summary>
        /// Valida que el operador sea (+ - * /) 
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El operador, sino es valido devuelve el operador +</returns>
        private static string ValidarOperador(char operador)
        {
            string returnAux=string.Empty;
            switch (operador)
            {
                case '+':
                case '-':
                case '/':
                case '*':
                    {
                        returnAux = operador.ToString();
                        break;
                    }
                default:
                    {
                        returnAux = "+";
                        break;
                    }
            }
            return returnAux;
        }
    }
}
