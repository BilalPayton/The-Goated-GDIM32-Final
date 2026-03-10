using TMPro;
using UnityEngine;

public class PlayerHealthUI : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public void UpdateHealthUI(int current, int max)
    {
        healthText.text = "Health: " + current + " / " + max;
    }
}