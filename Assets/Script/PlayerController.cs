using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject _seaMine = null;
    [SerializeField] private float speed = 1f;
    private SceneLoader sceneLoader;
    private int _health = 50;
    public Text healthtext;
    public Text mineText;
    private int seaMine = 3;
    private Vector3 firingPoint;
    private float Xmin;
    private float Xmax;
    private float Padding = 1;
    private Camera cam;
    private AudioManger manger;
    // Start is called before the first frame update
    void Start()
    {
        healthtext.text = "HEALTH " + _health;
        sceneLoader = FindObjectOfType<SceneLoader>();
        manger = FindObjectOfType<AudioManger>();
        mineText.text = "x " + seaMine;
        Boundries();
    }

    private void Boundries()
    {
        Camera cam = Camera.main;
        Xmin = cam.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + Padding;
        Xmax = cam.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - Padding;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space) && seaMine > 0)
        {
            SeaMine();
            seaMine--;
            mineText.text = "x " + seaMine;
        }
    }

    private void Movement()
    {
        float xPos = Input.GetAxis("Horizontal");
        var deltaX = transform.position.x + xPos * speed * Time.deltaTime;
        transform.position = new Vector2(Mathf.Clamp(deltaX, Xmin, Xmax),transform.position.y);
    }
    private void SeaMine()
    {
        firingPoint = new Vector3(transform.position.x, transform.position.y, 1f);
        if (_seaMine != null)
        {
            GameObject seaMine = Instantiate(_seaMine, firingPoint, quaternion.identity);
            Rigidbody2D rd;
            rd = seaMine.GetComponent<Rigidbody2D>();
            rd.velocity = new Vector2(0f, -0.3f);
        }
        else return;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Torpedo"))
        {
            Destroy(other.gameObject);
            manger._ShipAudio();
            int dealDamage = other.GetComponent<DamageDealer>().DealDamage();
            Health(dealDamage);
        }
    }
    private void Health(int damageTaken)
    {
        _health -= damageTaken;
        healthtext.text = "HEALTH " + _health;
        if (_health <= 0)
        {
            _health = 0;
            healthtext.text = "HEALTH " + _health;
            sceneLoader.GameOver();
        }
    }
    public void SeaMineLeft(int mine)
    {
        this.seaMine += mine;
        mineText.text = "x " + seaMine;
    }
}
