using UnityEngine;

public class Rocks : MonoBehaviour
{
    public GameObject[] rocks;
    public int rockCounts;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void RockFall()
    {
        rockCounts++;
    }
    public GameObject TakeRock(Transform carryObj)
    {
        rockCounts--;
        int randomRockIndex = Random.Range(0, rocks.Length);
        GameObject rock = Instantiate(rocks[randomRockIndex], carryObj.transform.position, Quaternion.identity);
        rock.transform.parent = carryObj.transform;
        rock.transform.position = carryObj.transform.position;
        return rock;
    }
}
