using UnityEngine;
[AddComponentMenu("TienCuong/GameManager")]
public class GameManager : MonoBehaviour
{
    public GameObject panelGameOver;
    public int pauseGame = 0;
    private static GameManager instance;
    public static GameManager Instance
    {
        get => instance;
    }
    public int diamond;
    private void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
    }
    public void SetDiamond(int diamond)
    {
        this.diamond += diamond;
    }
    public int GetDiamond()
    {
        return diamond;
    }
    public void GameOver()
    {
        Time.timeScale = pauseGame;
        panelGameOver.SetActive(true);
    }
}
