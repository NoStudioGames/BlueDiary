using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantSystem : MonoBehaviour
{
    public int age;
    public GameObject[] versions;
    public SpriteRenderer[] versionsSprite;
    public Animator animator;
    public float health;
    public float maxhealth;

    void Start()
    {
        
    }

    void Update()
    {

    }

    public void GrowUp()
    {
        age++;
        health = 0;
        gameObject.GetComponent<SpriteRenderer>().sprite = versionsSprite[age].sprite;
        animator.SetInteger("age", age);
    }
    public void Water()
    {
        health += 10;
        if(health >= maxhealth)
        {
            GrowUp();
        }
    }
}
