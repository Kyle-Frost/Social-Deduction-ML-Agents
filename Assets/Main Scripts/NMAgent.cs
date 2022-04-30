using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NMAgent : MonoBehaviour
{
    public float minWaitTime;
    public float maxWaitTime;
    private NavMeshAgent nmAgent;
    public Vector3 goal;
    private bool hasStopped = false;
    public float height;

    private void Awake()
    {
        nmAgent = GetComponent<NavMeshAgent>();
        goal = GetPoint();
        if (enabled) nmAgent.destination = goal;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.localPosition, goal) < 2 && !hasStopped)
        {
            hasStopped = true;
            float t = Random.Range(minWaitTime, maxWaitTime);
            StartCoroutine(SetAgentDestination(t));
        }
    }

    IEnumerator SetAgentDestination(float time)
    {
        yield return new WaitForSeconds(time);
        goal = GetPoint();
        if (enabled) nmAgent.destination = goal;
        hasStopped = false;
    }

    public Vector3 GetPoint()
    {
        return new Vector3(Random.Range(-33, 33), height, Random.Range(-22, 22));
    }

    public void Reset()
    {
        transform.localPosition = GetPoint();
        goal = GetPoint();
        if (enabled) nmAgent.destination = goal;
        hasStopped = false;
    }
}
