using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleGenerator : MonoBehaviour
{

    [SerializeField] private List<Obstacle> obstacleList;
    [SerializeField] private TrackSegment track;

    // Start is called before the first frame update
    void Start()
    {
        var index = Random.Range(0, obstacleList.Count);
        Instantiate(obstacleList[index],track.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
