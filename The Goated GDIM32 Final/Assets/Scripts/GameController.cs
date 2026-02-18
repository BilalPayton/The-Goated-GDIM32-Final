using UnityEngine;
using System.Collections;

public enum GameState
{
    Quest1,
    Quest2,
    Escaping
}

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState CurrentState;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
       CurrentState = GameState.Quest1;
    }

    
}