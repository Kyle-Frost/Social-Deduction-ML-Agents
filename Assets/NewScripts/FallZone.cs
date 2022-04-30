using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public ButtonEnv env;
    public bool has_fallen = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag=="Player")
        {
            env.AgentTeam.AddGroupReward(-3f);
            env.AgentTeam.GroupEpisodeInterrupted();
            env.Reset();
        }
    }
}
