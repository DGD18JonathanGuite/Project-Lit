using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointSystem : MonoBehaviour
{
    public Transform[] WayPoints;

    public void Awake()
    {
        WayPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            WayPoints[i] = transform.GetChild(i);
    }
}
