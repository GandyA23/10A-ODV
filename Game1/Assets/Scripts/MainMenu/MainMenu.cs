using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Necesario para cambiar entre escenas
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Inicia la escena en donde podr� jugar
        SceneManager.LoadScene("Game");       
    }

    public void ExitGame()
    {
        // Para pruebas, detiene la ejecuci�n, cuando existe el ejecutable, es necesario eliminarlo
        // UnityEditor.EditorApplication.isPlaying = false;
        // Se cierra el juego
        Application.Quit();
    }
}
