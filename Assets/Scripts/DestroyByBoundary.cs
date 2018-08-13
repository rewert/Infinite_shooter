using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour
{
    void OnTriggerExit(Collider other)
    {
        if (this.tag == "Enemy" && other.tag == "Enemy" || other.tag == "Boundary"){
            return;
        }
        if (this.tag == "Enemy" && other.tag == "Player" || this.tag == "Player" && other.tag == "Enemy"){
            return;
        }
        Destroy(other.gameObject);
    }
}