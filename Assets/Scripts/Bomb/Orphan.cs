using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orphan : MonoBehaviour
{
    public void NoMoreParent()
    {
        this.transform.SetParent(null);
    }
}
