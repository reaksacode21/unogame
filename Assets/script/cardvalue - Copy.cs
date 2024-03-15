

//using System.Collections;
//using UnityEngine;
//using UnityEngine.UI;

//public class RandomNumberButtonManager : MonoBehaviour
//{
//    public Button[] buttonPrefabs;
//    public GameObject canvas;
//    public Transform target;
//    private int totalSum = 0;
//    public Text sumText;
//    private Vector3[] positions = new Vector3[4];
//    public int countcard;

//    void Start()
//    {
//        positions[0] = new Vector3(-1.3f, 2f, 0);
//        positions[1] = new Vector3(1.3f, 2f, 0);
//        positions[2] = new Vector3(-1.3f, 0f, 0);
//        positions[3] = new Vector3(1.3f, 0f, 0);

//        for (int j = 0; j < 4; j++)
//        {
//            Button buttonPrefab = buttonPrefabs[j];
//           //print(buttonPrefab);

//            for (int i = 0; i < countcard; i++)
//            {
//                Vector3 position = new Vector3(i * 1f, 0, 0);
//                int index = i % 4;

//                Button button = Instantiate(buttonPrefab, positions[index], Quaternion.identity, canvas.transform);
//                int randomNumber = Random.Range(-6, 10);
//                button.GetComponentInChildren<Text>().text = randomNumber.ToString();
//                //print(button)
//                button.onClick.AddListener(() =>
//                MoveAndDestroyButton(button.transform));
//            }

//        }
//    }
//    void MoveAndDestroyButton(Transform buttonTransform)
//    {
//        Vector3 targetPosition = target.position;
//        buttonTransform.GetComponent<BubbleRotation>().isOn = true;
//        int buttonValue = int.Parse(buttonTransform.GetComponentInChildren<Text>().text);
//        totalSum += buttonValue;
//       //rint(totalSum);
//        sumText.text = totalSum.ToString();

//        StartCoroutine(MoveAndDestroyButtonCoroutine(buttonTransform, targetPosition, 2f));
//    }

//    IEnumerator MoveAndDestroyButtonCoroutine(Transform buttonTransform, Vector3 targetPosition, float duration)
//    {
//        float time = 0.1f;
//        Vector3 startPosition = buttonTransform.position;

//        while (time < duration)
//        {
//            time +=2* Time.deltaTime;
//            buttonTransform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
//            Vector3 direction = targetPosition - buttonTransform.position;

//            yield return null;
//        }

//        buttonTransform.position = targetPosition;

//        Destroy(buttonTransform.gameObject);
//    }


//}
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RandomNumberButtonManager : MonoBehaviour
{
    public Button[] buttonPrefabs;
    public GameObject canvas;
    public Transform target;
    private int totalSum = 0;
    public Text sumText,txtcountbtn;
    private Vector3[] positions = new Vector3[4];
    public int countcard;
    int totalCount, op = 0;
    public GameObject win,lost;
    public Button btnhelp, btntrash;
    public Animator fireresult;
    public void gamehepl()
    {
        btnhelp.GetComponent<Button>().image.color=Color.red;
        //btnhelp.GetComponent<Text>().text.color=Color.green;
        btnhelp.enabled = false;
        
        totalSum += 5;
        sumText.text = totalSum.ToString();
    }
    public void gametrash()
    {
        btntrash.GetComponent<Button>().image.color = Color.red;
        btntrash.enabled = false;
        totalSum =0;
        sumText.text = totalSum.ToString();
    }
    void Start()
    {
        //op = Random.Range(0, 5);
        //levelnum++;
        levelnum = PlayerPrefs.GetInt("LevelNumber", levelnum);
        txtlevel.text = "LEVEL:" + levelnum.ToString();
        fireresult.Play("idleresult");
        OutputButtonPrefab();
    }
    int intplayagain;
    public void gamePlayagain()
    {
        btntrash.GetComponent<Button>().image.color = Color.white;
        btnhelp.GetComponent<Button>().image.color = Color.white;
        btnhelp.enabled = true;
        btntrash.enabled = true;
        countcard = 0;
        totalCount = 0;
        intplayagain= op;
        if (op == 4)
        {
            op = 0;
        }
        totalSum = 0;
        sumText.text = "0";
        countcard += 4;

        if (countcard == 40)
        {
            countcard = 4;
        }
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("btnnum");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        lost.SetActive(false);
        lost.SetActive(false);

        Start();
    }
   public void RestartGame()
    {
        btntrash.GetComponent<Button>().image.color = Color.white;
        btnhelp.GetComponent<Button>().image.color = Color.white;
        btnhelp.enabled =true;
        btntrash.enabled = true;
        countcard = 0;
       totalCount = 0;
        op++;
        if (op == 4)
        {
            op=0;
        }
        totalSum = 0;
        sumText.text = "0";
        countcard += 4;
        
        if(countcard == 40)
        {
            countcard = 4;
        }
        // Destroy all buttons in the scene
        //Button[] buttons = FindObjectsOfType<Button>();
        //foreach (Button button in buttons)
        //{

        //   Destroy(button.gameObject);
        //}
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("btnnum");
        foreach (GameObject obj in objectsWithTag)
        {
            Destroy(obj);
        }
        lost.SetActive(false);
        win.SetActive(false);

        Start();
    }
    public void btnRunLevelgame()
    {
        levelnum++;
        //  PlayerPrefs.SetInt("LevelNumber", levelnum);
        saveLevel();
        txtlevel.text = "LEVEL:" + levelnum.ToString();
    }


    public void saveLevel()
    {
        PlayerPrefs.SetInt("LevelNumber", levelnum);
    }

    public Transform buttonGroup;
    void OutputButtonPrefab()
    {
        switch (op)
        {
            case 1:
                {
                    positions[0] = new Vector3(-1.3f, 1.5f, 0);
                    positions[1] = new Vector3(1.3f, 1.5f, 0);
                    positions[2] = new Vector3(-1.3f, 0f, 0);
                    positions[3] = new Vector3(1.3f, 0f, 0);
                }
                break;
            case 4:
                {
                    positions[0] = new Vector3(0f, 2.5f, 0);
                    positions[1] = new Vector3(0f, -0.7f, 0);
                    positions[2] = new Vector3(-1.3f, 1f, 0);
                    positions[3] = new Vector3(1.3f, 1f, 0);
                }
                break;
            case 0:
                {
                    positions[0] = new Vector3(-0.7f, 1.9f, 0);
                    positions[1] = new Vector3(0.7f, 1.9f, 0);
                    positions[2] = new Vector3(-1.7f, 1f, 0);
                    positions[3] = new Vector3(1.7f, 1f, 0);
                }
                break;
            case 3:
                {
                    positions[0] = new Vector3(-0.7f, 0f, 0);
                    positions[1] = new Vector3(0.7f, 0f, 0);
                    positions[2] = new Vector3(-1.4f, 0f, 0);
                    positions[3] = new Vector3(1.4f, 0f, 0);
                }
                break;
            case 2:
                {
                    positions[0] = new Vector3(-0.9f, 1f, 0);
                    positions[1] = new Vector3(0.9f, 1f, 0);
                    positions[2] = new Vector3(-1.7f, 1f, 0);
                    positions[3] = new Vector3(1.7f, 1f, 0);
                }
                break;
        }
       
        totalCount = countcard * 4;
        countntn = totalCount;
        print(totalCount);
        txtcountbtn.text= countntn.ToString();

        for (int j = 0; j < 4; j++)
        {
            Button buttonPrefab = buttonPrefabs[j];

            for (int i = 0; i < countcard; i++)
            {
                int index = (j * countcard) + i;
                Vector3 position = new Vector3(index * 1f, 0, 0);

                Button button = Instantiate(buttonPrefab, positions[j], Quaternion.identity, canvas.transform);
                button.transform.SetParent(buttonGroup.transform, true);
                // int randomNumber = Random.Range(-9,10);
                int[] excludedNumbers = { -1, -2, -3, -8, -9,0,7,5 };
                int randomNumber = GenerateRandomNumberExcluding(excludedNumbers);

                button.GetComponentInChildren<Text>().text = randomNumber.ToString();
                button.onClick.AddListener(() =>
                    MoveAndDestroyButton(button.transform));
            }
        }
    }
    int GenerateRandomNumberExcluding(int[] excludedNumbers)
    {
        int randomNumber;
        bool isValidNumber = false;

        do
        {
            randomNumber = Random.Range(-9, 10);

            isValidNumber = true;
            foreach (int excludedNumber in excludedNumbers)
            {
                if (randomNumber == excludedNumber)
                {
                    isValidNumber = false;
                    break;
                }
            }
        } while (!isValidNumber);

        return randomNumber;
    }
    void MoveAndDestroyButton(Transform buttonTransform)
    {
        FindFirstObjectByType<audioScript>().sfxsound[0].Play();

        for(int i =0; i < buttonGroup.childCount; i++)
        {
            buttonGroup.GetChild(i).GetComponent<Button>().enabled = false;
        }
        Vector3 targetPosition = target.position;
        buttonTransform.GetComponent<BubbleRotation>().isOn = true;
        int buttonValue = int.Parse(buttonTransform.GetComponentInChildren<Text>().text);
        totalSum += buttonValue;
        StartCoroutine(wait());

        if (totalSum<0 || totalSum > 21)
        {
            saveLevel();
            FindFirstObjectByType<audioScript>().sfxsound[3].Play();
            totalCount = 0;
            Debug.Log("Lose");
            StartCoroutine(waitlsoe());
           //RestartGame();
        }

        StartCoroutine(MoveAndDestroyButtonCoroutine(buttonTransform, targetPosition, 2f));
    }
    IEnumerator waitlsoe()
    {
        yield return new WaitForSeconds(1f);
        lost.SetActive(true);
    }
    IEnumerator wait()
    {
      
        yield return new WaitForSeconds(1f);
        fireresult.Play("fireresult");
        sumText.text = totalSum.ToString();
        StartCoroutine(waitanimation());
        FindFirstObjectByType<audioScript>().sfxsound[1].Play();
    }

    private int countntn;
    public Text txtlevel;
    int levelnum=1;

    IEnumerator MoveAndDestroyButtonCoroutine(Transform buttonTransform, Vector3 targetPosition, float duration)
    {
        float time = 0.1f;
        Vector3 startPosition = buttonTransform.position;
        fireresult.Play("idleresult");
        while (time < duration)
        {
            time += 2 * Time.deltaTime;
            buttonTransform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            yield return null;
        }

        buttonTransform.position = targetPosition;
        for (int i = 0; i < buttonGroup.childCount; i++)
        {
            buttonGroup.GetChild(i).GetComponent<Button>().enabled = true;
        }
        Destroy(buttonTransform.gameObject);
        yield return new WaitForSeconds(.5f);
       
        totalCount--;
        print("totalCount:" + totalCount);
        if (totalCount == 0)
        {
            if (totalSum >=0||totalCount<=21)
            {
                FindFirstObjectByType<audioScript>().sfxsound[2].Play();
                win.SetActive(true);
                totalCount = 0;
                saveLevel();

                Debug.Log("Win");
                // RestartGame();
            }
            else
            {
                
                totalCount = 0;
                Debug.Log("Lose");
            }

        }
    }
    IEnumerator waitanimation()
    {
        yield return new WaitForSeconds(0.5f);
        fireresult.Play("idleresult");
    }
}