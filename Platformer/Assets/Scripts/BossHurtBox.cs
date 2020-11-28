using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// HurtBox is the "weakness" area of an entity, if the player hits an enemy on such spot the enemy takes damage. This script is attached to an object
/// with a "HurtBox tag.
/// </summary>
public class BossHurtBox : MonoBehaviour
{
    public GameObject ChickenBoss;
    public GameObject mainObject;
    public int count = 0;
    private bool invincible = false;
    private SpriteRenderer bossSprite;
    //Gets call when a trigger collision happens on the game scene
    private void Start()
    {
        bossSprite = mainObject.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!invincible)
        {
            if (collision.tag == "Player")//if Player hits the weakspot then
            {
                invincible = true;
                count = count + 1;
                if (count == 5)
                {
                    mainObject.SetActive(false);
                }//Deactivate the mainObject scene object. We could destroy, but in order to still have access to such object 
                 //so we can do things like reviving it, we deactivate it instead.
                StartCoroutine(BlinkSprite());
                StartCoroutine(BossInvul());
            }
        }
    }
    IEnumerator BossInvul()
    {
        yield return new WaitForSeconds(1f);
        invincible = false;
    }
    IEnumerator BlinkSprite()
    {
        for (int i = 0; i < 8; ++i)
        {
            yield return new WaitForSeconds(.05f);

            if (bossSprite.enabled == true)
                bossSprite.enabled = false;
            else
                bossSprite.enabled = true;
        }
    }
}
