using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class App : MonoBehaviour
{
    public static GameObject map;
    public static int Level = 0;
    private void Awake()
    {
        map = GameObject.FindGameObjectWithTag("Map");
    }
    void Start()
    {
      
    }

   

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Exit()
    {
        Application.Quit();
    }
}
