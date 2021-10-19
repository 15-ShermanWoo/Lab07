using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Animation thisAnimation;

    public Vector3 jump;
    public float jumpForce = 2.0f;
    Rigidbody rb;

    public GameObject ScoreCounter;
    public static int Score;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jump = new Vector3(0.0f, 2.0f, 0.0f);
        thisAnimation = GetComponent<Animation>();
        thisAnimation["Flap_Legacy"].speed = 3;
    }

    void Update()
    {

        if (gameObject.transform.position.y < 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(jump * jumpForce, ForceMode.Impulse);
                thisAnimation.Play();
            }
        }
        else if (gameObject.transform.position.y <= -4)
        {
            SceneManager.LoadScene("GameLose");
        }

        ScoreCounter.GetComponent<Text>().text = "Score:" + Score;
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Boarder"))
        {
            SceneManager.LoadScene("GameLose");
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
