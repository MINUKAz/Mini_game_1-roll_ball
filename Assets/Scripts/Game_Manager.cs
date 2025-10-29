using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public GameObject completelevelUI;
    public float RestartDelay = 1f;
    bool gamehasended = false;
    public void Endgame()
    {
        if (gamehasended == false)
        {
            gamehasended = true;
            Debug.Log("GAME OVER");
            Invoke("Restart", RestartDelay);

        }
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Completelevel()
    {
        completelevelUI.SetActive(true);
    }
}
