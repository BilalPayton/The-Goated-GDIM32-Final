using UnityEngine;

public class CarUI : MonoBehaviour
{
    public GameObject clickUI;
    public GameObject victoryUI;
    public GameObject messageUI;
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

        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }

    }

    private void Update()
    {
        if (escaped) 
        {
            return;
        }

        float distance = Vector3.Distance(player.position, transform.position);

        if (messageUI != null && messageUI.activeSelf)
        {
            return;
        }

        if (clickUI != null)
        {
            clickUI.SetActive(distance < interactionDistance);
        }
    }

    public void OnCarClicked()
    {
        escaped = true;

        clickUI.SetActive(false);

        Invoke(nameof(ShowVictory), 2f);
    }

    private void ShowVictory()
    {
        if (victoryUI != null)
        {
            victoryUI.SetActive(true);
        }

        GameController.instance.GameVictory();
    }

    public void ShowMessage(string message)
    {
        Debug.Log("ShowMessage called");


        if (messageUI != null)
        {
            messageUI.SetActive(true);
        }

        if (clickUI != null)
        {
            clickUI.SetActive(false);
        }

        Debug.Log(message);
        Invoke(nameof(HideMessage), 3f);
    }

    private void HideMessage()
    {
        if (messageUI != null)
        {
            messageUI.SetActive(false);
        }
    }
}
