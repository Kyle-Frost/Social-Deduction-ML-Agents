using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;

public class Switch : MonoBehaviour
{
    public Material disabledMat;
    public Material enabledMat;

    public bool isEnabled = false;
    private bool inZone = false;

    private bool isPlayer = false;
    private bool isImposter = false;

    public GameManager gm;
    public GameObject plane;

    private void Start()
    {
        ChangeMaterial(disabledMat);
    }

    void ChangeMaterial(Material mat)
    {
        this.gameObject.GetComponent<Renderer>().material = mat;
    }

    public void Reset()
    {
        ChangeMaterial(disabledMat);
        isEnabled = false;
        gameObject.tag = "ButtonOff";
        gameObject.transform.localPosition = new Vector3(Random.Range(-33f, 27f), 1, Random.Range(-23f, 17f));
    }

    public void EnableSwitch()
    {
        isEnabled = true;
        ChangeMaterial(enabledMat);
        gameObject.tag = "ButtonOn";
        gm.activeSwitches++;
        gm.agent.AddReward(0.1f);
    }
    public void DisableSwitch()
    {
        isEnabled = false;
        ChangeMaterial(disabledMat);
        gameObject.tag = "ButtonOff";
        gm.activeSwitches--;
    }
}
