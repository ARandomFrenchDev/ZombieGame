using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
    }

    private void Shoot() {
        RaycastHit hit;
        // Returns
        // bool Returns true if the ray intersects with a Collider, otherwise false.
        // Description
        // Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
        Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range);
        Debug.Log(hit.collider);
    }
}
