using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool UIActive = false;
    byte CurrentUI = 0;
    public GameObject[] Ui;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("BuildMenu"))
        {
            Debug.Log("good");
            CurrentUI = 0;
            if ((CurrentUI == 0) || (UIActive == false))
            {
                UIActive = !UIActive;
            }
        }
        if (UIActive == true)
        {
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
            foreach (GameObject ui in Ui)
            {
                ui.SetActive(false);
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
    }
}
