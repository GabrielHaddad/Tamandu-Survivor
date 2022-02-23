using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBehavior : MonoBehaviour
{
    [SerializeField] GameObject laserPrefab;
    //bool canPlayLaser;

    void Start()
    {
        
    }

    void Update()
    {
        ProcessFiring();
    }

    void ProcessFiring()
    {
        if (Input.GetButton("Fire1"))
        {
            ModifyLasers(true);

            // if (canPlayLaser)
            // {
            //     StartCoroutine(PlayLaserSFX());
            // }
        }
        else
        {
            ModifyLasers(false);
        }
    }

    // IEnumerator PlayLaserSFX()
    // {
    //     canPlayLaser = false;
    //     //audioPlayer.PlayLaserSound();

    //     yield return new WaitForSeconds(delayLaserSound);

    //     canPlayLaser = true;
    // }

    public void ModifyLasers(bool laserState)
    {
        var emissionModule = laserPrefab.GetComponent<ParticleSystem>().emission;
        emissionModule.enabled = laserState;
    }
}
