using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Environment : MonoBehaviour
{
    public GameObject buttonOne;
    public GameObject buttonTwo;
    public FallZone fallZone;

    public List<Agent> agents;
    public SimpleMultiAgentGroup AgentTeam;
    public GameObject spawnOne;
    public GameObject spawnTwo;
    public int MaxSteps = 25000;
    private int ResetTimer = 0;

    public bool oneTriggered = false;
    public bool twoTriggered = false;

    private void Start()
    {
        AgentTeam = new SimpleMultiAgentGroup();
        foreach (Agent item in agents)
        {
            AgentTeam.RegisterAgent(item);
        }
    }

    private void FixedUpdate()
    {
        ResetTimer += 1;
        if (ResetTimer >= MaxSteps && MaxSteps > 0)
        {
            AgentTeam.GroupEpisodeInterrupted();
            ResetScene();
        }
        AgentTeam.AddGroupReward(-0.5f / MaxSteps);


        if (buttonOne.GetComponent<Button>().isTriggered)
        {
            AgentTeam.AddGroupReward(0.5f / MaxSteps);
        }
        if (buttonTwo.GetComponent<Button>().isTriggered)
        {
            AgentTeam.AddGroupReward(0.5f / MaxSteps);
        }

        if (buttonOne.GetComponent<Button>().isTriggered && buttonTwo.GetComponent<Button>().isTriggered)
        {
            Debug.Log("Success");
            AgentTeam.AddGroupReward(1f);
            AgentTeam.EndGroupEpisode();
            ResetScene();
        }
        if (fallZone.has_fallen)
        {
            AgentTeam.AddGroupReward(-1f);
            AgentTeam.GroupEpisodeInterrupted();
            ResetScene();
        }
    }

    void ResetScene()
    {
        ResetTimer = 0;
        agents[0].transform.position = spawnOne.transform.position;
        agents[1].transform.position = spawnTwo.transform.position;

        buttonOne.GetComponent<Button>().isTriggered = false;
        buttonTwo.GetComponent<Button>().isTriggered = false;
        fallZone.has_fallen = false;
    }
}
