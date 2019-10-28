using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeStyleOpenCloseAnimationByScript : MonoBehaviour
{
    public Transform hatch;
    public Transform dummyOpen;
    public Transform dummyClosed;
    public MessageBroadcaster messageBroadcaster;
    Quaternion startRotation;
    Quaternion targetRotation;
    bool isAnimating;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            OpenHatch();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CloseHatch();
        }
    }

    public void OpenHatch()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            startRotation = hatch.localRotation;
            targetRotation = dummyOpen.localRotation;
            StartCoroutine(AnimateHatch());
        }
        else
        {
            Invoke("OpenHatch", 1f);
        }
    }

    public void CloseHatch()
    {
        if (!isAnimating)
        {
            isAnimating = true;
            startRotation = hatch.localRotation;
            targetRotation = dummyClosed.localRotation;
            StartCoroutine(AnimateHatch());
        }
        else
        {
            Invoke("CloseHatch", 1f);

        }
    }

    //animasyonlar IEnumaratorlerle yapılır.

    IEnumerator AnimateHatch()
    {
        float timer = 0;
        float duration = 1f;

        while (timer < duration)
        {
            hatch.localRotation = Quaternion.Lerp(startRotation, targetRotation, timer / duration);
            timer += Time.deltaTime;
            yield return null;
        }
        //yield return new WaitForSeconds(3f);


        isAnimating = false;

        if (messageBroadcaster != null)
        {
            if (messageBroadcaster.message != null && messageBroadcaster.message != "")
            {
                messageBroadcaster.SendMessageToPlayer();
            }
        }
    }



}
