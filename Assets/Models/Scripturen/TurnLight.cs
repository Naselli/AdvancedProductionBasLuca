using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnLight : MonoBehaviour
{
    public GameObject lamp;
    public GameObject aud;
    public GameObject player;
    public GameObject superLamp;
    public Animator animUp;
    public Animator animDown;
    public Animator deur;
    public Animator giraffe;

    [SerializeField]
    private Text interactText = null, sleepText = null, thankers;

    private bool on = true;
    private RaycastHit hit;

    public LayerMask layer;

    private bool isDark;
    private int encounterCount = 0;
    private bool showTxt = true;
    private bool isDead = false;

    [SerializeField]
    private bool Eyestate = true;

    public List<GameObject> objects = new List<GameObject>();
    public List<Vector3> location = new List<Vector3>();
    public List<Vector3> originalPos = new List<Vector3>();

    private void Start()
    {
        aud.GetComponent<SoundBoard>().PlaySound(1);
        aud.GetComponent<SoundBoard>().PlaySound(8);
    }

    private void Update()
    {
        interactText.text = "";
        sleepText.text = "";

        if (isDead == true)
        {
            StartCoroutine(CoroutineForDreDead(3f));
            sleepText.text = "";
        }

        if (Eyestate)
        {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 5f, Color.green);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward * 5f, layer))
            {

                interactText.text = "Press E to interact.";

                if (Input.GetKeyDown(KeyCode.E))
                {
                    aud.GetComponent<SoundBoard>().PlaySound(0);
                    on = !on;
                    lamp.SetActive(on);
                    lamp.GetComponent<Light>().enabled = on;

                    isDark = !on;
                }

            }
        }

        if (isDark)
        {
            if (Eyestate)
            {
                if (showTxt == true)
                {
                    sleepText.text = "C - Close Eyes";
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        showTxt = false;
                        animUp.SetTrigger("GoDown");
                        animDown.SetTrigger("GoDown");
                        NewState();
                        NextEncounter();
                    }
                }
                else
                {
                    sleepText.text = "";
                    interactText.text = "";
                }

            }
            else
            {
                if (isDead == true)
                {
                    sleepText.text = "";
                }
                else
                {
                    sleepText.text = "C - Open Your Eyes";
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        aud.GetComponent<SoundBoard>().PlaySound(1);
                        animUp.SetTrigger("GoUp");
                        animDown.SetTrigger("GoUp");
                        Eyestate = true;
                    }
                }
            }
        }

    }

    public void NewState()
    {
        switch (encounterCount)
        {
            case 0:
                StartCoroutine(CoroutineForDreUno(3f));
                break;
            case 1:
                StartCoroutine(CoroutineForDreDos(3f));
                break;
            case 2:
                StartCoroutine(CoroutineForDreTres(3f));
                break;
            case 3:
                StartCoroutine(CoroutineForDreQuatro(3f));
                break;
            case 4:
                StartCoroutine(CoroutineForDreZero(3f));
                break;
            default:
                Eyestate = false;
                break;
        }
    }

    public void NextEncounter()
    {
        encounterCount++;
    }

    public IEnumerator CoroutineForDreUno(float time)
    {
        yield return new WaitForSeconds(time);

        aud.GetComponent<SoundBoard>().PlaySound(2);

        objects[0].transform.position = location[0];
        objects[1].transform.position = location[1];

        yield return new WaitForSeconds(time / 2);
        aud.GetComponent<SoundBoard>().PlaySound(3);
        yield return new WaitForSeconds(time);
        Eyestate = false;
        showTxt = true;
    }

    public IEnumerator CoroutineForDreDos(float time)
    {
        yield return new WaitForSeconds(time);

        aud.GetComponent<SoundBoard>().PlaySound(4);

        objects[2].transform.position = location[2];
        objects[3].transform.position = location[3];

        yield return new WaitForSeconds(time);
        aud.GetComponent<SoundBoard>().PlaySound(4);
        yield return new WaitForSeconds(time / 2f);
        Eyestate = false;
        showTxt = true;
    }

    public IEnumerator CoroutineForDreTres(float time)
    {
        yield return new WaitForSeconds(time);

        aud.GetComponent<SoundBoard>().PlaySound(5);

        objects[0].transform.position = originalPos[0];
        objects[1].transform.position = originalPos[1];
        objects[2].transform.position = originalPos[2];
        objects[3].transform.position = originalPos[3];

        yield return new WaitForSeconds(time * 1.5f);
        aud.GetComponent<AudioSource>().volume = 1f;
        aud.GetComponent<SoundBoard>().PlaySound(6);
        aud.GetComponent<AudioSource>().volume = 0.15f;
        Eyestate = false;
        showTxt = true;
    }


    public IEnumerator CoroutineForDreQuatro(float time)
    {
        yield return new WaitForSeconds(time);
        aud.GetComponent<SoundBoard>().PlaySound(7);
        aud.GetComponent<AudioSource>().volume = 1f;
        aud.GetComponent<SoundBoard>().PlaySound(8);
        aud.GetComponent<AudioSource>().volume = 0.15f;

        deur.SetTrigger("DraaiDeur");
        objects[4].transform.position = location[4];
        yield return new WaitForSeconds(time * 2.5f);
        Eyestate = false;
        showTxt = true;
    }

    public IEnumerator CoroutineForDreZero(float time)
    {
        yield return new WaitForSeconds(time);
        aud.GetComponent<AudioSource>().volume = 0.05f;
        aud.GetComponent<SoundBoard>().PlaySound(9);
        yield return new WaitForSeconds(time * 2.5f);
        aud.GetComponent<SoundBoard>().PlaySound(10);
        aud.GetComponent<AudioSource>().volume = 0.4f;
        aud.GetComponent<SoundBoard>().PlaySound(8);
        yield return new WaitForSeconds(time * 2f);
        aud.GetComponent<AudioSource>().volume = 0.15f;
        lamp.GetComponent<Light>().color = Color.red;
        lamp.GetComponent<Light>().intensity = 6.5f;
        lamp.SetActive(true);
        lamp.GetComponent<Light>().enabled = true;
        Eyestate = false;
        showTxt = true;
        isDead = true;
    }

    public IEnumerator CoroutineForDreDead(float time)
    {
        animUp.SetTrigger("GoUp");
        animDown.SetTrigger("GoUp");
        player.transform.rotation = Quaternion.Euler(0f, 86f, 0f);
        player.GetComponent<MouseLook>().enabled = false;
        yield return new WaitForSeconds(0.5f);
        deur.SetTrigger("Slam");
        deur.SetTrigger("SlamSlam");
        giraffe.SetTrigger("GaanBanaan");
        aud.GetComponent<SoundBoard>().PlaySound(11);
        yield return new WaitForSeconds(1.5f);
        animUp.SetTrigger("GoDown");
        animDown.SetTrigger("GoDown");
        showTxt = false;
        superLamp.GetComponent<TurnLight>().enabled = false;
        yield return new WaitForSeconds(1f);
        thankers.text = "Thank you for playing!";
        yield return new WaitForSeconds(6f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        Cursor.visible = true;
    }
}
