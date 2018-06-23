using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    [SerializeField]
    private GameObject _chatBox;
    private ChatBox _chatBoxScript;
    public bool EnabledChat { get; set; }

    // Use this for initialization
    void Start () {
        _chatBoxScript = _chatBox.GetComponent<ChatBox>();
        ResetChat();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space) && EnabledChat)
        {
            if( !_chatBox.activeSelf)
            {
                _chatBox.SetActive(true);
                _chatBoxScript.StartChat();
                Debug.Log("Começou");
            }
            else
            {
                if (_chatBoxScript.HasSetences())
                {
                    _chatBoxScript.NextSetence();
                    Debug.Log("Continua");
                }
                else
                {
                    _chatBox.SetActive(false);
                    ResetChat();
                    Debug.Log("Terminou");
                }                 
            }            
        }
    }    

    public void ResetChat()
    {
        _chatBox.SetActive(false);        
        _chatBoxScript.ResetChat();
    }

    public void SetChat( Chat NPCchat )
    {
        if(NPCchat != null)
        {
            EnabledChat = true;
            _chatBoxScript.ChatData = NPCchat;
        }
        else
        {
            EnabledChat = false;
            _chatBoxScript.ChatData = null;
            ResetChat();
        }
    }
}
