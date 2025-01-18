using UnityEngine;

public class LinearMoveLoop : MonoBehaviour {

    private Vector3 initPos;
    private Vector3 finalPos;
    public float moveSpeed = 1.0F;
    public float restTime = 3.0F;
    public float moveRange = 3.0F; 
    private float distanceMoved;
    private Vector3 moveDirection;

    void Start() {
        distanceMoved = 0;
        moveDirection = transform.forward;
        initPos = transform.position;
        finalPos = initPos + moveDirection * moveRange;
        
    }
    void Update() {
        if (distanceMoved >= moveRange) {
            Vector3 rotation = new Vector3(0, 180, 0);
            transform.Rotate(rotation);
            distanceMoved = 0;

            Vector3 temp = initPos;
            initPos = finalPos;
            finalPos = temp;
        }
        Vector3 move = moveDirection * moveSpeed * Time.deltaTime;
        if (distanceMoved + move.magnitude < moveRange) {
            transform.Translate(move);
        } else {
            transform.position = finalPos;
        }
        distanceMoved += move.magnitude;
    }
}