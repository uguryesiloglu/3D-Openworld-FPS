using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectElevationScript : MonoBehaviour
{
    Animator animator;
    public GameObject obj;
    public string elevateTriggerName,descendTriggerName;


    private void Start()
    {
        animator = obj.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Elevate");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            animator.SetTrigger("Descend");
        }
    }
}
