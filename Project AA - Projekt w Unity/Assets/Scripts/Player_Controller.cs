using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Controller : MonoBehaviour
{
    Animator animation;
    Rigidbody2D rgBody;
    float jumpForce = 500;
    private bool dirToRight=true;
    public float HeroSpeed;
    public AudioClip jump;
    public AudioClip points;
    public AudioClip butla;

    private bool onTheGround;
    private float radius = 0.1f;
    public Transform GroundTester;
    public LayerMask LayersToTest;
    void Start()
    {
        
        animation = GetComponent<Animator>();
        GetComponent<Rigidbody2D>().freezeRotation = true;
        rgBody = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        onTheGround = Physics2D.OverlapCircle(GroundTester.position, radius, LayersToTest);
        // poruszanie sie postaci
        float HorizontalMove = Input.GetAxis("Horizontal");
        rgBody.velocity = new Vector2(HorizontalMove * HeroSpeed, rgBody.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && onTheGround)
        {
            rgBody.AddForce(new Vector2(0f, jumpForce));
            animation.SetTrigger("Jump");
            AudioSource.PlayClipAtPoint(jump, transform.position);
        }

        animation.SetFloat("Speed", Mathf.Abs(HorizontalMove));

        // odwracanie postaci w lewo
        if (HorizontalMove < 0 && dirToRight)
            Flip();
        // odwracanie postaci w prawo
        if (HorizontalMove > 0 && !dirToRight)
            Flip();
    }

    void Flip()
    {
        // funkcja do obracania postacia
        dirToRight = !dirToRight;
        Vector3 HeroScale = gameObject.transform.localScale;
        HeroScale.x *= -1;
        gameObject.transform.localScale = HeroScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch(collision.name)
        {
            case "Chest":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(points, transform.position);
                }
                break;
            case "Chest 2":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(points, transform.position);
                }
                break;

            case "Chest 3":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(points, transform.position);
                }
                break;

            case "Chest 4":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(points, transform.position);
                }
                break;

            case "Chest 5":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(points, transform.position);
                }
                break;
            case "Butelka":
                {
                    CounterController.scoreAmount += 1;
                    Destroy(collision.gameObject);
                    AudioSource.PlayClipAtPoint(butla, transform.position);
                }break;
            case "Karczma_znak":
                {
                    SceneManager.LoadScene("Historyjka2");
                }
                break;
            case "GameOver_znak":
                {
                    SceneManager.LoadScene("GameOver");
                }
                break;
        }
    }

}
