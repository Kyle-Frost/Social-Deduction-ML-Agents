using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public int activeSwitches = 0;
    public int switchGoal = 0;
    public PlayerAgent agent;
    public GameObject startPos;
    public List<Switch> switches;

    private void Update()
    {
        scoreText.text = activeSwitches.ToString() + " / " + switchGoal.ToString();

        if (activeSwitches == switchGoal)
        {
            agent.AddReward(1f);
            agent.EndEpisode();
        }
    }

    public void Reset()
    {
        activeSwitches = 0;
        foreach (Switch s in switches)
        {
            s.Reset();
        }
    }
}
