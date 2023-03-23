using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mov_Barrer : MonoBehaviour
{
    public GameObject Barrer;
    public Vector3 dir;
    public float speed;
    // Update is called once per frame
    void Update()
    {
            transform.position += dir * speed * Time.deltaTime;
            Invoke(nameof(Desativar), 0.75f);
    }

    void Desativar()
    {
        Destroy(Barrer);
    }

}