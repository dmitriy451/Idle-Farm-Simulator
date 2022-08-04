using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowTransition : PlayerTransition
{
    public override void Enable()
    {
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent(out Wheat wheat))
        {
            if (wheat.Matured)
            {
                NeedTransit = true;
            }
        }
    }
}
