using UnityEngine;
using System.Collections;

//Laura
public enum GameState
{
    Quest1,
    Escaping
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
       CurrentState = GameState.Quest1;
    }

    private void Update()
    {
        HandleSpawning();
    }

    private void HandleSpawning()
    {
 
        if (CurrentState == GameState.Escaping)
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

        Instantiate(_zombiePrefab, spawnPoint.position, Quaternion.identity);

        _currentZombieCount++;
    }

    public void GiveItem(ItemData item)
    {
        Debug.Log("Giving item: " + item._name);

        Player.Instance.player._inventory.Remove(item);

        FindObjectOfType<InventoryUI>().Refresh();
    }

    // public void ZombieDied()
    //{
    //   _currentZombieCount--;
    // }

}