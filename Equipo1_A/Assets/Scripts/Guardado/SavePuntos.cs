using UnityEngine;

public class SistemaPuntuacion : MonoBehaviour
{
    // Método para guardar la puntuación de un nivel
    public void GuardarPuntuacion(int puntuacion, int nivel)
    {
        // Guardamos la puntuación usando PlayerPrefs
        PlayerPrefs.SetInt("PuntuacionNivel" + nivel, puntuacion);
        PlayerPrefs.Save(); // Aseguramos que los datos se guarden
        Debug.Log("Puntuación del Nivel " + nivel + " guardada: " + puntuacion);
    }

    // Método para cargar la puntuación de un nivel
    public int CargarPuntuacion(int nivel)
    {
        // Cargamos la puntuación del nivel, si no existe devuelve 0
        int puntuacion = PlayerPrefs.GetInt("PuntuacionNivel" + nivel, 0);
        Debug.Log("Puntuación del Nivel " + nivel + " cargada: " + puntuacion);
        return puntuacion;
    }

    // Método para resetear todas las puntuaciones guardadas
    public void ResetearPuntuaciones()
    {
        PlayerPrefs.DeleteAll(); // Borra todas las puntuaciones guardadas
        Debug.Log("Todas las puntuaciones han sido reseteadas.");
    }

    /*-----------------------------------------------------------------------------------
    Para futura implementacion en los finales de los niveles
    
    
    
    void FinDelNivel(int puntuacion, int nivel)
    {
    SistemaPuntuacion sistemaPuntuacion = new SistemaPuntuacion();
    sistemaPuntuacion.GuardarPuntuacion(puntuacion, nivel);
    }   

    void InicioDelNivel(int nivel)
    {
    SistemaPuntuacion sistemaPuntuacion = new SistemaPuntuacion();
    int puntuacion = sistemaPuntuacion.CargarPuntuacion(nivel);
    // Mostrar la puntuación cargada en la UI o usarla de otra manera
    }

    public void ReiniciarPuntuaciones()
    {
    SistemaPuntuacion sistemaPuntuacion = new SistemaPuntuacion();
    sistemaPuntuacion.ResetearPuntuaciones();
    }
    
    -------------------------------------------------------------------------------------*/
}
