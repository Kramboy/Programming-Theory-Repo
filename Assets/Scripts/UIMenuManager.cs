using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
#endif

public class UIMenuManager : MonoBehaviour
{
    private const int MAIN_SCENE_INDEX = 1;

    public void StartGame()
    {
        SceneManager.LoadScene(MAIN_SCENE_INDEX);
    }

    public void ExitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.ExitPlaymode();
#endif
        Application.Quit();
    }
}
