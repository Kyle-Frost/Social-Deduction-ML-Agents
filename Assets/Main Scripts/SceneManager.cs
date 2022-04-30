using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{
    public List<NMAgent> nmAgents;
    public GameObject playerAgent;
    float t;
    float maxtime = 120;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ResetScene();
        }

        if (t < maxtime)
        {
            t += Time.deltaTime;
        }
        else
        {
            playerAgent.GetComponent<PlayerAgent>().EndEpisode();
            t = 0;
        }
    }

    public void ResetScene()
    {
        playerAgent.GetComponent<PlayerAgent>().EndEpisode();
        foreach (NMAgent agent in nmAgents)
        {
            agent.Reset();
        }
    }
}
