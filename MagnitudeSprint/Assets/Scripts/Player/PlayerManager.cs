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

    private GameObject _currBarbell;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            int delta = -other.gameObject.GetComponent<Enemy>().Strength;
            ChangeStrength(delta);
            if (_strength > 0)
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
            _currBarbell = other.gameObject;
            if (_strength > 0)
                SmashBarbell();
        }
        else if (other.gameObject.CompareTag("SteakLoot"))
        {
            ChangeStrength(1);
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Coin"))
        {
            LevelController.Instance.AddCoin();
            Destroy(other.gameObject);
        }
        else if (other.gameObject.CompareTag("Finish"))
        {
            LevelController.Instance.OnFinish();
            gameObject.GetComponent<PlayerMovement>().Move = false;
        }
        else if (other.gameObject.CompareTag("BarbellFinish"))
        {
            ChangeStrength(-1);
            if (_strength > 0)
            {
                LevelController.Instance.StopFinishBarbell();
                _currBarbell = other.gameObject;
                Invoke("SmashBarbell", 0.7f);
            }
        }
    }


    private void SmashBarbell()
    {
        _currBarbell.GetComponent<Barbell>().Slap();
    }


    private void ChangeStrength(int delta)
    {
        _strength += delta;
        StrengthText.text = $"Strength: {_strength}";
        ChangePlayerScale(delta);

        if (_strength < 1)
        {
            if (LevelController.Instance.GameStatement == GameStatement.GameOn)
                LevelController.Instance.PlayerLose();
            else
                LevelController.Instance.GameOver();
        }
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