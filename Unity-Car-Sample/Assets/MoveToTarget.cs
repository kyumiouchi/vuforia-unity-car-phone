using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveToTarget : MonoBehaviour
{
    NavMeshAgent agent;
    Vector3 destination;

    // Use this for initialization
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            MoveTo();
        }


    }

    void MoveTo()
    {
        RaycastHit hit;

        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);

        if (Physics.Raycast(cameraRay, out hit))
        {
            agent.destination = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}