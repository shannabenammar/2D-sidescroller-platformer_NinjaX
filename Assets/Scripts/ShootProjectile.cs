using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootProjectile : MonoBehaviour
{
    public GameObject crosshair;
    public GameObject player;
    public GameObject weaponPrefab;

    public float weaponSpeed = 15.0f;

    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
       Cursor.visible = false;
       crosshair.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        target = transform.GetComponentInParent<Camera>().ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z));
        crosshair.transform.position = new Vector2(target.x, target.y);
 
        Vector3 difference = target - player.transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        
        
        //rotate player object
        // player.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);

        if(Input.GetMouseButtonDown(0)) {
            // fire weapon
            float distance = difference.magnitude;
            Vector2 direction = difference / distance;
            direction.Normalize();
            
            shootWeapon(direction, rotationZ);
        }
    }
    
    void shootWeapon(Vector2 direction, float rotationZ){
        GameObject b = Instantiate(weaponPrefab) as GameObject;
        b.transform.position = player.transform.position + new Vector3(0.30f, -0.30f);
        b.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        b.GetComponent<Rigidbody2D>().velocity = direction * weaponSpeed;
    }
}
