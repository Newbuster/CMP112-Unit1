using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameController : MonoBehaviour
{
    public int killCount;
    private string output;
    public TextMeshProUGUI kcUI;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        kcUI.text = "Kills: 0";
    }

    // Update is called once per frame
    void Update()
    {
        output = "Kills: "+ killCount.ToString();
        kcUI.text = output;
    }
}
