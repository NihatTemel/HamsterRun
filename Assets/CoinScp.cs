using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class CoinScp : MonoBehaviour
{


    private void FixedUpdate()
    {
        GetComponent<TMP_Text>().text = "Coin : " + PlayerPrefs.GetInt("coin");
    }

}
