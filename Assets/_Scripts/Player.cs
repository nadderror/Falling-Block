// Change Default scripts on Editor\Data\Resources\ScriptTemplates

using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    static Player _i; //  _i ←→ _instance 

    public static Player I
    {
        get
        {
            //Singleton
            if (_i == null) //Are we have Player before? Checking...
            {
                _i = FindObjectOfType<Player>();
                if (_i == null)
                {
                    //Ok... we dont have any <Player>(); then create that
                    GameObject myPlayer = new GameObject("Player");
                    myPlayer.AddComponent<Player>();
                    _i = myPlayer.GetComponent<Player>();
                }
            }

            //return _i anyway
            return _i;
        }
    }

    private void Awake()
    {
        if (_i != null) // if we have _i (Player) before, then destroy me bos...
            Destroy(this);
        DontDestroyOnLoad(this.gameObject); //it's ok... i'am first <Player>() now.
    }

    public void TakeDamage(float damageAmounth)
    {
        GetComponent<Health>().TakeDamage(1);
    }

}