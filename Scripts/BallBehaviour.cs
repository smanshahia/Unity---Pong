using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{

    public float xspeed;
    public float yspeed;
    public Camera cam;
    public Transform p1;
    public Transform p2;
    public AudioSource p1Hit;
    public AudioSource p2Hit;

    private void Start()
    {
        xspeed = (Random.Range(0, 2) == 0) ? -xspeed : xspeed;
        yspeed = (Random.Range(0, 2) == 0) ? -yspeed : yspeed;
    }

    void Update()
    {
        if (GameManager.playable == true)
        {
            if ((transform.position.x >= (p1.transform.position.x - 0.25f) && transform.position.x <= (p1.transform.position.x + 0.25f)) && (transform.position.y < (p1.transform.position.y + p1.transform.localScale.y / 2) && transform.position.y > (p1.transform.position.y - p1.transform.localScale.y / 2)))
            {
                p1Hit.Play();
                transform.position = new Vector2(p1.transform.position.x - 0.25f, transform.position.y);
                xspeed = -xspeed;
            }
            if ((transform.position.x >= (p2.transform.position.x - 0.25f) && transform.position.x <= (p2.transform.position.x + 0.25f)) && (transform.position.y < (p2.transform.position.y + p2.transform.localScale.y / 2) && transform.position.y > (p2.transform.position.y - p2.transform.localScale.y / 2)))
            {
                p2Hit.Play();
                transform.position = new Vector2(p2.transform.position.x + 0.25f, transform.position.y);
                xspeed = -xspeed;
            }
            if (transform.position.y < -(cam.orthographicSize * Screen.width / Screen.height) / 2)
            {
                transform.position = new Vector2(transform.position.x, -(cam.orthographicSize * Screen.width / Screen.height) / 2);
                yspeed = -yspeed;
            }
            if (transform.position.y > (cam.orthographicSize * Screen.width / Screen.height) / 2)
            {
                transform.position = new Vector2(transform.position.x, (cam.orthographicSize * Screen.width / Screen.height) / 2);
                yspeed = -yspeed;
            }
            transform.position = new Vector2(transform.position.x + xspeed * Time.deltaTime, transform.position.y + yspeed * Time.deltaTime);
        }
    }
}
