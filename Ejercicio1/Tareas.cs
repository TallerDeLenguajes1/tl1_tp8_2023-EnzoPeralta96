namespace EspacioTareasEmpleados
{
    public enum Estado
    {
        Pendiente=1,
        Realizado=2
    }
    public class Tarea
    {
        int tareaID;
        String descripcion;
        int duracion;

        public int TareaID { get => tareaID; set => tareaID = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public int Duracion { get => duracion; set => duracion = value; }

        public Tarea(int tareaID, string descripcion, int duracion)
        {
            TareaID = tareaID;
            Descripcion = descripcion;
            Duracion = duracion;
        }        
    }

   
}



