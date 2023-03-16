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
        Invoke(nameof(Desabilitar), 0.75f);
    }

    void Desabilitar()
    {
        Barrer.gameObject.SetActive(false);
    }
}