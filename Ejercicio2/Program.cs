internal class Program
{
    private static void Main(string[] args)
    {   string rutaCarpeta;
        do
        {
            Console.WriteLine("Ingrese la ruta de la carpeta:");
            rutaCarpeta = @Console.ReadLine();
               // rutaCarpeta = @"C:\Users\user\Documents\Facultad\2do-año\Algoritmos\Diapositivas";
        } while (string.IsNullOrEmpty(rutaCarpeta));

        if (Directory.Exists(rutaCarpeta))
        {
            Console.WriteLine("Listados de archivos existentes en la carpeta:");

            var archivosCarpeta = Directory.GetFiles(rutaCarpeta);

            foreach (var archivo in archivosCarpeta)
            {
                Console.WriteLine(archivo);
            } 

            string rutaArchivo = "index.csv"; // ruta relativa a la carpeta ejercicio2
    
            using (var archivo_csv = new StreamWriter(rutaArchivo))
            {
                archivo_csv.WriteLine("Índice,Nombre,Extensión");
                for (int i = 0; i < archivosCarpeta.Length; i++)
                {
                    String NombreArchivo = Path.GetFileNameWithoutExtension(archivosCarpeta[i]);
                    String ExtensionArchivo = Path.GetExtension(archivosCarpeta[i]);
                    archivo_csv.WriteLine((i+1)+","+NombreArchivo+","+ExtensionArchivo);
                }
            }
            Console.WriteLine("Archivo CSV 'index.csv' generado exitosamente.");

        }else
        {
            Console.WriteLine("Directorio inexistente");
        }
    }
}