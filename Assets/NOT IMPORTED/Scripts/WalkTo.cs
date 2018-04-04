using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WalkTo : MonoBehaviour {
    public NavMeshAgent agent;
    public Transform destination;
    // Use this for initialization
    void Start()
    {
        agent.destination = destination.position;
    }
}
