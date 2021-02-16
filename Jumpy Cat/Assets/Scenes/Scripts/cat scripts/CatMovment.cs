using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CatMovment : MonoBehaviour
{
    private BlockManager blockManager;
    [SerializeField]
    private float speed=0.3f, height=2f;
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
        KeyCode key =(KeyCode) keyArray[0];

        if (key == KeyCode.UpArrow) {
            audioManager.Play(); //jumpsound
            anim.Play("ready");
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1f); //going forward in 3d is the z axis
            transform.DOJump(pos,height,1,speed);
            blockManager.LeaveLandedBlock();

            anim.SetTrigger("jump");
        }

        if (key == KeyCode.DownArrow)
        {
            audioManager.Play(); //jumpsound
            anim.Play("ready");
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1f); //going forward in 3d is the z axis
            transform.DOJump(pos, height, 1, speed);
            blockManager.LeaveLandedBlock();

            anim.SetTrigger("jump");
        }

        if (key == KeyCode.RightArrow)
        {
            audioManager.Play(); //jumpsound
            anim.Play("ready");
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
            Vector3 pos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z ); //going forward in 3d is the z axis
            transform.DOJump(pos, height, 1, speed);
            blockManager.LeaveLandedBlock();

            anim.SetTrigger("jump");
        }

        if (key == KeyCode.LeftArrow)
        {
            audioManager.Play(); //jumpsound
            anim.Play("ready");
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            Vector3 pos = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z); //going forward in 3d is the z axis
            transform.DOJump(pos, height, 1, speed);
           blockManager.LeaveLandedBlock();

            anim.SetTrigger("jump");
        }

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
