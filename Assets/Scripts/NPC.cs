using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public Chat chat;
    private UIManager _uiManager;    

    private void Start()
    {        
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void OnTriggerEnter2D()
    {
        _uiManager.SetChat(chat);
    }

    private void OnTriggerExit2D()
    {
        _uiManager.SetChat(null);
    }
}
