using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteConfig: MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody rigidBody;
    public Transform trans;

    //Foob sprites
    public Sprite sprites1; //original
    public Sprite sprites2; //
    public Sprite sprites3; //impostors 
    public Sprite sprites4; //
    public Sprite sprites5; //
    public Sprite sprites6; //
    public Sprite sprites7; //shiny original


    private void Update()
    {
        if(trans.position.x > 5)  //Teleporting at edges of the screen
        {
            Vector3 pos = new Vector3(-5f, trans.position.y, 0);
            trans.position = pos;
        }
        if (trans.position.x < -5)
        {
            Vector3 pos = new Vector3(5f, trans.position.y, 0);
            trans.position = pos;
        }
        if (trans.position.y < -5)
        {
            Vector3 pos = new Vector3(trans.position.x, 5f, 0);
            trans.position = pos;
        }
        if (trans.position.y > 5)
        {
            Vector3 pos = new Vector3(trans.position.x, -5f, 0);
            trans.position = pos;
        }
    }

    public void ChangeSprite(int changeTo)
    {
        switch (changeTo)
        {
            case 0:
                spriteRenderer.sprite = sprites1;
                break;
            case 1:
                spriteRenderer.sprite = sprites2;
                break;
            case 2:
                spriteRenderer.sprite = sprites3;
                break;
            case 3:
                spriteRenderer.sprite = sprites4;
                break;
            case 4:
                spriteRenderer.sprite = sprites5;
                break;
            case 5:
                spriteRenderer.sprite = sprites6;
                break;
            case 6:
                spriteRenderer.sprite = sprites7;
                break;
        }
    }    

    public void AddMovement(Vector3 speed)
    {
        rigidBody.AddForce(speed);
    }
   
}
