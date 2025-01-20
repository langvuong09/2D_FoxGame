using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("TienCuong/PauseManager")]
public class PauseManager : MonoBehaviour
{
    public GameObject panelPause;
    public int pauseGame = 0;
    public int resumeGame = 1;
    void Start()
    {

    }

    // Update is called once per frame
    public void OnButtonPause()
    {
        panelPause.SetActive(true);
        Time.timeScale = pauseGame;
    }

    public void OnButtonExit()
    {
        panelPause.SetActive(false);
        Time.timeScale = resumeGame;
    }

    public void OnButtonMenu(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = resumeGame;
    }
}
