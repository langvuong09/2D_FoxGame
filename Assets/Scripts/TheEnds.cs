using UnityEngine;

[AddComponentMenu("TienCuong/TheEnds")]
public class TheEnds : MonoBehaviour
{
    public GameObject panelFinish;
    public int pauseGame = 0;
    public int lenh = 0;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Finish"))
        {
            lenh = 1;
        }
        else
        {
            lenh = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Finish"))
        {
            lenh = 0;
        }
    }

    private void Update()
    {
        if (lenh == 1 && Input.GetKeyDown(KeyCode.Return))
        {
            panelFinish.SetActive(true);
            Time.timeScale = pauseGame;
        }
    }
}
