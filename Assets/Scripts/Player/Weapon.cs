using System.Collections;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera fPCamera;
    [SerializeField] ParticleSystem muzzleFlashVFX;
    [SerializeField] GameObject impactEffectVFX;
    
    [SerializeField] int impactForce = 150;
    [SerializeField] int fireRate = 10;
    [SerializeField] float nextTimeToFire;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 30f;

    public int currentAmmo;
    public int maxAmmo = 10;
    public int magazineSize;
    private int maxMagazineSize = 50;

    public float reloadTime = 2f;
    public Animator animator;
    private bool isRealoading = false;
    private bool isShooting = false;
    public bool allowedToShoot = true;

    private void OnEnable()
    {
        isRealoading = false;
        animator.SetBool("isReloading", false);
        animator.SetBool("isShooting", false);
    }
    private void Start()
    {
        currentAmmo = maxAmmo;
    }
    private void Update()
    {
        CheckAmmo();
        if(Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && currentAmmo > 0 && magazineSize >= 0 && allowedToShoot == true)
        {
            isShooting = true;
            if(isShooting == true)
            {
            //limits the number of ammo the player can shoot /sec
            nextTimeToFire = Time.time + (1f/fireRate);
            animator.SetBool("isShooting", true);
            Fire();
            }
        }
        else
        {
            animator.SetBool("isShooting", false);
        }
    }
    private void CheckAmmo()
    {
        if(currentAmmo == 0 && magazineSize == 0)
        {
            animator.SetBool("isShooting", false);
            return;
        }
        if(isRealoading)
            return;
        if(currentAmmo == 0 && magazineSize > 0 && !isRealoading)
        {
            StartCoroutine(ReloadAmmo());
        }
    }
    public void IncreaseMagazine()
    {
        if(magazineSize <= maxMagazineSize)
        {
            magazineSize+=10;
        }
        if(magazineSize > maxMagazineSize)
        {
            magazineSize = maxMagazineSize;
        }
    }
    IEnumerator ReloadAmmo()
    {
        isRealoading = true;
        animator.SetBool("isReloading", true);
        // AudioManager.instance.Play("reload");
        GameManager.GM.PlayReload();
        yield return new WaitForSeconds(reloadTime);
        animator.SetBool("isReloading", false);
        if(magazineSize >= maxAmmo)
        {
            currentAmmo = maxAmmo;
            magazineSize -= maxAmmo;
        }
        else
        {
            currentAmmo = magazineSize;
            magazineSize = 0;
        }
        isRealoading = false;
    }
    private void Fire()
    {
        muzzleFlashVFX.Play();
        //AudioManager.instance.Play("shootSound");
        GameManager.GM.PlayShoot();
        animator.SetBool("isShooting", true);
        currentAmmo--;

        RaycastHit hit;
        if (Physics.Raycast(fPCamera.transform.position, fPCamera.transform.forward, out hit, range))
        {
            //Checks if the object hit by raycast has enemyhealth
            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy == null) return;
                enemy.TakeDamage(damage);

            if(hit.rigidbody != null)
            {
                //add force to opposite direction thats why it's negative
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            //Creates muzzleFlashVFX in impact to enemy when hit
            GameObject impact = Instantiate(impactEffectVFX, hit.point, Quaternion.LookRotation(hit.normal));
            //the impact effects lands on the target hit by raycast
            impact.transform.parent = hit.transform;
            //check if I can pool this
            Destroy(impact, 5);
        }
    }
}
