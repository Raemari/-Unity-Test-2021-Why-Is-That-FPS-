using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject hitEffectVFX;
    [SerializeField] Ammo ammoSlot;
    [SerializeField] AmmoType ammoType;

    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;
    [SerializeField] float delayForShoot = 2f;
    [SerializeField] TextMeshProUGUI ammoText;
    private bool canShoot = true;

    private void OnEnable()
    {
        canShoot = true;
    }
    
    void Update()
    {
        DisplayAmmo();
        if(Input.GetMouseButtonDown(0) && canShoot == true)
        {
            StartCoroutine(Shoot());
        }
    }
    private void DisplayAmmo()
    {
        int currentAmmo = ammoSlot.GetCurrentAmmo(ammoType);
        ammoText.text = currentAmmo.ToString();
    }

    IEnumerator Shoot()
    {
        canShoot = false;
        if (ammoSlot.GetCurrentAmmo(ammoType) > 0)
        {
            PlayMuzzleFlash();
            ProcessRayCast();
            ammoSlot.ReduceCurrentAmmo(ammoType);
        }
        yield return new WaitForSeconds(delayForShoot);
        canShoot = true;
    }

    private void PlayMuzzleFlash()
    {
        muzzleFlashVFX.Play();
    }

    private void ProcessRayCast()
    {
        RaycastHit hit;
        if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, range))
        {
            CreateHitImpact(hit);
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if (target == null) return;
            target.TakeDamage(damage);
        }
        else
        {
            return;
        }
    }

    private void CreateHitImpact(RaycastHit hit)
    {
        GameObject impact = Instantiate(hitEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, .1f);
    }
}
