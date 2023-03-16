
using UnityEngine;

public class CoresCenario : MonoBehaviour
{
    public GameObject Barrer;
    public GameObject Player;
    void Update() {
        Debug.DrawRay(Vector3.up, Vector3.down);
        if(Physics.Raycast(Player.transform.position, Vector3.down ,out RaycastHit hit, 1))
        {
            Barrer.GetComponent<Mov_Barrer>().enabled = true;
        }
    }
}
