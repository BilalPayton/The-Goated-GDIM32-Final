using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialogueUI : MonoBehaviour
{
    [SerializeField] public GameObject _uiOne;
    [SerializeField] public GameObject _uiTwo;
    [SerializeField] public GameObject _uiThree;
    void Start()
    {
        _uiOne.SetActive(true);
        _uiTwo.SetActive(true);
        _uiThree.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
