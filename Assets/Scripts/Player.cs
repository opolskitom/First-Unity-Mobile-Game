using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Vector2 targetPos;
    private Vector2 bgTargetPos;
    private Quaternion targetRot;
    public Swipe swipeControls;
    public GameObject particleEffects;
    public GameObject background;
    public GameObject gameOver;
    public Text scoreText;
    public Text finalScore;

    public float gridDistance;
    public float bgParallax;
    public float bgSpeed;
    public float speed;
    public float rotSpeed;
    public float minHeight;
    public float maxHeight;
    public float minLength;
    public float maxLength;

    public int health = 3;
    public int score = 0;

    // Start is called before
    void Start()
    {
        targetPos = transform.position;
        bgTargetPos = background.transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Health Scene Manager
        if (health <= 0)
        {
            gameOver.SetActive(true);
            finalScore.text = score.ToString();
            Destroy(gameObject);
        }

        //Score
        scoreText.text = score.ToString();

        //Movement Update functions
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        background.transform.position = Vector2.MoveTowards(background.transform.position, bgTargetPos, bgSpeed * Time.deltaTime);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotSpeed * Time.deltaTime);

        //Up
        if (swipeControls.SwipeUp && transform.position.y < maxHeight)
        {
            //Particle Effects
            Instantiate(particleEffects, transform.position, Quaternion.identity);
            //Player Movement and Rotation
            targetPos = new Vector2(transform.position.x, transform.position.y + gridDistance);
            targetRot = Quaternion.Euler(0, 0, 0);

            //BG Movement
            bgTargetPos = new Vector2(background.transform.position.x, background.transform.position.y - bgParallax);
        }

        //Down
        if (swipeControls.SwipeDown && transform.position.y > minHeight)
        {
            Instantiate(particleEffects, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x, transform.position.y - gridDistance);
            targetRot = Quaternion.Euler(0, 0, 180);
            bgTargetPos = new Vector2(background.transform.position.x, background.transform.position.y + bgParallax);
        }

        //Right
        if (swipeControls.SwipeRight && transform.position.x < maxLength)
        {
            Instantiate(particleEffects, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x + gridDistance, transform.position.y);
            targetRot = Quaternion.Euler(0, 0, 270);
            bgTargetPos = new Vector2(background.transform.position.x- bgParallax, background.transform.position.y);
            
        }

        //Left
        if (swipeControls.SwipeLeft && transform.position.x > minLength)
        {
            Instantiate(particleEffects, transform.position, Quaternion.identity);
            targetPos = new Vector2(transform.position.x - gridDistance, transform.position.y);
            targetRot = Quaternion.Euler(0, 0, 90);
            bgTargetPos = new Vector2(background.transform.position.x + bgParallax, background.transform.position.y);
        }

    }




}
