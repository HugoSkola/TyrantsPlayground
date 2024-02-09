
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bosshealth : MonoBehaviour
{
    public Image bossbar;
    [SerializeField]
    public int bosshp = 100;
    // Start is called before the first frame update
    void Start()
    {
        bossbar = GameObject.Find("bossbar").GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        bossbar.fillAmount = bosshp / 100f;
    }
}
