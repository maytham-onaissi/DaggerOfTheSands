using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapManager : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] private PlayerController playerController;

    [Header("Maps")]
    [SerializeField] private GameObject dunes;
    [SerializeField] private GameObject VotK_1;
    [SerializeField] private GameObject VotK_2;
    [SerializeField] private GameObject baghdad;
    [SerializeField] private GameObject oasis_1;
    [SerializeField] private GameObject oasis_2;
    [SerializeField] private GameObject Al_Ssuradiq;
    [SerializeField] private GameObject ancientKings;
    [SerializeField] private GameObject Training_Ground;
    [SerializeField] private GameObject IramOfThePillars;
    [SerializeField] private GameObject etched_Remnants_1;
    [SerializeField] private GameObject etched_Remnants_2;


    [Header("Booleans")]
    [SerializeField] private bool acquireBracelet = false;
    [SerializeField] private bool isIotP;
    [SerializeField] private bool isDunes;
    [SerializeField] private bool isVotK_1;
    [SerializeField] private bool isVotK_2;
    [SerializeField] private bool isOasis_1;
    [SerializeField] private bool isOasis_2;
    [SerializeField] private bool isBaghdad;
    [SerializeField] private bool isAl_Ssuradiq;
    [SerializeField] private bool isAncientKings;
    [SerializeField] private bool isTrainingGround;
    [SerializeField] private bool isEtched_Remnants_1;
    [SerializeField] private bool isEtched_Remnants_2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        SetMapBool();

        if (playerController.playerInputScript.mapInput && acquireBracelet)
        {
            Debug.Log("M is being pressed");     

            if (isTrainingGround)
            {
                Training_Ground.SetActive(true);
            }
            else if (isBaghdad)
            {
                baghdad.SetActive(true);
            }
            else if (isEtched_Remnants_1)
            {
                etched_Remnants_1.SetActive(true);
            }
            else if (isEtched_Remnants_2)
            {
                etched_Remnants_2.SetActive(true);
            }
            else if (isOasis_1)
            {
                oasis_1.SetActive(true);
            }
            else if (isOasis_2)
            {
                oasis_2.SetActive(true);
            }
            else if (isVotK_1)
            {
                VotK_1.SetActive(true);
            }
            else if (isVotK_2)
            {
                VotK_2.SetActive(true);
            }
            else if (isAncientKings)
            {
                ancientKings.SetActive(true);
            }
            else if (isDunes)
            {
                dunes.SetActive(true);
            }
            else if (isIotP)
            {
                IramOfThePillars.SetActive(true);
            }
            else if (isAl_Ssuradiq)
            {
                Al_Ssuradiq.SetActive(true);
            }


        }

        if (playerController.playerInputScript.notMapInput)
        {
            Debug.Log("M is not being pressed");    
            
            dunes.SetActive(false);
            VotK_1.SetActive(false);
            VotK_2.SetActive(false);
            baghdad.SetActive(false);
            oasis_1.SetActive(false);
            oasis_2.SetActive(false);
            Al_Ssuradiq.SetActive(false);
            ancientKings.SetActive(false);
            Training_Ground.SetActive(false);
            IramOfThePillars.SetActive(false);
            etched_Remnants_1.SetActive(false);
            etched_Remnants_2.SetActive(false);
        }
    }

    public void BraceletObtained()
    {
        StartCoroutine(BraceletAcquire());
    }

    public IEnumerator BraceletAcquire()
    {
        acquireBracelet = true;

        playerController.notifyText.text = "Bracelet of Revealing acquired; Press and Hold M to reveal the MAP";

        yield return new WaitForSeconds(3f);

        playerController.notifyText.text = "";
    }

 

    private void SetMapBool()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            isTrainingGround = true;
        }
        else
        {
            isTrainingGround = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            isBaghdad = true;
        }
        else
        {
            isBaghdad = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            isEtched_Remnants_1 = true;
        }
        else
        {
            isEtched_Remnants_1 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            isEtched_Remnants_2 = true;
        }
        else
        {
            isEtched_Remnants_2 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 6)
        {
            isOasis_1 = true;
        }
        else
        {
            isOasis_1 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            isOasis_2 = true;
        }
        else
        {
            isOasis_2 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            isVotK_1 = true;
        }
        else
        {
            isVotK_1 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 9)
        {
            isVotK_2 = true;
        }
        else
        {
            isVotK_2 = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 11)
        {
            isAncientKings = true;
        }
        else
        {
            isAncientKings = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 13)
        {
            isDunes = true;
        }
        else
        {
            isDunes = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            isIotP = true;
        }
        else
        {
            isIotP = false;
        }

        if (SceneManager.GetActiveScene().buildIndex == 16)
        {
            isAl_Ssuradiq = true;
        }
        else
        {
            isAl_Ssuradiq = false;
        }
    }
}
