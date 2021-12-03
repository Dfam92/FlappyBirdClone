using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private TrackSegment track;
    [SerializeField] private List<TrackSegment> trackList;
    private List<TrackSegment> nextTrack;

    private void Start()
    {
        Vector3 startTrackPos = new Vector3(track.EndPos, track.transform.position.y, transform.position.z);
        
        if ((player.transform.position.x) > track.StartPos)
        {
            Instantiate(track, startTrackPos, Quaternion.identity);
            nextTrack.Add(track);
        }
       
    }
    private void Update()
    {
       
    }
}
