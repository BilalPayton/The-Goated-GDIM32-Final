using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;
    [SerializeField] private AudioSource _chaseMusic;

    private void Awake()
    {
        _backgroundMusic.Play();
    }

    public void InitiateChase()
    {
        _backgroundMusic.Stop();
        _chaseMusic.Play();
    }

    public void StopChase()
    {
        _chaseMusic.Stop();
        _backgroundMusic.Play();
    }
}