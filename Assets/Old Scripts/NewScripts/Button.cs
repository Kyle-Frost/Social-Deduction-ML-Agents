using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public Environment env;
    public int buttonNumber = 0;
    public bool isTriggered = false;

    private void OnTriggerStay(Collider other)
    {
        if (other.tag=="Player")
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag=="Player")
        {
            isTriggered = false;
        }
    }
}
