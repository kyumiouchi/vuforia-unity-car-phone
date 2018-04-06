using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToTarget : MonoBehaviour
{
    NavMeshAgent agent;

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
            Debug.Log("Teste");
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
            agent.destination = hit.point;
            Debug.Log("hit.point " + hit.point);
        }
    }
}