using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Events; 

public class BeatManager : MonoBehaviour
{
    [SerializeField] private float _bpm;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private Intervals[] _intervals;

    private void Update()
    {
        foreach (Intervals interval in _intervals)
        {
            float sampledTime = (_audioSource.timeSamples / (_audioSource.clip.frequency * interval.GetIntervalLength(_bpm))); // guess the time that we are currently elapsed in intervals in beats 
            interval.CheckForNewInterval(sampledTime);

        }
    }
}

[System.Serializable]
public class Intervals
{
    [SerializeField] private float _steps;
    [SerializeField] private UnityEvent _trigger;
    private int _lastInterval; 

    public float GetIntervalLength(float bpm) // take in bpm
    {
        return 60f / (bpm * _steps); // 60 seconds in a minute to find how many beat you are in a second
    }

    public void CheckForNewInterval (float interval) // check if we passe an another interval with different bpm 
    {
        if (Mathf.FloorToInt(interval) != _lastInterval)
        {
            _lastInterval = Mathf.FloorToInt(interval);
            _trigger.Invoke(); 
        }   
    }
}
