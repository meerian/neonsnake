using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Food : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject walls;
    public string color;

    public float maxDist; 
    private Color32 colorStart = new Color32(224, 224, 224, 255);
    public Color32 colorChange;

    public GameObject particle;
    public Light2D curLight;

    private void Update()
    {
        float dist = Vector3.Distance(GameManager.Instance.snake.transform.position, transform.position);
        sr.material.color = Color.Lerp(colorChange, colorStart, dist/maxDist);
        curLight.color = Color.Lerp(colorChange, colorStart, dist/maxDist);
        curLight.intensity = Mathf.Lerp(5f, 1f, dist/maxDist);
    }

    public void RandomizePosition()
    {
        Vector3 newpos;
        do
        {
            float x = Mathf.Round(Random.Range(walls.transform.position.x - 16, walls.transform.position.x + 16));
            float y = Mathf.Round(Random.Range(walls.transform.position.y - 10, walls.transform.position.y + 10));
            newpos =   new Vector3(x, y, 0.0f);        
        } while (Vector3.Distance(GameManager.Instance.snake.transform.position, newpos) < 10);
        this.transform.position = newpos;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (GameManager.Instance.correct == "text")
            {
                if (GameManager.Instance.color == color)
                {
                    particle.transform.position = transform.position;
                    particle.GetComponent<ParticleSystem>().Play();
                    StartCoroutine("StopParticles");
                    AudioManager.Instance.Play("positive");
                    GameManager.Instance.AddScore();
                    GameManager.Instance.snakecolor = color;
                    GameManager.Instance.RandomColorandPosition();
                }
                else
                {
                    AudioManager.Instance.Play("negative");
                    UIManager.Instance.GameOver();
                }                
            }
            else
            {
                if (GameManager.Instance.wordcolor == color)
                {
                    particle.transform.position = transform.position;
                    particle.GetComponent<ParticleSystem>().Play();
                    StartCoroutine("StopParticles");
                    AudioManager.Instance.Play("positive");
                    GameManager.Instance.AddScore();
                    GameManager.Instance.snakecolor = color;
                    GameManager.Instance.RandomColorandPosition();
                }
                else
                {
                    AudioManager.Instance.Play("negative");
                    UIManager.Instance.GameOver();
                }
            }
        }

        if (other.tag == "Obstacle" || other.tag == "Food")
        {
            RandomizePosition();
        }
    }

    IEnumerator StopParticles()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        particle.GetComponent<ParticleSystem>().Stop();
    }
}
