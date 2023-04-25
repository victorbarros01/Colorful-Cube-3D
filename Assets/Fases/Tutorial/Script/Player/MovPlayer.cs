using System.Collections;
using UnityEngine;

public class MovPlayer : MonoBehaviour {
    
    Vector2 direction;
    Vector2 StartPosition;
    private const float speed = 300f;
    bool isMoving = false;
    int count = 1;
    public float HalfSize = 0.5f;
    public LayerMask CheckCollision;
    public int PassosTotais;
    

    
    void Update() {
        if (isMoving)return;
        #if UNITY_ANDROID
        if (Input.touchCount < 1)return;
        Touch touch = Input.GetTouch(0);
        switch (touch.phase) {

            case TouchPhase.Began:

                StartPosition = touch.position;
                break;

            case TouchPhase.Ended:
                direction = touch.position - StartPosition;
                if (!ScriptCanvas.Instance.isPaused)
                {
                Move(direction);
                Debug.Log(count++);
                }
                break;
        

        }
        #endif

        // #if UNITY_EDITOR 
        // if(Input.GetKeyDown(KeyCode.A))
        // {
        //     Test();
        //     StartCoroutine(Roll(Vector3.left));
        // }else if(Input.GetKeyDown(KeyCode.D))
        // {           
        //     StartCoroutine(Roll(Vector3.right));
        // }else if(Input.GetKeyDown(KeyCode.W))
        // {           
        //     StartCoroutine(Roll(Vector3.forward));
        // }else if(Input.GetKeyDown(KeyCode.S))
        // {           
        //     StartCoroutine(Roll(Vector3.back));
        // }
        // #endif
        
        
    }
    
    public void Test()
    {
        Debug.Log("TEste");
    }
    
    private void Move(Vector2 direction) {

        if (direction.magnitude < 100f)return;

        Vector2 normalizedDirection = direction.normalized;
        float Rotation = Mathf.Deg2Rad * 45f;
        normalizedDirection = new Vector2(
                normalizedDirection.x * Mathf.Cos(Rotation) - normalizedDirection.y * Mathf.Sin(Rotation),
                normalizedDirection.x * Mathf.Sin(Rotation) + normalizedDirection.y * Mathf.Cos(Rotation)
        );

        if (Mathf.Abs(normalizedDirection.x) > Mathf.Abs(normalizedDirection.y)) {
            if (normalizedDirection.x > 0) {
                if (!Physics.Raycast(transform.position, Vector3.right, out RaycastHit hit, 3f, CheckCollision.value))
                    StartCoroutine(Roll(Vector3.right));
                    --ScriptCanvas.Instance.contaPassos.value;
                    ScriptCanvas.Instance.UpdateStar(PassosTotais);
                    PassosTotais--;
            } else {
                if (!Physics.Raycast(transform.position, Vector3.left, out RaycastHit hit, 3f, CheckCollision.value)) {
                    StartCoroutine(Roll(Vector3.left));
                    --ScriptCanvas.Instance.contaPassos.value;
                    ScriptCanvas.Instance.UpdateStar(PassosTotais);
                    PassosTotais--;
                }
            }
        } else {
            if (normalizedDirection.y > 0) {
                if (!Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 3f, CheckCollision.value))
                    StartCoroutine(Roll(Vector3.forward));
                    --ScriptCanvas.Instance.contaPassos.value;
                    ScriptCanvas.Instance.UpdateStar(PassosTotais);
                    PassosTotais--;
            } else {
                if (!Physics.Raycast(transform.position, Vector3.back, out RaycastHit hit, 3f, CheckCollision.value))
                    StartCoroutine(Roll(Vector3.back));
                    --ScriptCanvas.Instance.contaPassos.value;
                    ScriptCanvas.Instance.UpdateStar(PassosTotais);
                    PassosTotais--;
            }
        }


    }

    IEnumerator Roll(Vector3 direction) {
        isMoving = true;

        float remainingAngle = 90f;
        Vector3 rotationCenter = transform.position + direction * HalfSize + Vector3.down * HalfSize;
        Vector3 rotationAxis = Vector3.Cross(Vector3.up, direction);

        while (remainingAngle > 0f) {
            float rotationAngle = Mathf.Min(Time.deltaTime * speed, remainingAngle);
            transform.RotateAround(rotationCenter, rotationAxis, rotationAngle);
            remainingAngle -= rotationAngle;

            yield return null;
        }

        isMoving = false;
    }
    
}




