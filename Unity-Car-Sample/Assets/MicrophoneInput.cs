using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]
public class MicrophoneInput : MonoBehaviour
{
    public float sensitivity = 100;
    public float loudness = 0;
    AudioSource audio;
    public Text text;

    void Start()
    {
        audio = GetComponent<AudioSource>();

        //add the rest of the code like this
        audio.clip = Microphone.Start(null, true, 10, 44100);
        audio.loop = true;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audio.Play();

        //Do not Mute the audio Source.
    }

    void Update()
    {
        loudness = GetAveragedVolume() * sensitivity;
    }

    float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audio.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        return a / 256;
    }

    private void FixedUpdate()
    {
        if (loudness > 1)
        {
            text.text = "Blow: " + loudness;
        } else
        {
            text.text = "Blow - ";
        }
    }
}