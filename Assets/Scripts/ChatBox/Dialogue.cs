using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC Chat", menuName = "NPC Chat")]
public class Chat : ScriptableObject {

    public Sentence[] chat;
}
