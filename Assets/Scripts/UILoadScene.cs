using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[AddComponentMenu("TienCuong/UILoadScene")]
public class UILoadScene : MonoBehaviour
{
    public string scene = "";
    public GameObject panelMain;
    public GameObject panelOption;
    public void OnClick()
    {
        SceneManager.LoadScene(scene);
    }
    public void OnClickOption()
    {
        panelOption.SetActive(true);
        panelMain.SetActive(false);
    }
    public void OnClickBack()
    {
        panelMain.SetActive(true);
        panelOption.SetActive(false);
    }
    public void ONClickExit()
    {
        Application.Quit();
    }
}
