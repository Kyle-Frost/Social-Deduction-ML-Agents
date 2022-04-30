using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class PlayerAgentGate : Agent
{
    public int Agent_ID = 0;
    private int xDir = 0;
    private int yDir = 0;
    public float speed = 6;
    public float height;

    float t;
    float maxTime = 120;

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (Mathf.FloorToInt(actions.DiscreteActions[0]) == 0)
        {
            yDir = 0;
        }
        if (Mathf.FloorToInt(actions.DiscreteActions[0]) == 1)
        {
            yDir = 1;
        }
        if (Mathf.FloorToInt(actions.DiscreteActions[0]) == 2)
        {
            yDir = -1;
        }

        if (Mathf.FloorToInt(actions.DiscreteActions[1]) == 0)
        {
            xDir = 0;
        }
        if (Mathf.FloorToInt(actions.DiscreteActions[1]) == 1)
        {
            xDir = 1;
        }
        if (Mathf.FloorToInt(actions.DiscreteActions[1]) == 2)
        {
            xDir = -1;
        }

        float horizontal = xDir * Time.deltaTime * speed;
        float vertical = yDir * Time.deltaTime * speed;
        transform.Translate(horizontal, 0, vertical);
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        if (Input.GetKey(KeyCode.W) && Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[0] = 1;
        }
        else if (Input.GetKey(KeyCode.S) && Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[0] = 2;
        }
        else if (Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[0] = 0;
        }

        if (Input.GetKey(KeyCode.D) && Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[1] = 1;
        }
        else if (Input.GetKey(KeyCode.A) && Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[1] = 2;
        }
        else if (Agent_ID == 1)
        {
            actionsOut.DiscreteActions.Array[1] = 0;
        }

        if (Input.GetKey(KeyCode.UpArrow) && Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[0] = 1;
        }
        else if (Input.GetKey(KeyCode.DownArrow) && Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[0] = 2;
        }
        else if (Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[0] = 0;
        }

        if (Input.GetKey(KeyCode.RightArrow) && Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[1] = 1;
        }
        else if (Input.GetKey(KeyCode.LeftArrow) && Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[1] = 2;
        }
        else if (Agent_ID == 2)
        {
            actionsOut.DiscreteActions.Array[1] = 0;
        }

        if (Input.GetKey(KeyCode.E))
        {
            actionsOut.DiscreteActions.Array[2] = 1;
        }
    }

    public override void OnEpisodeBegin()
    {
        //Debug.Log("New Episode");
        //Reset();
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(Agent_ID);
        //sensor.AddObservation(transform.localPosition);
    }

    private void Update()
    {
        /*if (t < maxTime)
        {
            t += Time.deltaTime;
        }
        else
        {
            AddReward(-1f);
            EndEpisode();
        }*/
    }


    public void Reset()
    {
        t = 0;
        transform.localPosition = new Vector3(Random.Range(-33, 22), height, Random.Range(-22, 22));
        /*foreach (NMAgent agent in nmAgents)
        {
            agent.Reset();
        }*/
    }
}
