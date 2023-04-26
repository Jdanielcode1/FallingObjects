using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPanel : MonoBehaviour
{
    public GameObject gameoverPanel;
    private bool gameOver = false;
    

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && !gameOver)
        {
            Time.timeScale = 0; // pause the game
            gameoverPanel.SetActive(true); // show the gameover panel
            gameOver = true;
        }
    }

    public void ReplayGame()
    {
        Time.timeScale = 1; // unpause the game
        timeR.instanciar.ResetTimer();
   
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // reload the current scene

    }

    void Start()
    {
       
        timeR.instanciar.IniciarTiempo();
        gameoverPanel.SetActive(false); // hide the gameover panel at the start of the game
        gameOver = false;
    }
}