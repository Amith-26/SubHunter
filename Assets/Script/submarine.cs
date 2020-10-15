using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class submarine : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab = null;
    [SerializeField] private float firingIntervals = 5f;
    [SerializeField] private float speed = 0.1f;
    private AudioManger manger;
    private bool isMovingRigth = true;
    private Vector3 vesselSPeed;
    private Score _score;
    public GameObject boxPrefab;
    private SubmarineSpawner _submarine;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireTorpedo());
        vesselSPeed = new Vector3(speed, 0f) * Time.deltaTime;
        _score = FindObjectOfType<Score>();
        _submarine = FindObjectOfType<SubmarineSpawner>();
        _submarine.SubmarineCounter();
        manger = FindObjectOfType<AudioManger>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        AutoPilot();
    }

    private void AutoPilot()
    {
        if (isMovingRigth)
        {
            transform.position += vesselSPeed;
        }
        else { transform.position += -vesselSPeed; }
    }

    IEnumerator FireTorpedo()
    {
        while (true)
        {
            yield return new WaitForSeconds(firingIntervals);
            Fire();
        }
    }
    private void Fire()
    {
        if (bulletPrefab != null)
        {
            Quaternion rotation = Quaternion.Euler(0f, 0f, -90f);
            GameObject torpedo = Instantiate(bulletPrefab, transform.position, rotation);
            Rigidbody2D torpedoRigibody;
            torpedoRigibody = torpedo.GetComponent<Rigidbody2D>();
            torpedoRigibody.velocity = new Vector2(0f, 1f);
            Destroy(torpedo.gameObject, 10f);
        }
        else return;
    }
    private void Flip()
    {
        isMovingRigth = !isMovingRigth;
        Vector3 newDir = transform.localScale;
        newDir.x *= -1;
        transform.localScale = newDir;
    }
    private void Movement()
    {
        if (transform.position.x > 11 && isMovingRigth == true)
        {
            Flip();
        }
        else if (transform.position.x < -11 && isMovingRigth == false)
        {
            Flip();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Mine"))
        {
            Destroy(other.gameObject);
            _score._Score(5);
            Box();
            _submarine.SubmarineDecrement();
            manger._SubmarineSound();
            Destroy(this.gameObject);
        }
    }
    private void Box()
    {
        GameObject box = Instantiate(boxPrefab, transform.position, Quaternion.identity);
        Rigidbody2D rd;
        rd = box.GetComponent<Rigidbody2D>();
        rd.velocity = new Vector2(0f, 0.1f);
    }
}
