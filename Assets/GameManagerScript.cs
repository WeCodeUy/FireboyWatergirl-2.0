using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool estaFireboy = false;
    public bool estaWatergirl = false;
    public GameObject GanasteCanvas;
    public GameObject PerdisteCanvas;

    public void YouWin()
    {
        if (estaFireboy && estaWatergirl)
        {
            GanasteCanvas.SetActive(true);
        }
    }

    public void YouLose()
    {
        PerdisteCanvas.SetActive(true);
    }

    public void ReiniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}

