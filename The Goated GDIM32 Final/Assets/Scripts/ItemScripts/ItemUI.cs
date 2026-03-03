using UnityEngine;
using TMPro;

public class ItemUI : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text text;

    void Awake()
    {
        panel.SetActive(false);
        text.text = "";
    }
    public void ShowCollected(string itemName)
    {
        panel.SetActive(true);
        text.text = itemName + " collected!\nPress 1-7 to select a slot.";
    }

    public void ShowItem(string itemName)
    {
        panel.SetActive(true);
        text.text = itemName + "\nPress E to Eat\nPress Q to Drop";
    }
    public void ShowMessage(string message)
    {
        panel.SetActive(true);
        text.text = message;
    }
    /*void Update()
    {
        if (!panel.activeSelf) return;

        if (Input.GetKeyDown(KeyCode.E))
        {
            text.text = "You have been healed for 10 health.";
            Invoke("Hide", 2f);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            text.text = "Beans dropped.";
            Invoke("Hide", 2f);
        }
    }*/
    void Hide()
    {
        panel.SetActive(false);
        text.text = "";
    }
}