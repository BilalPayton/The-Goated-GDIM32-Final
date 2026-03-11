using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NPCMultipleBranches : MonoBehaviour
{
    [SerializeField] private float _interactionDistance = 2.0f;
    [SerializeField] private NPCDialogue _startNode;

    private NPCDialogue _currentNode;

    [SerializeField] private GameObject _interactText;
    [SerializeField] private GameObject _npcDialogue;
    // [SerializeField] private GameObject _playerReplyOptions;

    [SerializeField] private GameObject _playerReply1;
    [SerializeField] private GameObject _playerReply2;
    [SerializeField] private GameObject _playerReply3;
    [SerializeField] private NPCDialogueUI _playerReplyUI;


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

            if(!_waitingForPlayerResponse && Input.GetKeyDown(KeyCode.Mouse0))
            {
                AdvanceDialogue();
            }
            else if(!_runningDialogue)
            {
                
            }
        }
        else
        {
            EndDialogue();
        }
    }

    private void AdvanceDialogue()
    {
        _runningDialogue = true;
        _interactText.gameObject.transform.position = new Vector3(-1, -1, -1);

        if (_currentLine < _currentNode._lines.Length)
        {
            // if we still have NPC lines left, keep playing NPC lines
            ShowNPCDialogue();

            _currentLine++;
        }
        else if (_currentNode._playerReplyOptions != null && _currentNode._playerReplyOptions.Length > 0)
        {
            // show player dialogue options, if there are any
            HideNPCDialogue();
            _waitingForPlayerResponse = true;
            ShowPlayerReplies();

        }
        else
        {
            // if there are no NPC or player lines left, close dialogue UI
            EndDialogue();
        }
    }

    private void EndDialogue()
    {
        _runningDialogue = false;
        _waitingForPlayerResponse = false;
        _currentNode = _startNode;
        _currentLine = 0;
        _interactText.gameObject.SetActive(false);
    }

    public void SelectedOption(int option)
    {
        _currentLine = 0;
        _waitingForPlayerResponse = false;
        HidePlayerReplies();

        _currentNode = _currentNode._npcReplies[option];
        AdvanceDialogue();
    }


    private void ShowNPCDialogue()
    {
        _npcDialogue.GetComponent<TMP_Text>().text = _currentNode._lines[_currentLine].ToString();
        _npcDialogue.gameObject.SetActive(true);
    }

    private void HideNPCDialogue()
    {
        _npcDialogue.gameObject.SetActive(false);
    }

    private void ShowPlayerReplies()
    {
        Cursor.lockState = CursorLockMode.None;

        int numPlayerOptions = _currentNode._playerReplyOptions.Length;

        for (int i = 0; i < numPlayerOptions; i++)
        {
            if (i == 0)
            {
                _playerReply1.GetComponent<TMP_Text>().text = _currentNode._playerReplyOptions[i].ToString();
            }

            if (i == 1)
            {
                _playerReply2.GetComponent<TMP_Text>().text = _currentNode._playerReplyOptions[i].ToString();
            }

            if (i == 2)
            {
                _playerReply3.GetComponent<TMP_Text>().text = _currentNode._playerReplyOptions[i].ToString();
            }
        }

        switch (numPlayerOptions)
        {
            case 1:
            _playerReply1.gameObject.SetActive(true);
            _playerReply2.gameObject.SetActive(false);
            _playerReply3.gameObject.SetActive(false);
            _playerReplyUI.gameObject.SetActive(true);
                break;

            case 2:
                _playerReply1.gameObject.SetActive(true);
                _playerReply2.gameObject.SetActive(true);
                _playerReply3.gameObject.SetActive(false);
                _playerReplyUI.gameObject.SetActive(true);
                break;

            case 3:
                _playerReply1.gameObject.SetActive(true);
                _playerReply2.gameObject.SetActive(true);
                _playerReply3.gameObject.SetActive(true);
                _playerReplyUI.gameObject.SetActive(true);
                break;


        }

    }

    private void HidePlayerReplies()
    {
        Cursor.lockState = CursorLockMode.Locked;


        _playerReply1.gameObject.SetActive(false);
        _playerReply2.gameObject.SetActive(false);
        _playerReply3.gameObject.SetActive(false);
        _playerReplyUI.gameObject.SetActive(false);

    }
}
