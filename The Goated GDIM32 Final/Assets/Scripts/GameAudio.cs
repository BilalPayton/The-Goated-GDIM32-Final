using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _currentMusic;
    [SerializeField] private AudioClip _backgroundMusic;
    [SerializeField] private AudioClip _chaseMusic;
    [SerializeField] private ZombieNPC _zombie;
    private bool _isChasing = false;

    private void Awake()
    {
        if(_zombie != null)
        {
            _zombie.chaseMusicEvent += InitiateChase;
            _zombie.stopChaseMusicEvent += StopChase;
        }
        
    }

    private void Start()
    {
        _currentMusic.clip = _backgroundMusic;
        _currentMusic.Play();
    }

    private void Update()
    {
        if (_isChasing == true)
        {
            if (_currentMusic.clip == _backgroundMusic)
            {
                _currentMusic.clip = _chaseMusic;
                _currentMusic.Play();
            }

        }

        else
        {
            if (_currentMusic.clip == _chaseMusic)
            {
                _currentMusic.clip = _backgroundMusic;
                _currentMusic.Play();
            }
            
        }

    }

    public void InitiateChase()
    {
        _isChasing = true;
    }

    public void StopChase()
    {
        _isChasing = false;
    }
}