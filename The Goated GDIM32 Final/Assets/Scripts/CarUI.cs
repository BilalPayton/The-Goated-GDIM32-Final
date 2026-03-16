using UnityEngine;

public class CarUI : MonoBehaviour
{
    public GameObject clickUI;
    public GameObject victoryUI;
    public float interactionDistance = 2f;

    private Transform player;
    private bool escaped = false;

    private void Start()
    {
        player = Player.Instance.transform;

        if (clickUI != null)
        {
            clickUI.SetActive(false);

        }

        if (victoryUI != null)
        {
            victoryUI.SetActive(false);
        }

    }

    private void Update()
    {
        if (escaped) 
        {
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);

        if (clickUI != null)
        {
            clickUI.SetActive(distance < interactionDistance);
        }
    }

    public void OnCarClicked()
    {
        escaped = true;

        clickUI.SetActive(false);

        Invoke(nameof(ShowVictory), 3f);
    }

    private void ShowVictory()
    {
        if (victoryUI != null)
        {
            victoryUI.SetActive(true);
        }

        GameController.instance.GameVictory();
    }
}
