using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGenerator : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private TrackSegment startTrack;
    [SerializeField] private List<TrackSegment> trackList;
    [SerializeField] private List<TrackSegment> nextTrack;
    [SerializeField] private int numberOfSpawnedTracks;
    private bool newTrack;

    private void Start()
    {
       
        if ((player.transform.position.x) > trackList[trackList.Count - 1].StartPos)
        {
            Instantiate(trackList[trackList.Count - 1], startTrack.transform.position, Quaternion.identity);
            nextTrack.Add(trackList[trackList.Count - 1]);
            newTrack = true;
        }

    }
    private void Update()
    {
        if(newTrack)
        {
            SpawnTracks();
            newTrack = false;
        }
    }

    private void SpawnTracks()
    {
        var newNextTrack = nextTrack[nextTrack.Count - 1];
        for (int i = 1; i < numberOfSpawnedTracks; i++)
        {
            Vector3 previousTrackPos = new Vector3(newNextTrack.EndPos , nextTrack[i].transform.position.y, nextTrack[i].transform.position.z);
            Instantiate(newNextTrack,previousTrackPos * i, Quaternion.identity);
            nextTrack.Add(newNextTrack);
        }
    }
}
