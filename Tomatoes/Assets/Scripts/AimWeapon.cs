using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{
    public Transform aimTranform;
    public Transform playerSprite;

    public Transform bulletSpawnLocation;
    public GameObject bulletPrefab;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector3 aimDirection = (mousePosition - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        aimTranform.eulerAngles = new Vector3(0, 0, angle);

        Vector3 localScale = Vector3.one;
        Vector3 playerScale = Vector3.one;
        if (angle >  90 || angle < -90)
        {
            localScale.y = -1f;
            playerScale.x = -1f;
        }
        else
        {
            localScale.y = +1f;
            playerScale.x = +1f;
        }

        aimTranform.localScale = localScale;
        playerSprite.localScale = playerScale;

        if (Input.GetMouseButtonUp(0))
        {
            GameObject temp = Instantiate(bulletPrefab, bulletSpawnLocation.position, aimTranform.rotation);
            temp.GetComponent<Rigidbody2D>().AddForce(aimTranform.right * 1000);
        }

    }
}
