using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LightFlickering : MonoBehaviour {
    private Light light;

    private float newBrightness;
    
    void Start() {
        light = GetComponent< Light >( );
        StartCoroutine( flickering( ) );
    }

    private void Update( ) {
        newBrightness = Mathf.Lerp( light.intensity , newBrightness , .5f );
        light.intensity = newBrightness;
    }

    private IEnumerator flickering( ) {
        do {
            newBrightness = Random.Range( 1333333 , 333333 );
            yield return new WaitForSeconds( .1f );
        } while ( true );
    }
}
