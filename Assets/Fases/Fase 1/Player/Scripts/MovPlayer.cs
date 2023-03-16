using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPlayer : MonoBehaviour
{

    //public GameObject[] Lados = new GameObject[6];
    Vector2 direction;
    Vector2 StartPosition;
    public float speed = 300f;
    bool isMoving = false;
    public float HalfSize = 0.5f;

    void Update() {

        if (isMoving)return;
        if (Input.touchCount < 1)return;
        Touch touch = Input.GetTouch(0);
        switch (touch.phase) {

            case TouchPhase.Began:
                StartPosition = touch.position;
            break;

            case TouchPhase.Ended:
                direction = touch.position - StartPosition;
                Move(direction);
            break;


        }


    }

    void Move(Vector2 direction)
    {

        if(direction.magnitude < 100f)return;

            Vector2 normalizedDirection = direction.normalized;
            float Rotation = Mathf.Deg2Rad * 45f;
            normalizedDirection = new Vector2(
                    normalizedDirection.x * Mathf.Cos(Rotation) - normalizedDirection.y * Mathf.Sin(Rotation),
                    normalizedDirection.x * Mathf.Sin(Rotation) + normalizedDirection.y * Mathf.Cos(Rotation)
            );

            if (Mathf.Abs(normalizedDirection.x) > Mathf.Abs(normalizedDirection.y)) {
                if (normalizedDirection.x > 0) {
                    if (!Physics.Raycast(transform.position, Vector3.right, out RaycastHit hit, 3f))
                        StartCoroutine(Roll(Vector3.right));
                } else {
                    if (!Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, 3f))
                        StartCoroutine(Roll(Vector3.left));
                }
            } else {
                if (normalizedDirection.y > 0) {
                    if (!Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 3f))
                        StartCoroutine(Roll(Vector3.forward));
                } else {
                    if (!Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 3f))
                        StartCoroutine(Roll(Vector3.back));

                }
            }




    }

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        float remainingAngle = 90f;
        Vector3 rotationCenter = transform.position + direction * HalfSize + Vector3.down * HalfSize;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while(remainingAngle > 0f) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;

            yield return null;
        }

        isMoving = false;
    }


}
