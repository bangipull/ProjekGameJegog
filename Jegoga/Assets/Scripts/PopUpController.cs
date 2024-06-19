using UnityEngine;
using UnityEngine.SceneManagement;

public class PopUpController : MonoBehaviour
{
    public GameObject PopUpPanel; // Panel pop-up
    public GameObject QuitPanel; // Panel konfirmasi keluar
    private bool isPaused = false;
    private JegogController[] jegogBars; // Array untuk menyimpan semua bilah JegogBar

    void Start()
    {
        PopUpPanel.SetActive(false);
        QuitPanel.SetActive(false); // Pastikan panel opsi tersembunyi pada awal
        jegogBars = FindObjectsOfType<JegogController>(); // Temukan semua objek JegogBar di scene
    }

    public void OpenPopUpPanel()
    {
        PopUpPanel.SetActive(true);
        JegogController.isPaused = true; // Set static variable isPaused to true
        isPaused = true;
    }

    public void ClosePopUpPanel()
    {
        PopUpPanel.SetActive(false);
        JegogController.isPaused = false; // Set static variable isPaused to false
        isPaused = false;
    }

    public void ShowQuitConfirmation()
    {
        PopUpPanel.SetActive(false);
        QuitPanel.SetActive(true);
    }

    public void ConfirmQuit()
    {
        QuitPanel.SetActive(false);
        JegogController.isPaused = false; // Set static variable isPaused to false
        SceneManager.LoadScene("MainMenu"); // Ganti "MainMenu" dengan nama scene menu utama Anda
    }

    public void CancelQuit()
    {
        QuitPanel.SetActive(false);
        if (isPaused)
        {
            PopUpPanel.SetActive(true);
        }
    }
}
