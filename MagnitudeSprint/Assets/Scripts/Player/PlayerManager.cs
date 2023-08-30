using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public GameObject LeftArm;
    public GameObject RightArm;
    public GameObject LeftLeg;
    public GameObject RightLeg;

    public Text StrengthText;
    private int _strength = 1;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int delta = -other.gameObject.GetComponent<Enemy>().Strength;
            ChangeStrength(delta);
            other.gameObject.GetComponent<Enemy>().Fall();
        }
        else if (other.gameObject.CompareTag("CarrotLoot"))
        {
            ChangeStrength(-1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("BarbellObstacle"))
        {
            ChangeStrength(-1);
        }
        else if (other.gameObject.CompareTag("SteakLoot"))
        {
            ChangeStrength(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
        }
    }


    private void ChangeStrength(int delta)
    {
        _strength += delta;
        StrengthText.text = $"Strength: {_strength}";
        ChangePlayerScale(delta);
    }


    private void ChangePlayerScale(int delta)
    {
        if (delta > 0)
        {
            for (int i = 0; i < delta; i++)
            {
                LeftLeg.transform.localScale += new Vector3(0.1f, 0, 0);
                RightLeg.transform.localScale += new Vector3(0.1f, 0, 0);
                LeftArm.transform.localScale += new Vector3(0.1f, 0, 0.1f);
                RightArm.transform.localScale += new Vector3(0.1f, 0, 0.1f);
            }
        }
        else
        {
            for (int i = 0; i < -delta; i++)
            {
                LeftLeg.transform.localScale -= new Vector3(0.1f, 0, 0);
                RightLeg.transform.localScale -= new Vector3(0.1f, 0, 0);
                LeftArm.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
                RightArm.transform.localScale -= new Vector3(0.1f, 0, 0.1f);
            }
        }
    }
}
