using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToTarget : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

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
            transform.position = new Vector3(hit.point.x, transform.position.y, hit.point.z);
        }
    }
}