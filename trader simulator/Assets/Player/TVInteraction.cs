using UnityEngine;

public class TVInteraction : MonoBehaviour
{
    public GameObject Canvas; // Buy/Sell UI Paneli
    private bool isPlayerNear = false; // Karakter TV'ye yak�n m�?
    public CoinMarketManager coinMarketManager;
   
    void Start()
    {
        Canvas.SetActive(false); // Buy/Sell UI gizli ba�lar
    }
    
    void Update()
    {
        // Karakter yak�nken F tu�una bas�ld���nda paneli a�
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            Canvas.SetActive(!Canvas.activeSelf); // A�/Kapat
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("TV'nin �n�ne geldin. F tu�una basarak Buy/Sell ekran�n� a�abilirsin.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Canvas.SetActive(false); // Karakter uzakla�t���nda paneli kapat
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("TV'den uzakla�t�n.");
        }
    }
}
