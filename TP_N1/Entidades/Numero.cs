using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
        /// <summary>
        /// Valida que el valor recibido sea numero
        /// </summary>
        /// <param name="strNumero">Es el numero en formato string que se va a validar</param>
        /// <returns>El numero validado, si no es valido, devuelve 0</returns>
        private static double ValidarNumero(string strNumero)
        {
            double numeroAux;
            
            if (!(double.TryParse(strNumero, out numeroAux)) || strNumero.Contains("."))
            {
                numeroAux = 0;
            }
            return numeroAux;
        }
        /// <summary>
        /// Constructor por defecto, asigna el numero 0
        /// </summary>
        public Numero() : this (0)
        {
            
        }
        /// <summary>
        /// Constructor de tipo string que setea al valor enviado
        /// </summary>
        /// <param name="strNumero">Numero a asignar</param>
        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }
        /// <summary>
        /// Constructor de tipo double que setea al valor enviado
        /// </summary>
        /// <param name="numero">Numero a aginar</param>
        public Numero(double numero) : this(numero.ToString())
        {
            
        }
        /// <summary>
        /// Setea el numero previa validacion
        /// </summary>
        public string SetNumero
        {
            set { this.numero = Numero.ValidarNumero(value); }

        }
        /// <summary>
        /// Reeliza la conversion de un numero binario a decimal
        /// </summary>
        /// <param name="binario">Es el numero binario a convertir</param>
        /// <returns>Un string con el numero decimal</returns>
        public string BinarioDecimal(string binario)
        {
            string returnAux= string.Empty;
            double numAux = 0;
            int cantidadCaracteres = binario.Length;
            if (EsBinario(binario))
            {
                foreach (char caracter in binario)
                {
                    cantidadCaracteres--;
                    if (caracter == '1')
                    {
                        numAux += Math.Pow(2, cantidadCaracteres);
                    }
                }
                returnAux = numAux.ToString();
            }
            else
            {
                returnAux = "Valor Invalido";
            }
            return returnAux;
        }
        /// <summary>
        /// Realiza la conversion de un numero decimal, entero positivo a Binario
        /// </summary>
        /// <param name="numero">Es el numero a convertir</param>
        /// <returns>Un string con el numero Binario</returns>
        public string DecimalBinario(double numero)
        {
            string valorBinario = string.Empty;
            int resultDiv = (int)numero;
            int restoDiv;
            if (resultDiv >= 0)
            {
                do
                {
                    restoDiv = resultDiv % 2;
                    resultDiv /= 2;
                    valorBinario = restoDiv.ToString()+valorBinario;
                } while (resultDiv > 0);
            }
            else
            {
                valorBinario = "Valor Invalido";
            }
            return valorBinario;
        }
        /// <summary>
        /// Realiza la conversion de un numero decimal recibido como string, entero positivo a Binario
        /// </summary>
        /// <param name="strNumero">Es el numero a convertir</param>
        /// <returns>Un string con el numero Binario</returns>
        public string DecimalBinario(string strNumero)
        {
            double auxNum;
            string returAux= "Valor Invalido";
            if (double.TryParse(strNumero, out auxNum))
            {
                returAux= DecimalBinario(auxNum);
            }
            return returAux;
        }
        /// <summary>
        /// Valida que la cadena de texto recibida posea solamente caracteres 1 y 0 para determinar si corresponde a un numero Binario
        /// </summary>
        /// <param name="strNumero">Es la cadena a validar</param>
        /// <returns>True en caso exitoso o False de lo contrario</returns>
        private bool EsBinario(string strNumero)
        {
            int flag = 0;
            bool returnAux = true;
            foreach (char caracter in strNumero)
            {
                if(caracter!='1' && caracter !='0')
                {
                    flag++;
                    break;
                }
            }
            if (flag==1)
            {
                returnAux = false;
            }
            return returnAux;
        }
        /// <summary>
        /// Sobrecarga del operador suma
        /// </summary>
        /// <param name="n1">Objeto 1 de tipo Numero</param>
        /// <param name="n2">Objeto 2 de tipo Numero </param>
        /// <returns>La suma de 2 numeros</returns>
        public static double operator +(Numero n1, Numero n2)
        {
            return (n1.numero + n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador resta
        /// </summary>
        /// <param name="n1">Objeto 1 de tipo Numero<</param>
        /// <param name="n2">Objeto 2 de tipo Numero<</param>
        /// <returns>La resta de 2 numeros</returns>
        public static double operator -(Numero n1, Numero n2)
        {
            return (n1.numero - n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador producto
        /// </summary>
        /// <param name="n1">Objeto 1 de tipo Numero<</param>
        /// <param name="n2">Objeto " de tipo Numero<</param>
        /// <returns>El producto de 2 numeros</returns>
        public static double operator *(Numero n1, Numero n2)
        {
            return (n1.numero * n2.numero);
        }
        /// <summary>
        /// Sobrecarga del operador division
        /// </summary>
        /// <param name="n1">Objeto 1 de tipo Numero</param>
        /// <param name="n2">Objeto 1 de tipo Numero</param>
        /// <returns>La division de 2 numeros, si se trata de una division por cero retornara el valor minimo de un Double</returns>
        public static double operator /(Numero n1, Numero n2)
        {
            double returAux = double.MinValue;
            if (n2.numero != 0)
            {
                returAux = n1.numero / n2.numero;
            }
            return returAux;
        }
    }
}
