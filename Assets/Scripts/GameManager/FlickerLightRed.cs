using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerLightRed : MonoBehaviour
{
    // animate the game object from -1 to +1 and back
    public float minimum = 0.0f;
    public float maximum = 10f;
    public float speed = 0.5f;

    // starting value for the Lerp
    static float t = 0.0f;

    void Update() {
        // choper la lumière
        // en x secondes, on la passe d'une valuer A à valeur B 
        // puis on retourne de valeur B à valeur A 

        GetComponent<Light>().intensity = Mathf.Lerp(minimum, maximum, t);

        // .. and increase the t interpolater
        t += speed * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.0f;
        }
    }
}
