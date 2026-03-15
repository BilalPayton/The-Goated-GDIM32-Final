using UnityEngine;

public class CarUI : MonoBehaviour
{
    public GameObject clickUI;
    public float interactionDistance = 3f;

    private Transform player;

    private void Start()
    {
        player = Player.Instance.transform;
        
        if (clickUI != null)
            clickUI.SetActive(false);
    }

    private void Update()
    {
        float distance = Vector3.Distance(player.position, transform.position);

        if (clickUI != null)
        {
            clickUI.SetActive(distance < interactionDistance);
        }
    }
}
