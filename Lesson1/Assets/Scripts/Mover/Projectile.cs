using UnityEngine;
using System.Collections.Generic;

public class Projectile : MonoBehaviour {
    public GameObject projectilePrefab;

    private List<GameObject> Projectiles = new List<GameObject>();

    public float projectileVelocity = 1.0f;

    void Start()
    {
        InvokeRepeating("LaunchProjectile", 1.0f, 1.5f);
    }

    void LaunchProjectile() {
        GameObject bullet = (GameObject)Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Projectiles.Add(bullet);
    }

    void Update()
    {
        for(int i = 0; i < Projectiles.Count; i++) 
        {
            GameObject goBullet = Projectiles[i];

            if(goBullet != null) 
            {
                goBullet.transform.Translate(new Vector3(-1, 0) * Time.deltaTime * projectileVelocity);

                Vector3 bulletScreenPos = Camera.main.WorldToScreenPoint(goBullet.transform.position);
                if(bulletScreenPos.x <= 0)
                {
                    DestroyObject(goBullet);
                    Projectiles.Remove(goBullet);
                }
            }
        }
    }
}