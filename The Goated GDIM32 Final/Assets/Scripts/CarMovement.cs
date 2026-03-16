using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 5f;
    public float driveTime = 3f;
    

    private bool driving = false;
    private float timer = 0f;

    private void Update()
    {
        if (driving)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);

            timer += Time.deltaTime;

            if (timer >= driveTime)
            {
                EndGame();
            }
        }
    }

    public void StartEscape()
    {
        driving = true;

        Player.Instance.transform.SetParent(transform);
        Player.Instance.enabled = false;
    }

    private void EndGame()
    {
        Debug.Log("Player Escaped!");

        GameController.instance.GameVictory();

        Time.timeScale = 0f;
    }
}