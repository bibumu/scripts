using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private List<GameObject> slots;
    public List<Vector3> v;
    private Vector3 currentPosition;
    private int slotNumber;
    private int direction;
    private List<int> directionList;
    private int[] possibleSlot4 = { 0, 3, 5, 6, 7, 8, 10};
    private int[] possibleSlot3 = { 0, 1, 4, 6, 7, 8, 9};
    private int[] possibleSlot2 = { 0, 1, 2, 3, 8, 9, 10};
    private int[] possibleSlot1 = {0, 2, 4, 5, 7, 9, 10};
    // Start is called before the first frame update
    void Start()
    {
        listPath();
        currentPosition = new Vector3(0f, 0f, 0f);
        StartCoroutine(generateMaze());
    }

    
    
    int getDirection() {

        directionList = new List<int>();
        directionList.Add(1);
        directionList.Add(2);
        directionList.Add(3);
        directionList.Add(4);
        switch ((slotNumber)) {
            case 0: 
                break;
            case 1:
                directionList.Remove(1);
                directionList.Remove(4);
                break;
            case 2:
                directionList.Remove(1);
                directionList.Remove(2);
                break;
            case 3:
                directionList.Remove(2);
                directionList.Remove(4);
                break;
            case 4:
                directionList.Remove(1);
                directionList.Remove(3);
                break;
            case 5:
                directionList.Remove(2);
                directionList.Remove(3);
                break;
            case 6:
                directionList.Remove(3);
                directionList.Remove(4);
                break;
            case 7:
                directionList.Remove(3);
                break;
            case 8:
                directionList.Remove(4);
                break;
            case 9:
                directionList.Remove(1);
                break;
            case 10:
                directionList.Remove(2);
                break;


            default: Debug.Log(" no case for Get Direction"); break;
        
        }





        direction = directionList[Random.Range(0,directionList.Count)];

        return direction;
    }


    Vector3 getPosition(int i)
    {
        switch (i)
        {
            case 1: 
                currentPosition.z = currentPosition.z + 5f;
                if (checkIfPositionIsInList(currentPosition)) 
                {
                    return currentPosition;
                }
                break;
            case 2:
                currentPosition.x = currentPosition.x + 5f;
                if (checkIfPositionIsInList(currentPosition))
                {
                    return currentPosition;
                }
                break;
            case 3:
                currentPosition.z = currentPosition.z - 5f;
                if (checkIfPositionIsInList(currentPosition))
                {
                    return currentPosition;
                }
                break;
            case 4:
                currentPosition.x = currentPosition.x - 5f;
                if (checkIfPositionIsInList(currentPosition))
                {
                    return currentPosition;
                }
                break;
            default: Debug.Log(" no case for Get Slot");
                break;
        }
        return currentPosition;
    }

    bool checkIfPositionIsInList(Vector3 pos) {
        for (int i = 0; i < v.Count; i++) {
            if (pos == v[i])
            { return true; }
        }
        return false;   
    }

    GameObject GetSlot(int i)
    {
        switch (i)
        {

            case 1: slotNumber = possibleSlot1[Random.Range(0, possibleSlot1.Length)]; break;
            case 2: slotNumber = possibleSlot2[Random.Range(0, possibleSlot2.Length)]; break;
            case 3: slotNumber = possibleSlot3[Random.Range(0, possibleSlot3.Length)]; break;
            case 4: slotNumber = possibleSlot4[Random.Range(0, possibleSlot4.Length)]; break;
            default: Debug.Log(" no case for Get Slot"); break;
        }
        return slots[slotNumber];
    }
    void generateSlot(int i) {

        Instantiate(GetSlot(i), getPosition(i), Quaternion.identity);

    }


    IEnumerator generateMaze()
    {
        generateSlot(getDirection());
        generateSlot(getDirection());
        yield return null;
    }

    void listPath()
    {
        float x = -15f;
        float y = 0f;
        float z = 0f;

        for (int i = 0; i < 49; i++) {
            v.Add(new Vector3(x,y,z));
            if (x < 15f) {
                x = x + 5f;
            }
            if (x == 15f)
            {
                v.Add(new Vector3(x, y, z));
                i++;
                x = -15f;
                z = z + 5f;
            }
        }
    }
    
}
