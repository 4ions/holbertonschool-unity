using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrlOpen : MonoBehaviour
{
    // Start is called before the first frame update

    public void OpenFacebook(){
        Application.OpenURL("https://www.facebook.com/leovalsan");
    }

    public void OpenLinkedIn(){
        Application.OpenURL("https://www.linkedin.com/in/leovalsan/");
    }
    public void OpenTwitter(){
        Application.OpenURL("https://twitter.com/leovalsan_dev/");
    }
    public void OpenInstagram(){
        Application.OpenURL("https://www.instagram.com/leovalsan/");
    }
}
