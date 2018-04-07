using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUpAndDown : MonoBehaviour {

    public float amplitude = 0.5f;
    public float frequency = 1f;
    Vector3 tempPos;

    //adjust this to change speed
    public float speed = 5f;
    //adjust this to change how high it goes
    public float height = 0.5f;

    private void Start()
    {
        tempPos = transform.position;
    }

    void Update()
    {
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

        transform.position = tempPos;
    }
}
