using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class SnakeController : MonoBehaviour
{
    private Vector2 direction = Vector2.right;
    private List<GameObject> segments = new List<GameObject>();
    private bool growFlag = false;
    private Vector2 movingDirection = Vector2.right; 

    public GameObject segmentPrefab;
    public GameObject maincam;
    public GameObject walls;

    public SpriteRenderer sr;
    public int initialSize;
    public Sprite orange;
    public Sprite green;
    public Sprite blue;
    public Sprite pink;
    public string color;
    public Light2D curLight;
    private Color32 greenColor = new Color32(0, 180, 0, 255);
    private Color32 orangeColor = new Color32(255, 128, 0, 255);
    private Color32 blueColor = new Color32(0, 128, 255, 255);
    private Color32 pinkColor = new Color32(255, 75, 255, 255);

    private void Start()
    {
        ChangeColor();
        segments.Add(gameObject);
        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
    }

    private void Update()
    {
        if (
            movingDirection != Vector2.down
            && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        )
        {
            direction = Vector2.up;
        }
        else if (
            movingDirection != Vector2.up
            && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        )
        {
            direction = Vector2.down;
        }
        else if (
            movingDirection != Vector2.right
            && (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        )
        {
            direction = Vector2.left;
        }
        else if (
            movingDirection != Vector2.left
            && (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        )
        {
            direction = Vector2.right;
        }
    }

    private void FixedUpdate()
    {
        movingDirection = direction;
        if (growFlag)
        {
            Grow();
            growFlag = false;
        }
        else
        {
            for (int i = segments.Count - 1; i > 0; i--)
            {
                segments[i].GetComponent<SegmentController>().NextMove(segments[i - 1]);
            }
        }
        this.transform.position = new Vector3(
            Mathf.Round(this.transform.position.x * 10f) / 10f + direction.x,
            Mathf.Round(this.transform.position.y * 10f) / 10f + direction.y,
            0.0f
        );
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Food")
        {
            CameraController.Instance.ShakeCamera(25f, 0.2f);
            growFlag = true;
        }
        else if (other.tag == "Obstacle")
        {
            AudioManager.Instance.Play("negative");
            CameraController.Instance.ShakeCamera(25f, 0.2f);
            if (GameManager.Instance.isStarted)
            {
                UIManager.Instance.GameOver();
            }
            else
            {
                ResetState();
            }
        }
    }

    public void ResetState()
    {
        transform.position = Vector3.zero;
        for (int i = segments.Count - 1; i > 0; i--)
        {
            Destroy(segments[i]);
        }
        segments.Clear();
        segments.Add(gameObject);

        for (int i = 1; i < this.initialSize; i++)
        {
            segments.Add(Instantiate(segmentPrefab));
        }
        direction = Vector2.right;
    }

    public void ChangeColor()
    {
        color = GameManager.Instance.snakecolor;
        switch (color)
        {
            case "green":
                sr.sprite = green;
                curLight.color = greenColor;
                return;
            case "orange":
                sr.sprite = orange;
                curLight.color = orangeColor;
                return;
            case "blue":
                sr.sprite = blue;
                curLight.color = blueColor;
                return;
            case "pink":
                sr.sprite = pink;
                curLight.color = pinkColor;
                return;
        }
    }

    private void Grow()
    {
        GameObject segment = Instantiate(segmentPrefab);
        segment.transform.position = transform.position;
        segments.Insert(1, segment);
    }
}
