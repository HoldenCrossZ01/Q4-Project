using System;
using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static implicit operator SceneController(FinishPoint v)
    {
        throw new NotImplementedException();
    }
}
