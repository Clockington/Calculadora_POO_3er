using System;

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
            private readonly Double resultC, operC;
            private readonly int funciont;
            //private int degrad;

            public CalcuTrigono(Double operC,int funciont)
            {
                this.operC = operC;
                this.funciont = funciont;
            }
            public String ResultTrigono()
            {
                switch (funciont)
                {
                    case 1: //Seno
                    return ">" + Math.Sin(operC);
                    case 2: //Coseno
                    return ">" + Math.Cos(operC);
                    case 3: //Tangente
                    return ">" + Math.Tan(operC);
                    case 4: //Cosecante
                    return ">"+(1/Math.Sin(operC));
                    case 5: //Secante
                    return ">"+(1/Math.Cos(operC));
                    case 6: //Cotangente
                    return ">"+(Math.Cos(operC)/Math.Sin(operC));
                    default:
                    throw new InvalidOperationException("Operacin Invalida.");
                }
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
                    case 2: //Trigonometrica
                        {
                            double operC;
                            int functiont;

                            Console.WriteLine("Modo Trigonometrico habilitado...");
                            Console.WriteLine("\nIndique con un numero la funcion a utilizar..."+
                            "\n\t1. Seno"+
                            "\n\t2. Coseno"+
                            "\n\t3. Tangente"+
                            "\n\t4. Cosecante"+
                            "\n\t5. Secante"+
                            "\n\t6. Cotangente");
                            functiont=int.Parse(COnsole.Readline());
                            Console.WriteLine("\nIngrese el valor a evaluar en radianes...");
                            operC=double.Parse(Console.ReadLine());

                            CalcuTrigono calcutrigono = new CalcuTrigono(operC,functiont);
                            Console.WriteLine(Console.ResultTrigono());
                            
                            break;
                        }
                    default:
                        break;
                }
            } while (seleccion != 3);

            
            
        }
    }
}
