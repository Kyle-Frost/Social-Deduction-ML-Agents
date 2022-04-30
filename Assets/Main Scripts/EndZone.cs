using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndZone : MonoBehaviour
{
    public ButtonEnv env;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            env.AgentTeam.AddGroupReward(3f);
            env.AgentTeam.EndGroupEpisode();
            Debug.Log("Success");
            env.Reset();
        }
    }
}
