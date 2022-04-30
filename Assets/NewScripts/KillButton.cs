using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillButton : MonoBehaviour
{
    public ButtonEnv env;
    public GameObject wall;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            wall.SetActive(false);
            env.AgentTeam.AddGroupReward(0.5f);
            other.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
