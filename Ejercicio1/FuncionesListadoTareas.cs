using EspacioTareasEmpleados;
namespace Funciones_para_ListadoDeTareas
{
    class Funcion
    {
        public static void MarcarTarea(List<Tarea> TareasPendientes, List<Tarea> TareasRealizadas, int cantidadDeTareas)
        {
            string marca;
            for (int i = 0; i < cantidadDeTareas; i++)
            {
                MostrarTarea(TareasPendientes[i]);
                do
                {
                    Console.WriteLine("Marcar Como realizada?: Y:SI - N:No");
                    marca = Console.ReadLine();
                } while (String.IsNullOrEmpty(marca));
                
                if (marca == "Y" || marca=="y")
                {
                    var tareaMarcada = TareasPendientes[i];
                    TareasRealizadas.Add(tareaMarcada);
                }
            }
            foreach (var tareaMarcada in TareasRealizadas)
            {
                TareasPendientes.Remove(tareaMarcada);
            }
        }

        public static void MostrarLista(List<Tarea> ListaDeTareas)
        {
            foreach (var Tarea in ListaDeTareas)
            {
                MostrarTarea(Tarea);

            }
        }

        public static void MostrarTarea(Tarea TareaEmpleado)
        {
            Console.WriteLine("Tarea Nro:" + TareaEmpleado.TareaID);
            Console.WriteLine("Descripción:" + TareaEmpleado.Descripcion);
            Console.WriteLine("Duración:" + TareaEmpleado.Duracion);
            Console.WriteLine();
        }

        public static void CargarLista(List<Tarea> TareasPendientes, int cantidadDeTareas)
        {
            
            int tiempoTarea;
            string descripcionTarea, inputTiempoTarea;

            for (int i = 0; i < cantidadDeTareas; i++)
            {
                Console.WriteLine("Tarea nro:"+(i+1));
                do
                {
                    Console.WriteLine("Ingrese Descripción:");
                    descripcionTarea = Console.ReadLine();
                } while (string.IsNullOrEmpty(descripcionTarea));
                do
                {
                    Console.WriteLine("Tiempo de duración:");
                    inputTiempoTarea = Console.ReadLine();
                } while (String.IsNullOrEmpty(inputTiempoTarea));

                bool Resultado_inputTiempoTarea = int.TryParse(inputTiempoTarea, out tiempoTarea);

                if (Resultado_inputTiempoTarea)
                {
                    
                    Tarea NuevaTarea = new Tarea((i+1), descripcionTarea, tiempoTarea);
                    TareasPendientes.Add(NuevaTarea);
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Error al ingresar duración");
                    i--;
                }
            }
        }

        public static int NumeroAleatorio(int a, int b)
        {
            Random random = new Random();
            return random.Next(a, b);
        }    
    }
    
}