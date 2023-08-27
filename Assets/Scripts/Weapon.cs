using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            Shoot();
        }
    }

    private void Shoot() {
        muzzleFlash.Play();
        RaycastHandle();
    }

    void RaycastHandle() {
        RaycastHit hit;
        // Returns
        // bool Returns true if the ray intersects with a Collider, otherwise false.
        // Description
        // Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            ParticleBulletHitEffect(hit);

            DamageBulletHandle(hit);

        }
    }

    void ParticleBulletHitEffect(RaycastHit hit) {
        GameObject impact = Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.1f);
        
    }

    void DamageBulletHandle(RaycastHit hit) {
        EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
        if (target == null) return;
        target.DecreaseHealth(damage);

    }
}
