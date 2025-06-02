using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class Floor : MonoBehaviour
{
    [SerializeField] Collider2D floorCollider;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        print("hit");
        var gen = FindFirstObjectByType(typeof(FloorGenerator));
        gen.GetComponent<FloorGenerator>().GenerateFloor();
    }
    
}
