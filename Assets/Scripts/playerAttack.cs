using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class playerAttack : MonoBehaviour
{
    [SerializeField] private bool isFiring = false;
    //[SerializeField] private float base_atk = 1f;
    [SerializeField] private float bullet_speed = 20f;
    [SerializeField] private float bullet_cooldown = 0.1f;

    //private bool isSlashing = false;
    //[SerializeField] private float slash_atk = 150f;
    [SerializeField] private float slash_area = 1.5f;
    [SerializeField] private float slash_cooldown = 0.1f;
    private float time_bullet = 0f;
    private float time_slash = 0f;
    [SerializeField] private Transform fire_point_1;
    [SerializeField] private Transform player;
    [SerializeField] private GameObject bullet_prefab;
    void Start()
    {
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.J))
        {
            isFiring = true;
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            isFiring = false;
        }

        time_slash += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.K) && time_slash >= slash_cooldown)
        {
            Slash();
            time_slash = 0f;
        }

        time_bullet += Time.deltaTime;
        if (isFiring && time_bullet >= bullet_cooldown)
        {
            Shoot();
            time_bullet = 0f;
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bullet_prefab, fire_point_1.position, fire_point_1.rotation);
        Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
        rbBullet.AddForce(fire_point_1.up * bullet_speed, ForceMode2D.Impulse);
    }
    void Slash()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(player.position, slash_area);
        if(cols != null)
        {
            foreach(Collider2D col in cols)
            {
                Debug.Log(col.gameObject.name);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(player.position, slash_area);
    }
}
