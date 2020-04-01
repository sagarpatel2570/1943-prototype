using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class PathCreator : ScriptableObject
{
    public List<PathInfo> paths;
    public bool debugPath;

  
}

[System.Serializable]
public class PathInfo
{
    public string name;
    public List<Vector3> wayPoints;
    public PathType pathType;

    public PathInfo(List<Vector3> wayPoints, PathType pathType, int waitTimeBetweenWaypoints)
    {
        this.wayPoints = wayPoints;
        this.pathType = pathType;
    }
}
