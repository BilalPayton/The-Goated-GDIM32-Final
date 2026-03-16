using UnityEngine;

public class CarInteraction : MonoBehaviour
{
    private CarMovement movement;
    private CarUI carUI;

    [SerializeField] private ItemData carKey;

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
       
        InventoryUI ui = FindObjectOfType<InventoryUI>();

        if (ui == null || ui.inventory == null)
        {
            return;
        }

        
        if (!ui.inventory.Contains(carKey))
        {
            if (carUI != null)
            {
                carUI.ShowMessage("I need the car key.");
            }
            return;
        }

        
        ui.inventory.Remove(carKey);
        ui.Refresh();

        if (movement != null)
        {
            movement.StartEscape();
        }

        if (carUI != null)
        {
            carUI.OnCarClicked();
        }
    }

}