using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private CarMovement movement;

    private void Start()
    {
        movement = GetComponentInParent<CarMovement>();
    }

    private void OnMouseOver()
    {
        Debug.Log("Click to escape");
    }

    private void OnMouseDown()
    {
        if (movement != null)
        {
            movement.StartEscape();
        }
    }

}