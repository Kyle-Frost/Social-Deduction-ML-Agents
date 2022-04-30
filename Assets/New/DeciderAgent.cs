using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using TMPro;
using UnityEngine.UI;
using UnityEngine.AI;

public class DeciderAgent : Agent
{
    public List<GameObject> players;

    public GameObject player;
    public GameObject NPCOne;
    public GameObject NPCTwo;
    public GameObject NPCThree;

    public GameObject floor;
    public Material red;
    public Material green;
    public Material black;

    public TMP_Text correctText;
    public TMP_Text incorrectText;
    private int correct = 0;
    private int incorrect = 0;

    public float maxTime = 60;
    private float t;

    public void ShuffleList()
    {
        for (int i = 0; i < players.Count; i++)
        {
            GameObject temp = players[i];
            int randomIndex = Random.Range(i, players.Count);
            players[i] = players[randomIndex];
            players[randomIndex] = temp;
        }
    }

    public void RandomiseAgents()
    {
        int randomIndex = Random.Range(0, 4);

        for (int i = 0; i < players.Count; i++)
        {
            if (i == randomIndex)
            {
                players[randomIndex].GetComponent<NavMeshAgent>().enabled = false;
                players[randomIndex].GetComponent<NMAgent>().enabled = false;
                players[randomIndex].GetComponent<PlayerAgent>().enabled = true;
                players[randomIndex].GetComponent<PlayerAgent>().Reset();
            }
            else
            {
                players[i].GetComponent<NavMeshAgent>().enabled = true;
                players[i].GetComponent<NMAgent>().enabled = true;
                players[i].GetComponent<PlayerAgent>().enabled = false;
                players[i].GetComponent<NMAgent>().Reset();
            }
        }

        
    }

    private void Start()
    {
        ShuffleList();
        //RandomiseAgents();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RandomiseAgents();
        }

        if (t < maxTime)
        {
            t += Time.deltaTime;
        }
        else
        {
            RequestDecision();
        }
    }

    private void UpdateText()
    {
        correctText.text = "Correct: " + correct;
        incorrectText.text = "Incorrect: " + incorrect;
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        if (actions.DiscreteActions[0] == 0)
        {
            CheckPlayer(players[0]);
            Debug.Log("One");
        }
        if (actions.DiscreteActions[0] == 1)
        {
            CheckPlayer(players[1]);
            Debug.Log("Two");
        }
        if (actions.DiscreteActions[0] == 2)
        {
            CheckPlayer(players[2]);
            Debug.Log("Three");
        }
        if (actions.DiscreteActions[0] == 3)
        {
            CheckPlayer(players[3]);
            Debug.Log("Four");
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            actionsOut.DiscreteActions.Array[0] = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            actionsOut.DiscreteActions.Array[0] = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            actionsOut.DiscreteActions.Array[0] = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            actionsOut.DiscreteActions.Array[0] = 3;
        }
    }

    public override void OnEpisodeBegin()
    {
        //Reset();
        ShuffleList();
        //RandomiseAgents();
        t = 0;
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        sensor.AddObservation(player.transform.localPosition);
        sensor.AddObservation(NPCOne.transform.localPosition);
        sensor.AddObservation(NPCTwo.transform.localPosition);
        sensor.AddObservation(NPCThree.transform.localPosition);

        sensor.AddObservation(players.IndexOf(player));
        sensor.AddObservation(players.IndexOf(NPCOne));
        sensor.AddObservation(players.IndexOf(NPCTwo));
        sensor.AddObservation(players.IndexOf(NPCThree));
    }

    public void Reset()
    {
        player.GetComponent<PlayerAgent>().Reset();
        NPCOne.GetComponent<NMAgent>().Reset();
        NPCTwo.GetComponent<NMAgent>().Reset();
        NPCThree.GetComponent<NMAgent>().Reset();
        t = 0;
    }

    public void CheckPlayer(GameObject player)
    {
        if (player.tag == "Player")
        {
            AddReward(1f);
            StartCoroutine(ChangeMat(true));
            correct++;
            UpdateText();
            EndEpisode();
        }
        else
        {
            AddReward(-1f);
            StartCoroutine(ChangeMat(false));
            incorrect++;
            UpdateText();
            EndEpisode();
        }

        /*if (player.GetComponent<PlayerAgent>().enabled)
        {
            AddReward(1f);
            StartCoroutine(ChangeMat(true));
            correct++;
            UpdateText();
            EndEpisode();
        }
        else
        {
            AddReward(-1f);
            StartCoroutine(ChangeMat(false));
            incorrect++;
            UpdateText();
            EndEpisode();
        }*/
    }
    
    IEnumerator ChangeMat (bool result)
    {
        if (result)
        {
            floor.GetComponent<Renderer>().material = green;
        }
        else
        {
            floor.GetComponent<Renderer>().material = red;
        }
        yield return new WaitForSeconds(2);
        floor.GetComponent<Renderer>().material = black;
    }
}
