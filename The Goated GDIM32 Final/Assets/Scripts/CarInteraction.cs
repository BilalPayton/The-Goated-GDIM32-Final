using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private CarMovement movement;
    private CarUI carUI;

    //public UnityEvent escape;

    private void Start()
    {
        movement = GetComponentInParent<CarMovement>();
        carUI = GetComponentInParent<CarUI>();
    }

    /*private void OnMouseOver()
    {
        Debug.Log("Click to escape");
    }*/

    private void OnMouseDown()
    {
        if (GameController.instance.CurrentState != GameState.FindCar)
        {
            return;
        }

        if (movement != null)
        {
            movement.StartEscape();

            //escape?.Invoke();
        }

        if (carUI != null)
        {
            carUI.OnCarClicked();
        }

    }

}