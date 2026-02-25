using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public Shoot shoot;
    public float weaponCooldown;
    void Update()
    {
        CheckShoot(true);
    }
    public void CheckShoot(bool IT) 
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject projectile = Instantiate(shoot.prefab);

    projectile.transform.position = transform.position;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    mousePos.z = 0;
           
            Vector3 dir = mousePos - projectile.transform.position;
    projectile.transform.up = dir;

            projectile.transform.Translate(Vector2.up* 1.5f);

            StartCoroutine(ShootCooldown());
        }
    }

    IEnumerator ShootCooldown() 
    {
        CheckShoot(false);
        yield return new WaitForSeconds(weaponCooldown);
        CheckShoot(true);
    } 

}

[System.Serializable]
public struct Shoot 
{
    public GameObject prefab;
}
