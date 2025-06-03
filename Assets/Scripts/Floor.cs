using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Floor : MonoBehaviour
{
    [SerializeField] Collider2D floorCollider;
    [SerializeField] bool hasBirds = true;
    [SerializeField] private GameObject bird;
    [SerializeField] private Transform[] birdSpawns;

    private bool activated = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!activated && hasBirds)
        {
            Instantiate(bird, birdSpawns[Random.Range(0,8)].position, Quaternion.identity);
            activated = true;
        }
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        var gen = FindFirstObjectByType(typeof(FloorGenerator));
        gen.GetComponent<FloorGenerator>().GenerateFloor();
    }
    
}
