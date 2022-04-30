using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public bool green = false;
    public bool blue = false;

    public Environment env;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (green && !blue)
            {
                if (other.GetComponent<PlayerAgent>().Agent_ID == 1)
                {
                    env.AgentTeam.AddGroupReward(0.5f);
                }
                if (other.GetComponent<PlayerAgent>().Agent_ID == 2)
                {
                    env.AgentTeam.AddGroupReward(-0.5f);
                }
            }
            if (!green && blue)
            {
                if (other.GetComponent<PlayerAgent>().Agent_ID == 2)
                {
                    env.AgentTeam.AddGroupReward(0.5f);
                }
                if (other.GetComponent<PlayerAgent>().Agent_ID == 1)
                {
                    env.AgentTeam.AddGroupReward(-0.5f);
                }
            }

        }
    }
}
