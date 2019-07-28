using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneLoader : MonoBehaviour
{
    public void LoadLevel(int buildID)
    {
        SceneManager.LoadScene(buildID);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
