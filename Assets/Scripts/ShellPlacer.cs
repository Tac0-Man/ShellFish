using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

public class ShellPlacer : MonoBehaviour
{
    [SerializeField] private List<GameObject> Shells = new List<GameObject>();
    [SerializeField] private int shellCount = 100;
    [SerializeField] private GameObject BottomLeft;
    [SerializeField] private GameObject TopRight;
    private List<Vector2> Pionts = new List<Vector2>();

  
    void Start()
    {
        generatePoints();
        // spawn prefab
        // ga over lijst en kies random prefab uit shells
    }

    public void generatePoints()
    {
        for(int i = 0; i< shellCount; i++)
        {
            Vector2 point = Vector2.zero;
            //point.x = random - bl.x tr.x

            Pionts.Add(point);
        } 
        
    }


   
    void Update()
    {
        
    }
}
