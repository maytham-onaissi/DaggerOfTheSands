using UnityEngine;

public class Mana : MonoBehaviour
{

    [Header("Classes")]
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject manaUI;

    [Header("Specifications")]
    [SerializeField] private float manaRegenAmount;
    public float manaAmount;
    public float MAX_MANA;

    // Start is called before the first frame update
    void Start()
    {
        MAX_MANA = playerController.playerStatus.totalMana;
        playerController.playerStatus.currentMana = MAX_MANA;
        manaAmount = playerController.playerStatus.currentMana;

        manaUI.GetComponent<ManaUI>().SetMaxMana(manaAmount);
    }

    // Update is called once per frame
    void Update()
    {
       /* if (Input.GetKeyDown(KeyCode.V))
        {
            SpendMana(30);
        }*/

        if (Input.GetKeyDown(KeyCode.E))
        {
            RegenMana();
        }

       // Debug.Log(manaAmount);
    }

    public void SpendMana(int _Amount)
    {
        Debug.Log(playerController.playerStatus.currentMana);
        playerController.playerStatus.currentMana -= _Amount;
        Debug.Log(playerController.playerStatus.currentMana);
        manaUI.GetComponent<ManaUI>().SetMana(playerController.playerStatus.currentMana);
    }

    public bool canSpendMana(int _Amount)
    {
        return playerController.playerStatus.currentMana >= _Amount;
    }

    public void RegenMana()
    {
        playerController.playerStatus.currentMana = Mathf.Clamp(playerController.playerStatus.currentMana + manaRegenAmount, 0f, MAX_MANA);
        manaUI.GetComponent<ManaUI>().SetMana(playerController.playerStatus.currentMana);
    }
}
