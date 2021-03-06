﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using Vuforia;

public class PickUpItems : MonoBehaviour {

    public Text countText;
    public Image winText;
    public int maxItems;
    public Button restartButton;
    public GameObject[] pickUps;
    public GameObject pickUpFirst;

    private int count;
    // Use this for initialization
    void Start() {
        // Set the count to zero 
        count = 0;

        // Run the SetCountText function to update the UI (see below)
        SetCountText();

        restartButton.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update() {

    }

    // When this game object intersects a collider with 'is trigger' checked, 
    // store a reference to that collider in a variable named 'other'..
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("PickUpFirst"))
        {
            other.gameObject.SetActive(false);
            
            pickUpFirst.SetActive(false);

        }
        // ..and if the game object we intersect has the tag 'Pick Up' assigned to it..
        if (other.gameObject.CompareTag("PickUp") && !pickUpFirst.activeSelf)
        {
            // Make the other game object (the pick up) inactive, to make it disappear
            other.gameObject.SetActive(false);

            // Add one to the score variable 'count'
            count = count + 1;

            // Run the 'SetCountText()' function (see below)
            SetCountText();

        }
    }


    // Create a standalone function that can update the 'countText' UI and check if the required amount to win has been achieved
    void SetCountText()
    {
        // Update the text field of our 'countText' variable
        countText.text = "Pontos: " + count.ToString();

        // Check if our 'count' is equal to or exceeded maxItems
        if (count >= maxItems)
        {
            // Set the text value of our 'winText'
            winText.enabled = true;
            restartButton.gameObject.SetActive(true);
        } else
        {
            // Set the text property of our Win Text UI to an empty string, making the 'You Win' (game over message) blank
            winText.enabled = false;
        }
    }

    public void TurnOffAR()
    {
        if (VuforiaBehaviour.Instance.enabled)
        {
            VuforiaBehaviour.Instance.enabled = false;
        } else
        {
            VuforiaBehaviour.Instance.enabled = true;
        }
    }

    public void RestartButton()
    {
        //Back the start point
        this.gameObject.transform.position = Vector3.zero;

        // Set the count to zero 
        count = 0;

        // Run the SetCountText function to update the UI (see below)
        SetCountText();

        //GameObject[] W1P = GameObject.FindGameObjectsWithTag("PickUp");
 
         foreach(GameObject wi in pickUps) {
            wi.SetActive(true);
        }

        restartButton.gameObject.SetActive(false);
    }
}
