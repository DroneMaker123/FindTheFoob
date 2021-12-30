using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Camera MainCamera;

    public SpriteConfig SpriteObject;
    public SpriteConfig Created;

    private GameObject Cleaner;

    public int currentLevel = 1; // used to show the current level
    private int difficulty = 5; // used for the amount of spawn
    public int score = 0; // player score

    private bool activeTimer = false; // disables the countdown while in cutscene
    public float timeRemaining = 10; // stores the remaining play time

    public bool hasLost = false; // game over flag

    private bool hasBeenClicked = false; // to prevent mass clicking the original sprite

    public GameObject gameOver;
    public GameObject scoreHidden;
    public GameObject scoreValueHidden;
    public GameObject levelHidden;
    public GameObject levelValueHidden;
    public GameObject tryAgain;
    public GameObject exit;
    public GameObject exit2;
    public GameObject credits;

    private void Start()
    {
        gameOver.SetActive(false);
        scoreHidden.SetActive(false);
        scoreValueHidden.SetActive(false);
        levelHidden.SetActive(false);
        levelValueHidden.SetActive(false);
        tryAgain.SetActive(false);
        exit.SetActive(false);
        exit2.SetActive(true);
        credits.SetActive(false);
        LevelRedraw(difficulty, Random.Range(0,6));
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasLost)
        {
            if (Input.GetMouseButtonDown(0)) // if left button is clicked
            {
                Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition); //raycast test and check what was hit
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.transform.tag == "Impostor")
                    {
                        timeRemaining -= 3;
                        Destroy(hit.transform.gameObject);
                    }
                    if (hit.transform.tag == "Original" && !hasBeenClicked)
                    {
                        timeRemaining += 5;

                        hasBeenClicked = true;


                        foreach (GameObject Cleaner in GameObject.FindGameObjectsWithTag("Impostor")) //erasing every sprite objects
                        {
                            Destroy(Cleaner);
                        }
                        Cleaner = GameObject.FindGameObjectWithTag("Original");
                        Destroy(Cleaner, 1);
                        activeTimer = false; // disabling countdown timer
                        score += 10 + currentLevel / 4 + (int)(timeRemaining-5)/10;
                        difficulty += 2;
                        currentLevel += 1;
                        StartCoroutine(ExecuteAfterTime(2));
                    }
                }
            }

            if (activeTimer) //countdown flag
            {
                timeRemaining -= Time.deltaTime;  //TIME ENABLED
            }
            if (timeRemaining <= 0)
            {
                timeRemaining = 0; // to prevent time being lower than 0

                foreach (GameObject Cleaner in GameObject.FindGameObjectsWithTag("Impostor")) //erasing every sprite objects
                {
                    Destroy(Cleaner);
                }
                Cleaner = GameObject.FindGameObjectWithTag("Original");

                Destroy(Cleaner);
                hasLost = true; // set the game over flag
                Debug.Log("You have died");

                gameOver.SetActive(true);
                scoreHidden.SetActive(true);
                scoreValueHidden.SetActive(true);
                levelHidden.SetActive(true);
                levelValueHidden.SetActive(true);
                tryAgain.SetActive(true);
                exit.SetActive(true);
                exit2.SetActive(false);
                credits.SetActive(true);


            }
        }
    }

    void LevelRedraw(int quantity, int strategy)
    {
       
        switch(strategy)
        {
            case 0: //static grid random with different difficulty levels
                int randomOriginalx;
                int randomOriginaly;
                if (quantity < 15)
                {
                    randomOriginalx = Random.Range(0, 3);
                    randomOriginaly = Random.Range(0, 3);
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            Created = Instantiate(SpriteObject, new Vector3((-1.0f + x), (-1.0f + y), 0), Quaternion.identity);
                            if (x == randomOriginalx && y == randomOriginaly)
                            {
                                Created.transform.tag = "Original";
                                if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                                else Created.ChangeSprite(0);
                            }
                            else
                            {
                                Created.transform.tag = "Impostor";
                                int rng = Random.Range(1, 6);
                                Created.ChangeSprite(rng);
                            }
                        }
                    }
                }
                else if (quantity < 25)
                {
                    randomOriginalx = Random.Range(0, 4);
                    randomOriginaly = Random.Range(0, 4);
                    for (int x = 0; x < 4; x++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            Created = Instantiate(SpriteObject, new Vector3((-1.5f + x), (-1.5f + y), 0), Quaternion.identity);
                            if (x == randomOriginalx && y == randomOriginaly)
                            {
                                Created.transform.tag = "Original";
                                if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                                else Created.ChangeSprite(0);
                            }
                            else
                            {
                                Created.transform.tag = "Impostor";
                                int rng = Random.Range(1, 6);
                                Created.ChangeSprite(rng);
                            }
                        }
                    }
                }
                else if (quantity < 30)
                {
                    randomOriginalx = Random.Range(0, 5);
                    randomOriginaly = Random.Range(0, 5);
                    for (int x = 0; x < 5; x++)
                    {
                        for (int y = 0; y < 5; y++)
                        {
                            Created = Instantiate(SpriteObject, new Vector3((-2f + x), (-2f + y), 0), Quaternion.identity);
                            if (x == randomOriginalx && y == randomOriginaly)
                            {
                                Created.transform.tag = "Original";
                                if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                                else Created.ChangeSprite(0);
                            }
                            else
                            {
                                Created.transform.tag = "Impostor";
                                int rng = Random.Range(1, 6);
                                Created.ChangeSprite(rng);
                            }
                        }
                    }
                }
                else if (quantity < 45)
                {
                    randomOriginalx = Random.Range(0, 7);
                    randomOriginaly = Random.Range(0, 7);
                    for (int x = 0; x < 7; x++)
                    {
                        for (int y = 0; y < 7; y++)
                        {
                            Created = Instantiate(SpriteObject, new Vector3((-3f + x), (-3f + y), 0), Quaternion.identity);
                            if (x == randomOriginalx && y == randomOriginaly)
                            {
                                Created.transform.tag = "Original";
                                if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                                else Created.ChangeSprite(0);
                            }
                            else
                            {
                                Created.transform.tag = "Impostor";
                                int rng = Random.Range(1, 6);
                                Created.ChangeSprite(rng);
                            }
                        }
                    }
                }
                else
                {
                    randomOriginalx = Random.Range(0, 9);
                    randomOriginaly = Random.Range(0, 9);
                    for (int x = 0; x < 9; x++)
                    {
                        for (int y = 0; y < 9; y++)
                        {
                            Created = Instantiate(SpriteObject, new Vector3((-4f + x), (-4f + y), 0), Quaternion.identity);
                            if (x == randomOriginalx && y == randomOriginaly)
                            {
                                Created.transform.tag = "Original";
                                if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                                else Created.ChangeSprite(0);
                            }
                            else
                            {
                                Created.transform.tag = "Impostor";
                                int rng = Random.Range(1, 6);
                                Created.ChangeSprite(rng);
                            }
                        }
                    }
                }

                break;
            case 1: // Random spam with random speed and direction
                int randomOriginal = Random.Range(0, (quantity/2) - 1);
                for (int i = 0; i < quantity/2; i++)
                {
                    Created = Instantiate(SpriteObject, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                    if (i == randomOriginal)
                    {
                        Vector3 randomSpeed = new Vector3(Random.Range(-50 - quantity, 50 + quantity), Random.Range(-50 - quantity, 50 + quantity), 0);
                        Created.transform.tag = "Original";
                        if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                        else Created.ChangeSprite(0);
                        Created.AddMovement(randomSpeed);
                    }
                    else
                    {
                        Vector3 randomSpeed = new Vector3(Random.Range(-50 - quantity, 50 + quantity), Random.Range(-50 - quantity, 50 + quantity), 0);
                        Created.transform.tag = "Impostor";
                        int rng = Random.Range(1, 6);
                        Created.ChangeSprite(rng);
                        Created.AddMovement(randomSpeed);
                    }
                }
                break;
            case 2: //random spam with same speed and direction for every one without the original one
                randomOriginal = Random.Range(0, quantity - 1);
                int sign = RandomSign();
                Vector3 randomSpeed2 = new Vector3(sign * Random.Range(20 + (quantity / 2), 75 + quantity), sign * Random.Range(20 + (quantity / 2), 75 + quantity), 0);

                for (int i = 0; i < quantity; i++)
                {
                    Created = Instantiate(SpriteObject, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                    if (i == quantity-1)
                    {
                        Vector3 randomSpeed = new Vector3(sign * Random.Range(-50 - quantity, -20 - (quantity / 2)), sign * Random.Range(-50 - quantity, -20 - (quantity / 2)), 0);
                        Created.transform.tag = "Original";
                        if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                        else Created.ChangeSprite(0);
                        Created.AddMovement(randomSpeed);
                    }
                    else
                    {
                        
                        Created.transform.tag = "Impostor";
                        int rng = Random.Range(1, 6);
                        Created.ChangeSprite(rng);
                        Created.spriteRenderer.sortingOrder = 1;
                        Created.AddMovement(randomSpeed2);
                    }
                }
                break;
            case 3: //only horizontal direction, original slower
                randomOriginal = Random.Range(0, quantity - 1);
                sign = RandomSign();
                randomSpeed2 = new Vector3(sign * Random.Range(30 + quantity, 100 + (quantity * 2)), 0, 0);

                for (int i = 0; i < quantity; i++)
                {
                    Created = Instantiate(SpriteObject, new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                    if (i == quantity - 1)
                    {
                        Vector3 randomSpeed = new Vector3(randomSpeed2.x * 0.9f, 0);
                        Created.transform.tag = "Original";
                        //shiny Foob check
                        if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                        else Created.ChangeSprite(0);
                        Created.AddMovement(randomSpeed);
                    }
                    else
                    {

                        Created.transform.tag = "Impostor";
                        int rng = Random.Range(1, 6);
                        Created.ChangeSprite(rng);
                        Created.spriteRenderer.sortingOrder = 1;
                        Created.AddMovement(randomSpeed2);
                    }
                }
                break;
            case 4: //only vertical direction, original slower
                randomOriginal = Random.Range(0, quantity - 1);
                sign = RandomSign();
                randomSpeed2 = new Vector3(0, sign * Random.Range(30 + quantity, 100 + (quantity * 2)), 0);

                for (int i = 0; i < quantity; i++)
                {
                    Created = Instantiate(SpriteObject, new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-4.0f, 4.0f), 0), Quaternion.identity);
                    if (i == quantity - 1)
                    {
                        Vector3 randomSpeed = new Vector3(0, randomSpeed2.y * 0.9f, 0);
                        Created.transform.tag = "Original";
                        if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                        else Created.ChangeSprite(0);
                        Created.AddMovement(randomSpeed);
                    }
                    else
                    {

                        Created.transform.tag = "Impostor";
                        int rng = Random.Range(1, 6);
                        Created.ChangeSprite(rng);
                        Created.spriteRenderer.sortingOrder = 1;
                        Created.AddMovement(randomSpeed2);
                    }
                }
                break;
            case 5: // Random spam with random speed and direction but slow
                randomOriginal = Random.Range(0, (quantity/2) - 1);
                for (int i = 0; i < quantity/2; i++)
                {
                    Vector3 randomSpeed = new Vector3(Random.Range(-30 + (quantity / 20), 30 - (quantity / 20)), Random.Range(-30 + (quantity / 20), 30 - (quantity / 20)), 0);
                    Created = Instantiate(SpriteObject, new Vector3(Random.Range(-4.5f, 4.5f), Random.Range(-4.5f, 4.5f), 0), Quaternion.identity);
                    if (i == randomOriginal)
                    {
                        
                        Created.transform.tag = "Original";
                        if (Random.Range(0, 4096) == 0) Created.ChangeSprite(6);
                        else Created.ChangeSprite(0);
                        Created.spriteRenderer.sortingOrder = 1;
                        Created.AddMovement(randomSpeed);
                    }
                    else
                    {
                        Created.transform.tag = "Impostor";
                        int rng = Random.Range(1, 6);
                        Created.ChangeSprite(rng);
                        Created.AddMovement(randomSpeed);
                    }
                }
                break;
        }
        activeTimer = true; // enable countdown timer
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        int rng = Random.Range(0, 6);
        hasBeenClicked = false;
        LevelRedraw(difficulty, rng);

    }    
    int RandomSign()
    {
        return Random.value < .5 ? 1 : -1;
    }
}


