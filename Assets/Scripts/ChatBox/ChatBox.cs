using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatBox : MonoBehaviour {

    public Chat ChatData { get; set; }

    [SerializeField]
    private Text _characterTitle;
    [SerializeField]
    private Text _chat;
    [SerializeField]
    private Text _statusChat;
    private Queue _chatSequence;

    private const string _statusChatMenssege = "Continue";

    void Start () {
        _chatSequence = new Queue();
    }
	
	void Update () {        
	}

    public void StartChat()
    {
        EnqueueChat();
        NextSetence();
    }

    public void ResetChat()
    {
        _chatSequence.Clear();
        _characterTitle.text = "";
        _chat.text = "";
        _statusChat.text = "";
    }

    public void NextSetence()
    {
        string[] setence = _chatSequence.Dequeue() as string[];

        _characterTitle.text = setence[0];
        _chat.text = setence[1];
        _statusChat.text = _statusChatMenssege;
    }

    public bool HasSetences()
    {
        return _chatSequence.ToArray().Length > 0;
    }

    private void EnqueueChat()
    {
        int maxCountSetences = 0;
        int indexSetence = 0;

        _chatSequence.Clear();

        for(int i = 0; i < ChatData.chat.Length; i++)
        {
            maxCountSetences = ChatData.chat[i].senteces.Length > maxCountSetences ? ChatData.chat[i].senteces.Length : maxCountSetences;
        }

        while( indexSetence < maxCountSetences)
        {
            for (int i = 0; i < ChatData.chat.Length; i++)
            {
                if( indexSetence < ChatData.chat[i].senteces.Length)
                {
                    _chatSequence.Enqueue(new string[2] { ChatData.chat[i].charName, ChatData.chat[i].senteces[indexSetence] });
                }                
            }

            indexSetence++;
        }
    }   
}
