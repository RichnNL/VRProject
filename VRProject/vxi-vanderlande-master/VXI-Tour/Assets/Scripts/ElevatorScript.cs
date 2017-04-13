using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
public class ElevatorScript : MonoBehaviour
{
    // speech

    KeywordRecognizer keyWordRecognizer;
    Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();

    // empty objects infornt of the elevators
   // public GameObject elevator0;


    // boolean
    private bool checkElevator0;
    private bool checkElevator1;
    private bool checkElevator2;
    private bool checkElevator3;
    private bool checkElevator4;
    private bool checkElevator5;
    private bool checkElevator6;
    private bool checkElevator7;

    private bool checkInsideElevator0;
    //private bool checkInsideElevator1;
    //private bool checkInsideElevator2;
    //private bool checkInsideElevator3;
    //private bool checkInsideElevator4;
    //private bool checkInsideElevator5;
    //private bool checkInsidElevator6;
    //private bool checkInsideElevator7;

    // Use this for initialization
    void Start()
    {

        keywords.Add("Ground", () =>
        {
            EnteredElevator0();

        });
        keywords.Add("One", () =>
        {
            EnteredElevator1();

        });
        keywords.Add("Two", () =>
        {
            EnteredElevator2();

        });
        keywords.Add("Three", () =>
        {
            EnteredElevator3();

        });
        keywords.Add("Four", () =>
        {
            EnteredElevator4();

        });
        keywords.Add("Five", () =>
        {
            EnteredElevator5();

        });
        keywords.Add("Six", () =>
        {
            EnteredElevator6();

        });
        keywords.Add("Seven", () =>
        {
            EnteredElevator7();

        });

        keyWordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
        keyWordRecognizer.OnPhraseRecognized += KeyWordRecognizedOnPhraseRecognized;
        keyWordRecognizer.Start();

    }

    // Update is called once per frame
    void Update()
    {
        Toggle();

    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("elevator0"))
        {

            checkElevator0 = true;
        }

        if (other.gameObject.CompareTag("elevator1"))
        {

            checkElevator1 = true;

        }

        if (other.gameObject.CompareTag("elevator2"))
        {

            checkElevator2 = true;


        }
        if (other.gameObject.CompareTag("elevator3"))
        {

            checkElevator3 = true;


        }
        if (other.gameObject.CompareTag("elevator4"))
        {
            checkElevator4 = true;
        }
        if (other.gameObject.CompareTag("elevator5"))
        {

            checkElevator5 = true;


        }

        if (other.gameObject.CompareTag("elevator6"))
        {

            checkElevator6 = true;


        }
        if (other.gameObject.CompareTag("elevator7"))
        {

            checkElevator7 = true;


        }

        if (other.gameObject.CompareTag("InsideElevator0"))
        {

            checkInsideElevator0 = true;
        }

    



    }



   private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("elevator0"))
        {

            checkElevator0 = false;
        }

        if (other.gameObject.CompareTag("elevator1"))
        {

            checkElevator1 = false;

        }

        if (other.gameObject.CompareTag("elevator2"))
        {

            checkElevator2 = false;


        }
        if (other.gameObject.CompareTag("elevator3"))
        {

            checkElevator3 = false;


        }
        if (other.gameObject.CompareTag("elevator4"))
        {
            checkElevator4 = false;
        }
        if (other.gameObject.CompareTag("elevator5"))
        {

            checkElevator5 = false;


        }

        if (other.gameObject.CompareTag("elevator6"))
        {

            checkElevator6 = false;


        }
        if (other.gameObject.CompareTag("elevator7"))
        {

            checkElevator7 = false;


        }



        if (other.gameObject.CompareTag("InsideElevator0"))
        {

            checkInsideElevator0 = false;
        }

    }

    private void Toggle()
    {
        if (checkElevator0)
        {
            Debug.Log("you are 1st floor yo");
        }
        if (checkElevator1)
        {
            Debug.Log("you are 2nd floor yo");
        }
        if (checkElevator2)
        {

        }
        if (checkElevator3)
        {

        }
        if (checkElevator4)
        {

        }
        if (checkElevator5)
        {

        }
        if (checkElevator6)
        {

        }
        if (checkElevator7)
        {

        }
    }

    void KeyWordRecognizedOnPhraseRecognized(PhraseRecognizedEventArgs args)
    {
        System.Action keyAction;
            if (checkInsideElevator0)
        {
            if (keywords.TryGetValue(args.text, out keyAction))
        {
            
                keyAction.Invoke();
            }
        }

    }


    void EnteredElevator0()
    {
        Debug.Log("You jyst said ");

    }
    void EnteredElevator1()
    {
        Debug.Log("You selected 1st");

    }
    void EnteredElevator2()
    {
        Debug.Log("You selected 2nd");

    }
    void EnteredElevator3()
    {
        Debug.Log("You selected 3rd floor");

    }
    void EnteredElevator4()
    {
        Debug.Log("You selected 4th floor");

    }
    void EnteredElevator5()
    {
        Debug.Log("You selected 5th floor");

    }
    void EnteredElevator6()
    {
        Debug.Log("You selected 6th floor");

    }
    void EnteredElevator7()
    {
        Debug.Log("You selected 7th floor");
        
    }

}