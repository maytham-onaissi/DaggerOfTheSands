using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAbility : MonoBehaviour
{

    [SerializeField] private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    public void AcquireDagger()
    {
        playerController.GetComponent<JumpController>().DaggerAcquired();
    }

    public void AcquireSecondGem()
    {

        playerController.GetComponent<SerpentFangs>().SecondGemAcquired();
    }

    public void EmbedGem()
    {
        if (playerController.GetComponent<SerpentFangs>().secondGemAquired && !playerController.GetComponent<SerpentFangs>().secondGemEmbedded)
            EmbedSecondGem();
        
        if (playerController.GetComponent<SerpentStep>().thirdGemAquired && !playerController.GetComponent<SerpentStep>().thirdGemEmbedded)
            EmbedThirdGem();    
    }

    public void EmbedSecondGem()
    {

        playerController.GetComponent<SerpentFangs>().SecondGemEmbedded();
    }

    public void AcquireThirdGem()
    {
        playerController.GetComponent<SerpentStep>().ThirdGemAcquired();
    }

    public void EmbedThirdGem()
    {
        playerController.GetComponent<SerpentStep>().ThirdGemEmbedded();
    }

    public void AcquireBracelet()
    {
        playerController.GetComponent<MapManager>().BraceletObtained();
    }

    public void AcquireFlask()
    {
        playerController.GetComponent<Health>().FlaskAcquired();
    }


}
