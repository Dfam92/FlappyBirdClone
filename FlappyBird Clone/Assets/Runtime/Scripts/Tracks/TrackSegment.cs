using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackSegment : MonoBehaviour
{
    [SerializeField] private PlayerControl player;
    [SerializeField] private float endPos;
    [SerializeField] private float startPos;

    public float EndPos { get => endPos; private set => endPos = value; }
    public float StartPos { get => startPos; private set => startPos = value; }
}
