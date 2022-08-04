using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mow : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Wheat wheat))
        {
            wheat.Mow();
        }
    }
}
