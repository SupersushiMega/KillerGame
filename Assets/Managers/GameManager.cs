using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool BuildMode = false;
    bool UIActive = false;
    byte CurrentUI = 0;
    public GameObject[] Ui;
    public PlayerWeapons playerWeapons;
    public CameraMovementNonRB CameraMovement;
    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("BuildMode"))
        {
            BuildMode = true;
        }

        if (Input.GetButtonDown("UI Open"))
        {
            CurrentUI = 0;
            if ((CurrentUI == 0) || (UIActive == false))
            {
                UIActive = !UIActive;
            }
        }
        if (UIActive == true)
        {
            playerWeapons.PanActive = false;
            playerWeapons.MinigunActive = false;
            Cursor.lockState = CursorLockMode.None;
            foreach (GameObject ui in Ui)
            {
                if (ui == Ui[CurrentUI])
                {
                    ui.SetActive(true);
                }

                else
                {
                    ui.SetActive(false);
                }
            }
        }

        else
        {
            playerWeapons.PanActive = true;
            playerWeapons.MinigunActive = true;
            Cursor.lockState = CursorLockMode.Locked;
            foreach (GameObject ui in Ui)
            {
                ui.SetActive(false);
            }
        }
    }
}
