using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RifleWeapon : MonoBehaviour
{
    [SerializeField]
    int _damageDealt = 50;

    void Start()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Screen.lockCursor = false;
        }

    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Screen.lockCursor = true;
            Ray mouseRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hitInfo;

            if (Physics.Raycast(mouseRay, out hitInfo))
            {
                Health enemyHealth = hitInfo.transform.GetComponent<Health>();
                if (enemyHealth != null)
                {
                    enemyHealth.Damage(_damageDealt);
                }
            }
        }
    }
}
