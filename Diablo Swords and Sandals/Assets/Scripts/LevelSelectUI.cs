using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectUI : MonoBehaviour
{
    public GameObject LevelSelectCanvas;

    public void OnTriggerEnter(Collider other)
    {
        LevelSelectCanvas.SetActive(!LevelSelectCanvas.activeSelf);
    }

    public void disableWindow()
    {
        LevelSelectCanvas.SetActive(false);
    }

    public void gotoTrainingScene()
    {
        SceneManager.LoadSceneAsync(1);
    }

    public void gotoTournamentScene()
    {
        SceneManager.LoadSceneAsync(2);
    }
}

