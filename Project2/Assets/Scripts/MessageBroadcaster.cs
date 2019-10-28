using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageBroadcaster : MonoBehaviour
{
    public string message;
    public bool oneTimeMessage;
    public void SendMessageToPlayer()
    {
        GameObject canvasObj = GameObject.FindGameObjectWithTag("UserInterface");

        canvasObj.GetComponent<UIManagerScript>().SetMessageText(message);
        if (oneTimeMessage)
        {
            message = "";
        }
    }
}
