using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCMultipleBranches : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2.0f;
    [SerializeField] private NPCDialogue _startNode;

    private NPCDialogue _currentNode;

    [SerializeField] private TextMeshPro _interactText;

    private int _currentLine = 0;
    private bool _runningDialogue;
    private bool _waitingForPlayerResponse;

    private void Start()
    {
        _currentNode = _startNode;
    }

    private void Update()
    {
        if(Player.Instance == null) return;

        if(Vector3.Distance(transform.position, Player.Instance.transform.position) < _interactionDistance)
        {
            _interactText.gameObject.SetActive(true);

            if(!_waitingForPlayerResponse && Input.GetKeyDown(KeyCode.Space))
            {
                
            }
            else if(!_runningDialogue)
            {
                
            }
        }
        else
        {
            
        }
    }
}
