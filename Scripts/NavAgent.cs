using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class NavAgent : MonoBehaviour
{
    public WaypointNetwork WaypointNetwork = null;
    public int CurrentIndex = 0;
    public bool hasPath = false;
    public bool pathPending = false;
    public NavMeshPathStatus pathStatus = NavMeshPathStatus.PathInvalid;
    public float currentSpeed;

    private NavMeshAgent _navAgent = null;

    // Use this for initialization
    void Start()
    {
        //cache NavMeshAgent reference
        _navAgent = GetComponent<NavMeshAgent>();

        if (WaypointNetwork == null) return;

        SetNextDestination(false);
	}

    void SetNextDestination (bool increment)
    {
        if (!WaypointNetwork)
        {
            return;
        }

        int incStep = 0;

        if (increment)
        {
            incStep = 1;
        }
        else
            incStep = 0;

        int nextWaypoint = 0;
        Transform nextWaypointTransform = null;


        if (CurrentIndex + incStep >= WaypointNetwork.Waypoints.Count)
        {
            nextWaypoint = 0;
        }
        else
        {
            nextWaypoint = CurrentIndex + incStep;
        }

        nextWaypointTransform = WaypointNetwork.Waypoints[nextWaypoint];

        if(nextWaypointTransform != null)
        {
            CurrentIndex = nextWaypoint;
            _navAgent.destination = nextWaypointTransform.position;
            return;
        }
        
        CurrentIndex++;
    }

	// Update is called once per frame
	void Update ()
    {
        hasPath = _navAgent.hasPath;
        pathPending = _navAgent.pathPending;
        pathStatus = _navAgent.pathStatus;
        currentSpeed = _navAgent.speed;

        if (!hasPath && !pathPending)
        {
            SetNextDestination(true);
        }
        else
        {
            if (_navAgent.isPathStale)
            {
                SetNextDestination(false);
            }
        }
	}
}
