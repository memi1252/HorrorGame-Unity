using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] private int moveSpeed;
    [SerializeField] public GameObject mirrorgimic;
    [SerializeField] private ParticleSystem particleSystem = null;
    [SerializeField] private GameObject alter;
    [SerializeField] private GameObject flash;
    public GameObject itemPos;
    public bool isFlash;
    public bool isEraser;
    public Animator playerAnimator;
    public bool move = true;
    public bool die;
    public bool ui;
    private bool mirroronemore = false;
    public float h;
    public float v;
    public float mouseX;
    public float mouseY;

    public int alternumber;
    
    private RotateToMouse rotateToMouse;
    private float time = 4f;
    public bool restart = false;
    private int a;
    
    int monseterDiecount = 0;
    
    public static player Instance { get; private set; }


    private void Awake()
    {
        Instance = this;

        rotateToMouse = GetComponent<RotateToMouse>();
        playerAnimator = GetComponent<Animator>();
        a = 0;
        a = PlayerPrefs.GetInt("resstart");
        
        Time.timeScale = 1;
    }

    private void Start()
    {
        settingUI.Instance.BGMSlider.value = PlayerPrefs.GetFloat("BGM");
        settingUI.Instance.EffectSlider.value = PlayerPrefs.GetFloat("Effect");
    }

    private void Update()
    {
        Move();
        UpdateRotate();
        Pause();
        Die();
        Inventory();
        ToggleCursorVisibility();
        if (mirrorgimic != null)
        {
            if (mirrorgimic.activeSelf)
            {
                if (mirrorInteract.Instance.gameObject.activeSelf)
                {
                    if (!mirroronemore)
                    {
                        soundManager.Instance.itemDropAudioSource.Play();
                        mirroronemore = true;
                    }
                }
            }
        }

        if (a == 1)
        {
            restart = true;
        }
        else
        {
            restart = false;
        }
        
        
        if (restart)
        {
            gameObject.transform.position = new Vector3(-28, 20, -300);
            gameObject.transform.rotation = new Quaternion(0, -178, 0, 0);
            RotateToMouse.Instance.pause = true;
            RotateToMouse.Instance.anglepause = true;
            InventoryUI.Instance.baseBall = true;
            InventoryUI.Instance.eraser = true;
            InventoryUI.Instance.cross = true;
            InventoryUI.Instance.nail = true;
            InventoryUI.Instance.mirror = true;
            flash.SetActive(true);
            StartCoroutine(d());
            
            a = 0;
            Debug.Log("ddd");
            PlayerPrefs.SetInt("resstart", 0);
            restart = false;
        }
    }

    private IEnumerator d()
    {
        yield return new WaitForSeconds(1f);
        alter.SetActive(true);
    }
    
    private void UpdateRotate()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        rotateToMouse.CalculateRotation(mouseX, mouseY);
    }

    private void Move()
    {
        if (move)
        {
            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");

            var moveDir = new Vector3(h, 0, v);

            transform.Translate(moveDir * moveSpeed * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) moveSpeed = 8;
        if (Input.GetKeyUp(KeyCode.LeftShift)) moveSpeed = 3;

        if (particleSystem != null)
        {
            if (h > 0 || v > 0)
            {
                particleSystem.Play();
            }
            else
            {
                particleSystem.Stop();
            }
        }
    }

    private void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!storyinteract.Instance.interact && !InventoryUI.Instance.gameObject.activeSelf
                                                 && !DiaryUI.Instance.gameObject.activeSelf &&
                                                 !DieUI.Instance.gameObject.activeSelf
                                                 && !OpenChestUI.Instance.gameObject.activeSelf &&
                                                 !settingUI.Instance.gameObject.activeSelf
                                                 && !boxUI.Instance.gameObject.activeSelf &&
                                                 !offeringUI.Instance.gameObject.activeSelf
                                                 && !AlterTutorialUI.Instance.gameObject.activeSelf)
            {
                if (pauseUI.Instance.gameObject.activeSelf)
                {
                    Time.timeScale = 1;
                    pauseUI.Instance.Hide();
                    RotateToMouse.Instance.anglepause = true;
                    RotateToMouse.Instance.pause = true;
                }
                else
                {
                    Time.timeScale = 0;
                    pauseUI.Instance.Show();
                    RotateToMouse.Instance.anglepause = false;
                    RotateToMouse.Instance.pause = false;
                }
            }

            if (settingUI.Instance.gameObject.activeSelf)
            {
                settingUI.Instance.Hide();
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
                pauseUI.Instance.pauseUIpasue = false;
                Time.timeScale = 1;
            }

            if (boxUI.Instance.gameObject.activeSelf)
            {
                if (!BoxInteract.Instance.isShow)
                {
                    boxCloseMonster.Instance.monstershow();
                    gameObject.transform.position = new Vector3(120, 21, 49);
                    story5.Instance.startt();
                    BoxInteract.Instance.isShow = true;
                }

                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
                Time.timeScale = 1;
            }

            if (StoryUI.Instance.gameObject.activeSelf)
            {
                StoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                storyinteract.Instance.interact = false;
            }

            if (InventoryUI.Instance.gameObject.activeSelf)
            {
                InventoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }

            if (DiaryUI.Instance.gameObject.activeSelf)
            {
                DiaryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }

            if (OpenChestUI.Instance.gameObject.activeSelf)
            {
                OpenChestUI.Instance.Hide();
                ui = false;
                move = true;
                RotateToMouse.Instance.anglepause = true;
                storyNail.Instance.miirorON();
                RotateToMouse.Instance.pause = true;
                if (OpenChestInteract.Instance.dd)
                {
                    storyNail.Instance.ss();
                    OpenChestInteract.Instance.dd=false;
                }
            }

            if (offeringUI.Instance.gameObject.activeSelf)
            {
                offeringUI.Instance.Hide();
                move = true;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }
        }
    }

    private void Die()
    {
        if (die)
        {
            offeringUI.Instance.Hide();
            InventoryUI.Instance.Hide();
            RotateToMouse.Instance.pause = false;
            RotateToMouse.Instance.anglepause = false;
            time -= Time.deltaTime;
            if (time <= 0)
            {
                DieUI.Instance.Show();
                pauseUI.Instance.pauseUIpasue = true;
                move = false;
                h = 0;
                v = 0;
                Time.timeScale = 0;
            }
        }
    }

    private void Inventory()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (InventoryUI.Instance.gameObject.activeSelf)
            {
                InventoryUI.Instance.Hide();
                Time.timeScale = 1;
                RotateToMouse.Instance.anglepause = true;
                RotateToMouse.Instance.pause = true;
            }
            else
            {
                if (!pauseUI.Instance.gameObject.activeSelf && !boxUI.Instance.gameObject.activeSelf
                                                            && !settingUI.Instance.gameObject.activeSelf &&
                                                            !DiaryUI.Instance.gameObject.activeSelf
                                                            && !DieUI.Instance.gameObject.activeSelf &&
                                                            !StoryUI.Instance.gameObject.activeSelf
                                                            && !OpenChestUI.Instance.gameObject.activeSelf)
                {
                    InventoryUI.Instance.Show();
                    Time.timeScale = 0;
                    RotateToMouse.Instance.anglepause = false;
                    RotateToMouse.Instance.pause = false;
                }
            }
        }
    }

    private void ToggleCursorVisibility()
    {
        if (!ui)
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt) || Input.GetKeyDown(KeyCode.RightAlt))
            {
                RotateToMouse.Instance.pause = false;
                RotateToMouse.Instance.anglepause = false;
            }
            else if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.RightAlt))
            {
                RotateToMouse.Instance.pause = true;
                RotateToMouse.Instance.anglepause = true;
            }
        }
    }
    
    
    public void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("eraser"))
        {
            offeringUI.Instance.eraser = true;
            offeringUI.Instance.cross = false;
            offeringUI.Instance.baseBall = false;
            offeringUI.Instance.nail = false;
            offeringUI.Instance.mirror = false;
            alternumber = 1;
        }
        if (other.CompareTag("cross"))
        {
            offeringUI.Instance.eraser = false;
            offeringUI.Instance.cross = true;
            offeringUI.Instance.baseBall = false;
            offeringUI.Instance.nail = false;
            offeringUI.Instance.mirror = false;
            alternumber = 2;
        }
        if (other.CompareTag("baseball"))
        {
            offeringUI.Instance.eraser = false;
            offeringUI.Instance.cross = false;
            offeringUI.Instance.baseBall = true;
            offeringUI.Instance.nail = false;
            offeringUI.Instance.mirror = false;
            alternumber = 3;
        }
        if (other.CompareTag("nail"))
        {
            offeringUI.Instance.eraser = false;
            offeringUI.Instance.cross = false;
            offeringUI.Instance.baseBall = false;
            offeringUI.Instance.nail = true;
            offeringUI.Instance.mirror = false;
            alternumber = 4;
        }
        if (other.CompareTag("mirror"))
        {
            offeringUI.Instance.eraser = false;
            offeringUI.Instance.cross = false;
            offeringUI.Instance.baseBall = false;
            offeringUI.Instance.nail = false;
            offeringUI.Instance.mirror = true;
            alternumber = 5;
        }
    }
}