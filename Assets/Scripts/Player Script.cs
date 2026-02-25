using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Shoot shoot;
    public float weaponCooldown;
    public int currentClip, maxClipSize = 10;

    private void Start()
    {
        currentClip = maxClipSize;
    }
    void Update()
    {
        CheckShoot();
        if (Input.GetKeyDown(KeyCode.R) && currentClip <= 1) 
        {
            StartCoroutine(ShootCooldown());
        }
    }
    public void CheckShoot() 
    {
        if (currentClip > 0)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                GameObject projectile = Instantiate(shoot.prefab);

                projectile.transform.position = transform.position;

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePos.z = 0;

                Vector3 dir = mousePos - projectile.transform.position;
                projectile.transform.up = dir;

                projectile.transform.Translate(Vector2.up * 1.5f);

                currentClip--;
            }
        }
    }
    public void Reload() 
    {
        int reloadAmount = maxClipSize - currentClip;
        currentClip += reloadAmount;
    }

    IEnumerator ShootCooldown() 
    {
        yield return new WaitForSeconds(weaponCooldown);
        Reload();
    } 

}

[System.Serializable]
public struct Shoot 
{
    public GameObject prefab;
}
