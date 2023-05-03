using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking.Types;
using TMPro;


public class GameOverPanel : MonoBehaviour
{
    public GameObject gameoverPanel;
    private bool gameOver = false;
    public TextMeshProUGUI Crono;
    public TextMeshProUGUI pointsText;



    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" && !gameOver)
        {
            GameOverPanel gameOverPanel = FindObjectOfType<GameOverPanel>();
            if (gameOverPanel != null)
            {
                gameOverPanel.PostData();
            }
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
        if (gameoverPanel == null)
        {
            gameoverPanel = GameObject.Find("GameOverPanel");
        }
        gameoverPanel.SetActive(false); // hide the gameover panel at the start of the game
        gameOver = false;
    }
    void PostData() => StartCoroutine(PostData_Coroutine());

    IEnumerator PostData_Coroutine()
    {

        string uri = "https://info-api.herokuapp.com/partida_falling_objects/";
        WWWForm form = new WWWForm();

        form.AddField("player", "https://info-api.herokuapp.com/player_user/1/");
        form.AddField("score", pointsText.text);
        form.AddField("time_taken", Crono.text);
        using (UnityWebRequest request = UnityWebRequest.Post(uri, form))
        {
            yield return request.SendWebRequest();
            if (request.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(request.error);
            }
            else
            {
                Debug.Log(request.downloadHandler.text);
            }
        }

    }
}