using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleFootsteps : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip metalClip;
    [SerializeField] AudioClip grassClip;
    [SerializeField] AudioClip brickClip;
    [SerializeField] AudioClip woodClip;
    public void FootstepsCases() {
			audioSource.volume = PlayerPrefs.GetFloat("sfxVolume");
			audioSource.pitch = Random.Range(0.7f, 1f);
			RaycastHit hit;
			// Returns
			// bool Returns true if the ray intersects with a Collider, otherwise false.
			// Description
			// Casts a ray, from point origin, in direction direction, of length maxDistance, against all colliders in the Scene.
			if (Physics.Raycast(transform.position, transform.up * -1, out hit, 2f))
			{
				if(hit.transform.tag == "Grass") {
					audioSource.PlayOneShot(grassClip);
				} else if(hit.transform.tag == "Brick") {
					audioSource.PlayOneShot(brickClip);
				} else if(hit.transform.tag == "Wood") {
					audioSource.PlayOneShot(woodClip);
				}else if(hit.transform.tag == "Metal") {
					audioSource.PlayOneShot(metalClip);
				}

			}
    }
}
