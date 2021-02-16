using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatMovment : MonoBehaviour
{
    private BlockManager blockManager;
    [SerializeField]
    private float speed=0.3f, height=0.5f;
    [SerializeField]
    private AudioClip catDie;
    private AudioSource audioManager;
    ArrayList keyArray = new ArrayList();

    private bool isDied;
    private Animator anim;
    private GameObject waterFX;
    private void Awake()
    {
        blockManager = GameObject.Find("Block Manager").GetComponent<BlockManager>();
        anim = GetComponentInChildren<Animator>();
        audioManager = GetComponent<AudioSource>();
    }
    private void Start()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly);
    }

    void CheckInput()
    {
       if( Input.GetKeyDown(KeyCode.UpArrow))
            keyArray.Add(KeyCode.UpArrow);

        if (Input.GetKeyDown(KeyCode.DownArrow))
            keyArray.Add(KeyCode.DownArrow);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            keyArray.Add(KeyCode.RightArrow);

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            keyArray.Add(KeyCode.LeftArrow);

        if (keyArray.Count > 0)
        {

            MoveCat();
            keyArray.RemoveAt(0);
        }

    }
    void MoveCat()
    {

    }
    // Update is called once per frame
    void Update()
    {
        if(!isDied &&blockManager.catLandedBlock!=null)
        {
            CheckInput();
        }
        
    }
    private void OnCollisionEnter(Collision t)
    {
        if (t.gameObject.name==("Stone")) {
            blockManager.catLandedBlock = t.gameObject;
        }
    }
}
