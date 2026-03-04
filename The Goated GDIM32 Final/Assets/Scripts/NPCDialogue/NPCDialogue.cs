using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NPCDialogue", menuName = "ScriptableObjects/NPCDialogue", order = 2)]
public class NPCDialogue : ScriptableObject
{
    public string[] _lines;
    public string[] _playerReplyOptions;
    public NPCDialogue[] _npcReplies;

}
