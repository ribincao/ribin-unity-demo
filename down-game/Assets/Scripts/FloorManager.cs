using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorManager : MonoBehaviour
{
    [SerializeField] private GameObject[] floorPrefabs;
    // Start is called before the first frame update

    public void CreateFloor()
    {
        int r = Random.Range(0, floorPrefabs.Length);
        GameObject floor = Instantiate(floorPrefabs[r], transform);
        floor.transform.position = new Vector3(Random.Range(-15, 15), -25, 0);
    }
}
