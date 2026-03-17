using UnityEngine;
using System.Collections;
using UnityEngine.AI;

//Laura
public enum GameState
{
    FindBeans,
    GiveBeans,
    FindCar,
    Escaped
}


public class GameController : MonoBehaviour
{
    public static GameController instance;

    public GameState CurrentState;

    [SerializeField] private GameObject _zombiePrefab;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _spawnInterval = 5f;
    [SerializeField] private int _maxZombies = 10;

    private int _currentZombieCount;
    private float _spawnTimer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        CurrentState = GameState.FindBeans;
    }

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {

        if (CurrentState == GameState.Escaped)
        {
            return;
        }
        {
            _spawnTimer += Time.deltaTime;

            if (_spawnTimer >= _spawnInterval)
            {
                _spawnTimer = 0f;

                if (_currentZombieCount < _maxZombies)
                {
                    SpawnZombie();
                }
            }
        }
    }

    private void SpawnZombie()
    {
        if (_spawnPoints.Length == 0) return;

        int index = Random.Range(0, _spawnPoints.Length);
        Transform spawnPoint = _spawnPoints[index];

        NavMeshHit hit;
        if(NavMesh.SamplePosition(spawnPoint.position, out hit, 2f, NavMesh.AllAreas))
        {
            Instantiate(_zombiePrefab, hit.position, spawnPoint.rotation);
            _currentZombieCount++;
        }
        else
        {
            Debug.LogWarning("No NavMesh found near spawn point:" + spawnPoint.name);
        }
    }

    public void GiveItem(ItemData item)
    {
        Debug.Log("Giving item: " + item._name);

        Player.Instance.player._inventory.Remove(item);

        FindObjectOfType<InventoryUI>().Refresh();
    }

    public void GameVictory()
    {
        CurrentState = GameState.Escaped;

        Time.timeScale = 0f;
    }

    public void AdvanceState()
    {
        if (CurrentState == GameState.FindBeans)
        {
            CurrentState = GameState.GiveBeans;
            Debug.Log("State → GiveBeans");
        }
        else if (CurrentState == GameState.GiveBeans)
        {
            CurrentState = GameState.FindCar;
            Debug.Log("State → FindCar");
        }


        // public void ZombieDied()
        //{
        //   _currentZombieCount--;
        // }

    }
}