using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelCreator : MonoBehaviour
{
    public GameObject startLocation;
    public GameObject[] locations;
    public GameObject bottomLocation;
    
    public uint levelSectors = 5;
    // Start is called before the first frame update
    void Start()
    {
        CreateLevel();
    }

    private void CreateLevel()
    {
        var start = Instantiate(startLocation, transform.position, Quaternion.identity);
        var endPosition = start.transform.Find("EndPoint").transform.position;
        for (var i = 0; i < levelSectors; i++)
        {
            var randomLocationIndex = Random.Range(0, locations.Length);
            var location = Instantiate(locations[randomLocationIndex], endPosition, Quaternion.identity);
            endPosition += locations[randomLocationIndex].transform.Find("EndPoint").transform.position;
        }

        var bottom = Instantiate(bottomLocation, endPosition, Quaternion.identity);
    }
}
