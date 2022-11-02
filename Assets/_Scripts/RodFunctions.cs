using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class RodFunctions : MonoBehaviour
{
    public float speedBoost = 1.0f;
    public float knockback = 10.0f;
    public float cooldown = 10.0f;
    public float rotationDirection = 1.0f;
    public bool speedBoostOnCooldown = false;
    public bool switchDirectionOnCooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !speedBoostOnCooldown)
        {
            speedBoost = 5.0f;
            speedBoostOnCooldown = true;
            StartCoroutine(SpeedBoostRoutine());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !switchDirectionOnCooldown)
        {
            rotationDirection *= -1;
            switchDirectionOnCooldown = true;
            StartCoroutine(SwitchDirectionCooldownRoutine());
        }
    }

    IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(3);
        speedBoost = 1;
        StartCoroutine(SpeedBoostCooldownRoutine());
    }

    IEnumerator SpeedBoostCooldownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
         speedBoostOnCooldown = false;
    }

    IEnumerator SwitchDirectionCooldownRoutine()
    {
        yield return new WaitForSeconds(cooldown);
        switchDirectionOnCooldown = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody playerRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 knockbackPlayer = (collision.gameObject.transform.position - transform.position);
            Debug.Log("Test");
            playerRb.AddForce(knockbackPlayer * knockback, ForceMode.Impulse);
        }
    }

}
