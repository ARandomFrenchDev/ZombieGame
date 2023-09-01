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
    [SerializeField] float timeBetweenShots = 1f;

    [SerializeField] public bool canShoot = true;
    Animator anim;

    void Start() {
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && canShoot) {
            if(ammoSlot.GetAmmoCount() > 0) {
                StartCoroutine(Shoot());
            } else {
                Debug.Log("No more ammos to shoot. GLHF.");
            }
        }
    }

    // How to fix Coroutine when switching weapons 
    // 1) Setup a WaitUntil() Coroutine, with a bool assigned named "isSwitching"
    // 2) When switching, if the counter is lower than the initial counter but higher than 0, isSwitching goes to true
    // 3) When switching back on it, isSwitching goes back to false, counter takes the remaining counter and finishes the Coroutine

    IEnumerator Shoot() {
        canShoot = false;
        ammoSlot.ReduceAmmo();
        muzzleFlash.Play();
        anim.SetTrigger("isShooting");
        RaycastHandle();
        yield return new WaitForSeconds(timeBetweenShots);
        canShoot = true;
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
