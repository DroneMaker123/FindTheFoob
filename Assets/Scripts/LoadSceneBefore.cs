using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneBefore : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}