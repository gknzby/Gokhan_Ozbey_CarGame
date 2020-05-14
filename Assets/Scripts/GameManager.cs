using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject botCarPrefab;
    public List<GameObject> startPoints;
    public List<GameObject> endPoints;
    public Text timerTxt;
    public Text leftRightTxt;

    List<GameObject> botCars;
    List<Vector2> locations;
    List<Quaternion> rotations;

    public int currentLevel;
    float recordTime = 0;
    int turnCounter = 0;
    int carCount;
    bool playing = false;
    float timer = 0;
    float oldTimer = 0;

    public LayerMask exitMask;
    public CarMove carMove;
    
    void Start()
    {
        botCars = new List<GameObject>();
        transform.position = startPoints[0].transform.position;
        locations = new List<Vector2>();
        rotations = new List<Quaternion>();

        carCount = endPoints.Count;
        for (int i = 1; i < carCount; i++)
        {
            startPoints[i].GetComponentInChildren<SpriteRenderer>().enabled = false;
            endPoints[i].GetComponent<SpriteRenderer>().enabled = false;
        }
            
        endPoints[0].tag = "Exit";
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) {
            StartGame();
        }
        
        if(playing)
        {
            // timer += Time.deltaTime;
            // timerTxt.text = timer.ToString();

            recordTime += Time.deltaTime;
            if (recordTime > 0.05)
            {
                locations.Add(new Vector2(transform.position.x, transform.position.y));
                // rotations.Add(transform.eulerAngles.z);
                rotations.Add(transform.rotation);
                recordTime -= 0.05f;
            }
        }
        else
        {

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playing = false;
        leftRightTxt.text = "LEFT					RIGHT";
        GetComponent<CarMove>().playing = false;
        for (int i = 0; i < botCars.Count; i++)
        {
            botCars[i].GetComponent<BotCarMove>().playing = false;
        }

        if (collision.IsTouchingLayers(exitMask)) {
            Debug.Log("asdasd");
        }
        
        if (collision.CompareTag("Exit"))
        {
            //next turn
            turnCounter++;
            if (carCount == turnCounter)
            {
                string scnName = "Level" + (currentLevel + 1).ToString();
                SceneManager.LoadScene(sceneName: scnName);
            }

            botCars.Add(Instantiate(botCarPrefab));

            botCars[botCars.Count - 1].GetComponent<BotCarMove>().locations = locations.GetRange(0, locations.Count);
            botCars[botCars.Count - 1].GetComponent<BotCarMove>().rotations = rotations.GetRange(0, rotations.Count);

            locations.Clear();
            rotations.Clear();
            
            var tr = transform;
            tr.position = startPoints[turnCounter].transform.position;
            tr.rotation = startPoints[turnCounter].transform.rotation;

            endPoints[turnCounter - 1].tag = "Passive";
            startPoints[turnCounter - 1].GetComponentInChildren<SpriteRenderer>().enabled = false;
            endPoints[turnCounter - 1].GetComponent<SpriteRenderer>().enabled = false;

            endPoints[turnCounter].tag = "Exit";
            startPoints[turnCounter].GetComponentInChildren<SpriteRenderer>().enabled = true;
            endPoints[turnCounter].GetComponent<SpriteRenderer>().enabled = true;

            oldTimer = timer;
        }
        else
        {
            //reset turn
            transform.position = startPoints[turnCounter].transform.position;
            transform.rotation = startPoints[turnCounter].transform.rotation;

            locations.Clear();
            rotations.Clear();

            timer = oldTimer;
            
            carMove.Reset();
        }

    }

    public void StartGame()
    {
        playing = true;
        GetComponent<CarMove>().playing = true;
        for (int i = 0; i < botCars.Count; i++)
        {
            botCars[i].GetComponent<BotCarMove>().playing = true;
        }
        leftRightTxt.text = "";
    }
}
