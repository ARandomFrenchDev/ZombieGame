using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetHandle : MonoBehaviour
{
    [SerializeField] float points;
    
    public void HandlePoints() {
        Debug.Log("points");
        Destroy(gameObject);
    }

}
