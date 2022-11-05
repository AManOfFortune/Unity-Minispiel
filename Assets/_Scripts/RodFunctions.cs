using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class RodFunctions : MonoBehaviour
{
    public float speedBoost = 1.0f;
    public float knockbackStrength = 10.0f;
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
        //check what Key was input and if the corresponding ability is on cooldown.
        if (Input.GetKeyDown(KeyCode.UpArrow) && !speedBoostOnCooldown)
        {
            //set speed multiplyer to a higher float. 
            speedBoost = 5.0f;
            //set boolean to true to put ability on cooldown
            speedBoostOnCooldown = true;
            StartCoroutine(SpeedBoostRoutine());
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && !switchDirectionOnCooldown)
        {
            //multiply the current speed by -1 to switch directions
            rotationDirection *= -1;
            //set boolean to true to put ability on cooldown
            switchDirectionOnCooldown = true;
            StartCoroutine(SwitchDirectionCooldownRoutine());
        }
    }

    //Coroutine to let the speedBoost wear off after 3seconds and then start the ability cooldown timer.
    IEnumerator SpeedBoostRoutine()
    {
        yield return new WaitForSeconds(3);
        speedBoost = 1;
        StartCoroutine(SpeedBoostCooldownRoutine());
    }

    //Cooldown Coroutines that prevents the user from spamming the abilities
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

    //if the moving rod collides with a player a force is added to the player to make him fly away
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get the playerController component of hit player
            PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
            // Calculate the knockback direction
            Vector3 knockbackPlayer = (collision.gameObject.transform.position - transform.position);

            // Add impact to the player
            playerController.AddImpact(knockbackPlayer, knockbackStrength);
        }
    }

}
