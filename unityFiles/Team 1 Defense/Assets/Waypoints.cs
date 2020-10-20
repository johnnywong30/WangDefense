using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;

    void Awake() {
        points = new Transform[transform.childCount]; // number of children in Waypoints
        for (int i = 0; i < points.Length; i++) {
            points[i] = transform.GetChild(i);
        }
        

    }

}
