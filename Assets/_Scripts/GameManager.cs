using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject m_water;
    private float posYUp = 3;
    private float posYDown = 17;
    private float posY = 3;
    public GameObject m_rain;

    public float gazeTime = 1;
    private float timer;
    private bool gazeAtCheia;
    private bool gazeAtSeca;

    // Use this for initialization
    void Start () {
		
	}

    void Update()
    {
        if (gazeAtCheia)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                if (posY <= 17)
                {
                    m_rain.SetActive(true);
                    posY += 0.05f;
                    m_water.transform.position = new Vector3(249, posY, 249);
                }
                if (posY >= 17)
                {
                    gazeAtCheia = false;
                    m_rain.SetActive(false);
                    timer = 0;
                }
            }
        }

        if (gazeAtSeca)
        {
            timer += Time.deltaTime;
            if (timer >= gazeTime)
            {
                if (posY >= 3)
                {
                    posY -= 0.05f;
                    m_water.transform.position = new Vector3(249, posY, 249);
                }
                if (posY <= 3) {
                    gazeAtSeca = false;
                    timer = 0;
                }
            }
        }
        
    }

    public void PointerEnterCheia()
    {
        gazeAtCheia = true;
        gazeAtSeca = false;
    }

    public void PointerEnterSeca()
    {        
        gazeAtSeca = true;
        m_rain.SetActive(false);
        gazeAtCheia = false;
    }

    public void PointerExit()
    {
        
    }
}
