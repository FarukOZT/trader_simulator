using UnityEngine;

public class TVInteraction : MonoBehaviour
{
    public GameObject Canvas; // Buy/Sell UI Paneli
    private bool isPlayerNear = false; // Karakter TV'ye yakýn mý?
    public CoinMarketManager coinMarketManager;
   
    void Start()
    {
        Canvas.SetActive(false); // Buy/Sell UI gizli baþlar
    }
    
    void Update()
    {
        // Karakter yakýnken F tuþuna basýldýðýnda paneli aç
        if (isPlayerNear && Input.GetKeyDown(KeyCode.F))
        {
            Canvas.SetActive(!Canvas.activeSelf); // Aç/Kapat
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = true;
            Debug.Log("TV'nin önüne geldin. F tuþuna basarak Buy/Sell ekranýný açabilirsin.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNear = false;
            Canvas.SetActive(false); // Karakter uzaklaþtýðýnda paneli kapat
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Debug.Log("TV'den uzaklaþtýn.");
        }
    }
}
