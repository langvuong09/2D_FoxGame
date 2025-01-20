using System.Collections;

using TMPro;

using UnityEngine;
[AddComponentMenu("TienCuong/UIManager")]
public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI textDiamond;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(UpdateUI());
    }

    // Update is called once per frame
    private IEnumerator UpdateUI()
    {
        while (true)
        {
            textDiamond.text = GameManager.Instance.GetDiamond().ToString();
            yield return new WaitForSeconds(0.2f);
        }
    }
}
