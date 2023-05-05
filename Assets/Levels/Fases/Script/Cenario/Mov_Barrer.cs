using UnityEngine;

public class Mov_Barrer : MonoBehaviour
{
    public GameObject Barrer;
    
    void Update()
    {
            transform.position += Vector3.down * 2f * Time.deltaTime;
            Invoke(nameof(Desativar), 0.75f);
    }

    void Desativar()
    {
        Destroy(Barrer);
    }

}