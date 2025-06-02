using System.Collections.Generic;
using UnityEngine;

public class FloorGenerator : MonoBehaviour
{
    [SerializeField] Stack<GameObject> floorObjects = new Stack<GameObject>();
    [SerializeField] GameObject[] initFloors = new GameObject[4];
    [SerializeField] GameObject floorPrefab;
    [SerializeField] float placementDifference = 9f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            floorObjects.Push(initFloors[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateFloor()
    {
        var currentFloor = floorObjects.Peek();
        Vector3 floorPosition = new Vector3(currentFloor.transform.position.x + placementDifference, 
            currentFloor.transform.position.y, currentFloor.transform.position.z);
        GameObject floorObject = Instantiate(floorPrefab, floorPosition, Quaternion.identity);
        floorObjects.Push(floorObject);
    }
}
