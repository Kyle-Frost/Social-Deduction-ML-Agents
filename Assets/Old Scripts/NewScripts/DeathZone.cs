using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        /*if (other.tag == "Player")
        {
            //other.GetComponent<PlayerAgent>().AddReward(-1f);
            other.GetComponent<PlayerAgent>().EndEpisode();
        }*/

        if (other.GetComponent<PlayerAgent>().enabled)
        {
            other.GetComponent<PlayerAgent>().Reset();
        }
        if (other.GetComponent<NMAgent>().enabled)
        {
            other.GetComponent<NMAgent>().Reset();
        }
    }
}
