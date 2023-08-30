using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] GameObject hitEffect;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    Animator anim;

    void Start() {
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) {
            if(ammoSlot.GetAmmoCount() > 0) {
                Shoot();
            } else {
                Debug.Log("No more ammos to shoot. GLHF.");
            }
        }
    }

    private void Shoot() {
        ammoSlot.ReduceAmmo();
        muzzleFlash.Play();
        anim.SetTrigger("isShooting");
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
        if (target == null) {
            return;
        } else {
            target.DecreaseHealth(damage);
        }

    }
}
