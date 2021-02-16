using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlockScript : MonoBehaviour
{  [HideInInspector]
    public bool moveLikeYoyo;
    void Start()
    {
        if (moveLikeYoyo)
        {//set loop -1 means repeat this infinite times 
            transform.DOMoveY(-0.1f, 0.5f).SetLoops(-1,LoopType.Yoyo);
        }
        
    }
    void FallBlock()
    {
        CancelInvoke("FallBlock");
        transform.DOLocalMoveY(-3, 0.5f);
        Destroy(gameObject, 0.5f);
    }
    private void OnCollisionEnter(Collision t)
    {
        if (t.gameObject.name == "Cat")
        {
            if (moveLikeYoyo)
            {
                Invoke("FallBlock", 0.25f);
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
