using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public GameObject HelpPage;
    public GameObject HelpPage2;
    public GameObject HelpPage3;
    public GameObject HelpPage4;

    public void OpenPage2()
    {
        HelpPage.gameObject.SetActive(false);
		HelpPage2.gameObject.SetActive(true);
        HelpPage3.gameObject.SetActive(false);
        HelpPage4.gameObject.SetActive(false);
	}

    public void ClosePage2()
    {
        HelpPage.gameObject.SetActive(true);
		HelpPage2.gameObject.SetActive(false);
        HelpPage3.gameObject.SetActive(false);
        HelpPage4.gameObject.SetActive(false);
	}
     
    public void GoingPage3()
    {
		HelpPage3.gameObject.SetActive(true);
		HelpPage2.gameObject.SetActive(false);
		HelpPage.gameObject.SetActive(false);
		HelpPage4.gameObject.SetActive(false);
	}

    public void GoingPage4()
    {
		HelpPage3.gameObject.SetActive(false);
		HelpPage2.gameObject.SetActive(false);
		HelpPage.gameObject.SetActive(false);
		HelpPage4.gameObject.SetActive(true);
	}

}
