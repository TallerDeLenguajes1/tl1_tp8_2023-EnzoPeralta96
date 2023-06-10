using EspacioTareasEmpleados;   
using Funciones_para_ListadoDeTareas;
using System;
internal class Program
{
    private static void Main(string[] args)
    {
        
        var TareasPendientes = new List<Tarea>();
        var TareasRealizadas = new List<Tarea>();

        int cantidadDeTareas = Funcion.NumeroAleatorio(3, 8);
        int Opcion;

        bool ProgramaEnUso = true, MuestraEnUso;
        string AccionARealizar;
        
        while (ProgramaEnUso)
        {
            do
            {
                Console.WriteLine("Que acción desea realizar:");
                Console.WriteLine("-1:Cargar las Tareas Pendienres\n-2:Gestion de Tareas\n-3:MostrarTareas\n-4:Guardar Horas trabajadas\n-5:Finalizar");
                AccionARealizar = Console.ReadLine();
            } while (String.IsNullOrEmpty(AccionARealizar));

            bool Resultado = int.TryParse(AccionARealizar, out Opcion);

            if (Resultado && 1<=Opcion && Opcion<=5)
            {
                switch (Opcion)
                {
                    case 1:
                        Console.WriteLine("Cantidad de tareas a cargar:"+cantidadDeTareas);
                        Funcion.CargarLista(TareasPendientes, cantidadDeTareas);
                        break;
                    case 2:
                        if (TareasPendientes.Count==0)
                        {
                            Console.WriteLine("Lista vacia, Cargue las tareas pendientes para poder gestionarlas");
                        }else
                        {
                            Funcion.MarcarTarea(TareasPendientes, TareasRealizadas, cantidadDeTareas);
                        }
                        break;
                    case 3:
                        MuestraEnUso = true;
                        while (MuestraEnUso)
                        {
                            do
                            {
                                Console.WriteLine("Que Tareas desea ver:");
                                Console.WriteLine("-1:Tareas Pendienres\n-2:Tareas Realizadas\n-3:Volver a menu");
                                AccionARealizar = Console.ReadLine();
                            } while (String.IsNullOrEmpty(AccionARealizar));

                            Resultado = int.TryParse(AccionARealizar, out Opcion);

                            if (Resultado && 1<=Opcion && Opcion<=3)
                            {
                                switch (Opcion)
                                {
                                    case 1:
                                        if (TareasPendientes.Count==0)
                                        {
                                            Console.WriteLine("Lista vacia, Cargue las tareas pendientes");
                                        }else
                                        {
                                            Console.WriteLine("Listado de tareas Pendientes");
                                            Funcion.MostrarLista(TareasPendientes);
                                        }
                                        break;
                                    case 2:
                                        if (TareasRealizadas.Count==0)
                                        {
                                            Console.WriteLine("Lista vacia, haga el gestion de tareas primera");
                                        }else
                                        {
                                            Console.WriteLine("Listado de tareas Realizadas");
                                            Funcion.MostrarLista(TareasRealizadas);
                                        }
                                        break;
                                    case 3:
                                        MuestraEnUso = false;
                                        Console.WriteLine("Volviendo...");
                                        break;
                                }
                            }else
                            {
                                Console.WriteLine("Opcion incorrecta");
                            }
                        }
                        break;
                    case 4:
                        string ruta ="horas_trabajadas.txt";
                        var Archivo = new StreamWriter(ruta,true);
                        int HorasTrabajadas=0;
                        foreach (var Tarea in TareasRealizadas)
                        {
                            HorasTrabajadas += Tarea.Duracion;
                        }
                        Archivo.WriteLine("Dia:"+DateTime.Now.ToString("dd/MM/yyy")+" Horas trabajadas:"+HorasTrabajadas);
                        Archivo.Close();
                        Console.WriteLine("Horas trabajadas guardadas con exito!");
                        break;
                    case 5:
                        ProgramaEnUso=false;
                        Console.WriteLine("Saliendo...");
                        break;
                }    
            }else
            {
                Console.WriteLine("Opcion incorrecta");
            }
            Console.WriteLine("Finalizo la ejecución del programa!");
            
        }
    }
}

    