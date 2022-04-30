using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class ButtonEnv : MonoBehaviour
{
    public List<Agent> agents;
    public SimpleMultiAgentGroup AgentTeam;

    public GameObject spawnOne;
    public GameObject spawnTwo;
    public GameObject spawnThree;

    public GameObject WallOne;
    public GameObject WallTwo;
    public GameObject buttonOne;
    public GameObject buttonTwo;

    private int ResetTimer = 0;
    private int MaxSteps = 25000;

    private void Start()
    {
        AgentTeam = new SimpleMultiAgentGroup();
        foreach (Agent item in agents)
        {
            AgentTeam.RegisterAgent(item);
        }
    }

    public void Reset()
    {
        agents[0].transform.position = spawnOne.transform.position;
        agents[1].transform.position = spawnTwo.transform.position;
        agents[2].transform.position = spawnThree.transform.position;

        agents[0].gameObject.SetActive(true);
        agents[1].gameObject.SetActive(true);
        agents[2].gameObject.SetActive(true);

        ResetTimer = 0;

        WallOne.SetActive(true);
        WallTwo.SetActive(true);
        buttonOne.SetActive(true);
        buttonTwo.SetActive(true);
    }

    private void FixedUpdate()
    {
        ResetTimer += 1;
        if (ResetTimer >= MaxSteps && MaxSteps > 0)
        {
            AgentTeam.GroupEpisodeInterrupted();
            Reset();
        }
        AgentTeam.AddGroupReward(-0.5f / MaxSteps);
    }
}
