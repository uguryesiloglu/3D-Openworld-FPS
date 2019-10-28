using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HingeStyleOpenClose : MonoBehaviour
{
    Animator animator;
    public GameObject obj;
    public string openTriggerName, closeTriggerName;

    // Start is called before the first frame update
    void Start()
    {
        animator = obj.GetComponent<Animator>();
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger(openTriggerName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger(closeTriggerName);
        }
    }
}
