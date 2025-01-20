using UnityEditor.SearchService;

using UnityEngine;
using UnityEngine.SceneManagement;
[AddComponentMenu("TienCuong/FinishManager")]
public class FinishManager : MonoBehaviour
{
    public GameObject panelFinish;
    public GameObject panelGameOver;
    public int pauseGame = 0;
    public int resumeGame = 1;
    public void OnButtonRePlay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = resumeGame;
        panelFinish.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void OnButtonHome(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = resumeGame;
        panelFinish.SetActive(false);
        panelGameOver.SetActive(false);
    }
    public void OnButtonContinue()
    {

    }
}
