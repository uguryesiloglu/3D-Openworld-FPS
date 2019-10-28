using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManagerScript : MonoBehaviour
{
    public TextMeshProUGUI generalMessages;
    bool isActive;


    public void SetMessageText(string aMessage)
    {
        generalMessages.text = aMessage;
        if (!isActive)
        {
            StartCoroutine(ClearAfter5Secs());
        }
    }

    IEnumerator ClearAfter5Secs()
    {
        yield return new WaitForSeconds(5f);
        generalMessages.text = "";
    }

}
