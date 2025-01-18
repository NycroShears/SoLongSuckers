using UnityEngine;

public class Detector : MonoBehaviour {

    public Transform target; // target object to be detected
    public Vector3 faceDirection; // direction that the detector faces
    public float viewAngle = 20.0F; // furthest angle that the detector can see in either direction from its forward vector
                                    // (the total fov angle is double this value) 
    public float viewDist = 5.0F; // maximum distance the detector can see
    private bool inView = false; // keeps track of if the target is in view or not

    void Start() {
        
        faceDirection = transform.forward;
    }

    // Update is called once per frame
    void Update() {
        Vector3 toTarget = target.position - transform.position;
        float distToTarget = toTarget.magnitude;
        float angleToTarget = Vector3.Angle(toTarget, faceDirection);



        // check distance and angles are within range
        if (distToTarget <= viewDist && angleToTarget <= viewAngle) { 
            // check if target moved to "in view"
            if (!inView) {
                inViewUpdate();
                inView = true;
            }
        }

        // check if target moved to "out of view"
        else if (inView) {
            outOfViewUpdate();
            inView = false;
        }
    }


    void inViewUpdate() {
        Debug.Log("In view");
    }

    void outOfViewUpdate() {
        Debug.Log("Out of view");
    }



    // to see viewing range in scene editor
    void OnDrawGizmos() {
    

    
        Vector3 leftLimit = Quaternion.Euler(0, -viewAngle, 0) * faceDirection * viewDist;
        Vector3 rightLimit = Quaternion.Euler(0, viewAngle, 0) * faceDirection * viewDist;

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, transform.position + leftLimit);
        Gizmos.DrawLine(transform.position, transform.position + rightLimit);
    }
}
