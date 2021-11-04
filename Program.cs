using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculadora_POO_Proyecto
{
    class Program
    {
        public class CalcuBasica
        {
            // Declaracion de variables
            private Double operA;
            private Double operB;
            private Double resultAB;

            // Constructores
            public void InitiateBasica(Double operA, Double operB, Double resultAB)
            {
                this.operA = operA;
                this.operB = operB;
                this.resultAB = resultAB;
            }

            // Operaciones Básicas
            private Double Suma()
            {
                resultAB = operA + operB;
                Math.Round(resultAB, 4); // Redondea puntos decimales a 4 posiciones
                return resultAB;
            }
            private Double Resta()
            {
                resultAB = operA - operB;
                Math.Round(resultAB, 4);
                return resultAB;
            }
            private Double Multiplicacion()
            {
                resultAB = operA * operB;
                Math.Round(resultAB, 4);
                return resultAB;
            }
            private Double Division()
            {
                try { resultAB = operA / operB; } // El programa intentará ejecutar la operacion aritmetica
                catch (System.DivideByZeroException e) // Si no hay resultado entonces mostrará el símbolo de Infinito
                { Console.WriteLine(e); }
                return resultAB; // Caso contrario entonces mostrara el resultado correspondiente

            }
            public String Resultados()
            {
                return "Los resultados de las operaciones son los siguientes:" +
                    "\nSuma: " + Suma() +
                    "\nResta: " + Resta() +
                    "\nMultiplicacion: " + Multiplicacion() +
                    "\nDivision: " + Division();
            }
        }

        public class CalcuTrigono
        {
            private Double resultC, operC;
            private int funciont;
            //private int degrad;

            public void InitiateTrigono(Double resultC, Double operC,/* int degrad,*/ int funciont)
            {

                this.resultC = resultC;
                this.operC = operC;
                //this.degrad = degrad;
                this.funciont = funciont;
            }
            public String ResultTrigono()
            {
                if (funciont == 1) //Seno
                {
                    resultC = Math.Sin(operC);
                }
                else if (funciont==2) //Coseno
                {
                    resultC = Math.Cos(operC);
                }
                else if (funciont==3) //Tangente
                {
                    resultC = Math.Tan(operC);
                }
                else if (funciont == 4) //Cosecante
                {
                    resultC = 1/Math.Sin(operC);
                }
                else if (funciont == 5) //Secante
                {
                    resultC = 1/Math.Cos(operC);
                }
                else if (funciont == 6) //Cotangente
                {
                    resultC = Math.Cos(operC)/Math.Sin(operC);
                }
                return "\nResultado en radianes: "+(Math.Round(resultC,3))+"\nResultado en grados: "+(Math.Round(((resultC*180)/Math.PI),3));
                                
            }
        }
        /*Se hará una clase para las Conversiones y se seleccionarán con un Switch en el Main()*/

        static void Main(string[] args)
        {
            int seleccion;
            Console.WriteLine("Hola, y bienvenido a CeeCalc. La calculadora desarrollada en C#.");
            do
            {
                //Menu
                
                Console.WriteLine("\nIndica el modo a utilizar:\n1. Básica\n2. Trigonometrica\n3. Salir");
                seleccion = int.Parse(Console.ReadLine());
                switch (seleccion)
                {
                    case 1:
                        // Inicializa clase Base
                        CalcuBasica calcubasica;
                        calcubasica = new CalcuBasica();

                        // Declaracion de Variables
                        double operA;
                        double operB;
                        double resultAB = 0; // resultAB tiene que ser 0 ya que el usuario no ingresa su valor.

                        Console.WriteLine("Modo Básico habilitado...");
                        Console.WriteLine("Indique el primer operador:");
                        operA = double.Parse(Console.ReadLine());
                        Console.WriteLine("Indique el segundo operador:");
                        operB = double.Parse(Console.ReadLine());

                        // Inicializa las variables
                        calcubasica.InitiateBasica(operA, operB, resultAB);

                        // Imprime el return de Resultados()
                        Console.WriteLine(calcubasica.Resultados());
                        break;
                    case 2:
                        CalcuTrigono calcutrigono;
                        calcutrigono = new CalcuTrigono();

                        double resultC = 0, operC;
                        int /*degrad = 0,*/ funciont;


                        Console.WriteLine("Modo Trigonométrico habilitado...");
                        Console.WriteLine("\nIndique con un numero la funcion a usar:\n1. Seno\t\t2. Coseno\t\t3. Tangente\n4. Cosecante\t5. Secante\t6. Cotangente");
                        funciont = int.Parse(Console.ReadLine());
                        Console.WriteLine("\nIngrese el valor a evaluar:");
                        operC = double.Parse(Console.ReadLine());

                        calcutrigono.InitiateTrigono(resultC, operC, /*degrad,*/ funciont);

                        Console.WriteLine(calcutrigono.ResultTrigono());

                        break;
                    default:
                        break;
                }
            } while (seleccion != 3);

            
            
        }
    }
}
