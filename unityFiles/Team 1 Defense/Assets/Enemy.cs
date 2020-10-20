using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 10f; // arbitrary speed

    private Transform target;
    private int waypointIndex = 0; // waypoint target index

    void Start () {
        target = Waypoints.points[0];
    }

    void Update() {
        Vector3 dir = target.position - transform.position;
        // print(dir);
        // normalized vector * constant speed * times passed since last frame
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World); 
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) {
            GetNextWaypoint();
        }
    }

    void GetNextWaypoint() {
        if (waypointIndex >= Waypoints.points.Length - 1){
            Destroy(gameObject); // reached the end, clear this object...
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

}
