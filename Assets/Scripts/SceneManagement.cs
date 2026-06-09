using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    [SerializeField] private int SceneToLoad;


    public void LoadScreen()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    public void Quit()
    {
        Application.Quit();
    }
}

