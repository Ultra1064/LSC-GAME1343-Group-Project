using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] float timeToWin = 120f;
    
    private float currTimer = 0f;
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
}
