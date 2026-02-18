using UnityEngine;
using System.Collections;

public class GameAudio : MonoBehaviour
{
    [SerializeField] private AudioSource _backgroundMusic;

    private void Awake()
    {
        _backgroundMusic.Play();
    }
}