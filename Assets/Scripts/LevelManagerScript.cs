using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] float timeToWin = 120f;
    
    private float currTimer = 0f;

    private bool isPaused = false;
    [SerializeField] private GameObject PAUSED;
    [SerializeField] private GameObject QUIT;
    [SerializeField] private GameObject RETRY;
    [SerializeField] private GameObject GAMEOVER;
    //Hey, Angelo here, I added this just to make sure .SetActive works
    void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (currTimer > timeToWin)
            {
                SceneManager.LoadScene(2);
            }
            Debug.Log(currTimer);
            currTimer += Time.deltaTime;
        }
    }
    public void GoToStartMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void GoToLevel()
    {
        SceneManager.LoadScene(1);
    }
    public void GoToCredits()
    {
        SceneManager.LoadScene(3);
    }
    public void Quit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Pause()
    {
        isPaused = !isPaused;

        if (isPaused == true)
        {
            PAUSED.SetActive(true);
            QUIT.SetActive(true);
            Time.timeScale = 0f;
        }

        else
        {
        PAUSED.SetActive(false);
        QUIT.SetActive(false);
        Time.timeScale = 1f;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
        GAMEOVER.SetActive(false);
        Time.timeScale = 1f;
    }

    public void ReturntoMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
