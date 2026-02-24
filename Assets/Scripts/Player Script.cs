using System.Collections;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Shoot shoot;
    void Update()
    {
        CheckShoot();
    }
    public void CheckShoot() 
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
        }
    }
}

[System.Serializable]
public struct Shoot 
{
    public GameObject prefab;
}
