using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tarea1Progra2
{


    internal class Program
    {
        static void Main(string[] args)
        {
            Menu();



        }

        public static void Menu()
        {

            do
            {
                Console.WriteLine("Menu principal: ");
                Console.WriteLine("1- Inicializar vectores. \n2 - Ingresar Paso Vehicular. \n3- Consulta de vehículos x Número de Placa " +
                    "\n4- Modificar Datos Vehículos x número de Placa. \n5- Reporte Todos los Datos de los vectores. \n6 - Salir" +
                    "\nDigite la opcion que desea");

                opcion = int.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        inicializarVectores();
                        break;
                    case 2:
                        ingresarDatos();
                        break;
                    case 3:
                        consultar();
                        break;
                    case 4:
                        modificar();
                        break;
                    case 5:
                        reporte();
                        break;
                    case 6:
                        //Salida


                        break;
                    default:
                        Console.WriteLine("Ingrese una opcion valida");
                        break;


                }
            } while (opcion != 6);
            Console.Write("Gracias por su estadia. \nVuelva pronto");
        }
        static int opcion;
        static int count = 0;
        static int[] nFact = new int[15];
        static String[] nPlaca= new String[15];
        static String[] fecha = new String[15];
        static String[] hora = new String[15];
        static String[] nombre = new String[15];
        static String[] vehiculo = new String[15];
        static int[] nCaseta = new int[15];
        static int[] monto = new int[15];
        static int[] pago = new int[15];
        static int[] vuelto = new int[15];


        public static void inicializarVectores()
        {
            for (int i = 0; i < nFact.Length - 1; i++)
            {
                // [1112233, 343456534643, 34534543,453534543]
                // [0,0,0,0,0,0,0,0,0]

                //inicializando vectores numericos
                nFact[i] = 0;
                monto[i] = 0;
                pago[i] = 0;
                vuelto[i] = 0;
                nCaseta[i] = 0;

                //inicializando vectores de tipo cadena
                nPlaca[i] = "";
                fecha[i] = "";
                hora[i] = "";
                nombre[i] = "";
                vehiculo[i] = "";

            }
        }
        public static void ingresarDatos()
        {
 
            do
            {
                Console.WriteLine("Ingresar Datos de Paso Vehicular: ");
                Console.WriteLine("1 - Ingresar Datos. \n2 - Salir.\n");
                Console.WriteLine("Digite la opcion que desea");
                opcion = int.Parse(Console.ReadLine());
                if (opcion == 1)
                {
                    for (int i = 0; i < nFact.Length; i++)
                    {
                        //Genera el consecutivo de la factura
                        nFact[i] = i + 1;
                        Console.WriteLine("Numero De Factura: " + nFact[i]);

                        Console.WriteLine("Ingrese la fecha");
                        fecha[i] = Console.ReadLine();

                        Console.WriteLine("Ingrese la hora");
                        hora[i] = Console.ReadLine();

                        Console.WriteLine("Ingrese el numero de Placa");
                        nPlaca[i] = Console.ReadLine();

                        do
                        {
                            Console.WriteLine("Ingrese el tipo de vehiculo: \n 1-Moto. \n2-Vehículo Liviano. \n3- Camión o Pesado. \n4- Autobús");
                            opcion = int.Parse(Console.ReadLine());

                            
                            if (opcion == 1)
                            {
                                vehiculo[i] = "Moto";
                             }else if (opcion == 2)
                            {
                                vehiculo[i] = "Vehiculo Liviano";
                            } else if (opcion == 3)
                            {
                                vehiculo[i] = "Camion o Pesado";
                            } else if (opcion == 4)
                            {
                                vehiculo[i] = "Autobus";
                            } else{
                                Console.WriteLine("La opcion no existe. Intente de nuevo.\n");
                            }

                        } while (opcion != 1 && opcion != 2 && opcion != 3 && opcion != 4);
                        
                        //asignacion de caseta
                        do
                        {
                            Console.WriteLine("\nElija un numero de caseta: \n1 \n2 \n3");

                            nCaseta[i] = int.Parse(Console.ReadLine());

                            if (nCaseta[i] != 1 && nCaseta[i] != 2 && nCaseta[i] != 3)
                            {
                                Console.WriteLine("Elija un numero de caseta que se encuentra en las opciones, por favor: \n1, \n2, \n3");
                            }

                        } while (nCaseta[i] != 1 && nCaseta[i] != 2 && nCaseta[i] != 3);

                        //Asignacion de monto
                        if (vehiculo[i].Equals("Moto"))
                        {
                            monto[i] = 500;
                        }
                        else if (vehiculo[i].Equals("Vehiculo Liviano"))
                        {
                            monto[i] = 700;
                        }
                        else if (vehiculo[i].Equals("Camion o Pesado"))
                        {
                            monto[i] = 2700;
                        }
                        else
                        {
                            monto[i] = 3700;
                        }

                        //Se recibe el monto con el que se va a pagar
                        do
                        {
                            Console.WriteLine("El monto a pagar es de: " + monto[i] + ", tipo vehiculo " + vehiculo[i]);


                            Console.WriteLine("Digite su monto de pago");
                            pago[i] = int.Parse(Console.ReadLine());

                            if (pago[i] < monto[i])
                            {
                                Console.WriteLine("El monto de pago : " + pago[i] + "  es menor a al monto a cancelar: " + monto[i] + "\n");
                            }
                        } while (pago[i] < monto[i]);

                        //Cambio del usuario
                        vuelto[i] = pago[i] % monto[i];
                        Console.WriteLine("Su cambio es de: " + vuelto[i]);

                        do
                        {
                            Console.WriteLine("Desea continuar? \n1 - Si \n2 - No");
                            opcion = int.Parse(Console.ReadLine());
                            if (opcion != 1 && opcion != 2)
                            {
                                Console.WriteLine("Opcion incorrecta, por favor seleccionar entre 1 y 2");
                            }
                        } while (opcion != 1 && opcion != 2);
                        if (opcion == 2)
                        {
                            break;
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Saliendo del Sistema\n");
                }
            } while (opcion != 2);



        }

        public static void consultar()
        {

            Console.WriteLine("Ingrese el numero de placa que a consultar");
            String placaBusqueda = Console.ReadLine();
            for (int p = 0; p < nPlaca.Length; p++)
            {
                if (nPlaca[p].Equals(placaBusqueda))
                {                 
                    Console.WriteLine("\nVehículo encontrado:" );
                    Console.WriteLine("Numero de Facutura: " + nFact[p]);
                    Console.WriteLine("Fecha de ingreso: " + fecha[p]);
                    Console.WriteLine("Hora de Ingreso: " + hora[p]);
                    Console.WriteLine("Tipo de Vehiculo: " + vehiculo[p]);
                    Console.WriteLine("Numero de Caseta Registrada: " + nCaseta[p]);
                    Console.WriteLine("Monto a pagar: " + monto[p]);
                    Console.WriteLine("Su monto de pago fue con: " + pago[p]);
                    Console.WriteLine("Su vuelto fue de: " + vuelto[p]);
                    break;
                }
            }
        }

        public static void modificar()
        {

        }

        public static void reporte()
        {
            int total = 0;
            String lista =" ";
            {
                Console.WriteLine("");
                Console.WriteLine("                                                    Reporte de Paso                ");
                Console.WriteLine("Numero de Factura " + " Placa " + " Tipo de Vehiculo " + " Caseta " + " Monto por Vehiculo " + " Monto de Pago " + " Vuelto ");
                Console.WriteLine("=============================================================================================");
                for (int x = 0; x < nFact.Length; x++)
                {

                    if (monto[x] > 0)
                    {
                        lista += nFact[x] + "                " + nPlaca[x] + "                    " + vehiculo[x] + "           " + nCaseta[x] + "           " + monto[x] + "       " + pago[x] + "      " + vuelto[x] + "\n";
                        total += monto[x];
                        count++;
                    }
                    
                }
                Console.WriteLine(lista);
                Console.WriteLine("=============================================================================================");
                Console.WriteLine("Total: " + total + "                    " + "Cantidad de Vehiculos: " + count);
                Console.WriteLine("=============================================================================================");
            }
        }

    }
}
