using UnityEngine;
using System.Collections;
using System;
//using UnityEditor;

public class Generator : MonoBehaviour
{
    public GameObject walkable, nonwalkable;
    private GameObject parent;
    private PrimeFinder primeFinder;
    private long currentSeed = 143634665068113947;
    private readonly int size = 20;
    private bool[,] board;

    // Use this for initialization
    void Start()
    {
        parent = new GameObject().gameObject;
        parent.name = "Map";
        primeFinder = new PrimeFinder();
        primeFinder.GeneratePrimesUntilIndex(10000);
        board = new bool[size + 20, size + 20];
        for (int i = 0; i < size + 20; i++)
            for (int j = 0; j < size + 20; j++)
                board[i, j] = false;
        UnityEngine.Random random = new UnityEngine.Random();
        var asd = UnityEngine.Random.Range(0.0F, 1.0F) *100000000;
        currentSeed = MakeSeed((long)asd);
        name = currentSeed.ToString();
        Room[] rooms =
            new Room[
                (int)
                (currentSeed%(double) primeFinder.GetPrimeAtIndex(4000)/primeFinder.GetPrimeAtIndex(4000)*size/2 + 4)];
        for (int i = 0; i < rooms.Length; i++)
        {
            rooms[i] = new Room();
            rooms[i].roomsize =
                (int)
                (currentSeed%(double) primeFinder.GetPrimeAtIndex(4100 + i)/primeFinder.GetPrimeAtIndex(4100 + i)*(size) +
                 4);
            rooms[i].roomwidth =
                (int)
                (currentSeed%(double) primeFinder.GetPrimeAtIndex(4200 + i)/primeFinder.GetPrimeAtIndex(4200 + i)*
                 (rooms[i].roomsize - 4) + 2);
            rooms[i].roomheigth = rooms[i].roomsize - rooms[i].roomwidth;
            rooms[i].roomx =
                (int) (currentSeed%(double) primeFinder.GetPrimeAtIndex(4300 + i)/primeFinder.GetPrimeAtIndex(4300 + i)*
                       size);
            rooms[i].roomy =
                (int) (currentSeed%(double) primeFinder.GetPrimeAtIndex(4400 + i)/primeFinder.GetPrimeAtIndex(4400 + i)*
                       size);
            //MessageBox.Show(rooms[i].roomwidth + " " + rooms[i].roomheigth + " " + rooms[i].roomx + " " +
            //              rooms[i].roomy);
        }
        foreach (Room room in rooms)
        {
            for (int i = room.roomx; i < room.roomwidth + room.roomx && i < size + 20; i++)
            {
                for (int j = room.roomy; j < room.roomheigth + room.roomy && j < size + 20; j++)
                {
                    //GameObject tile = Instantiate()
                    board[i, j] = true;
                }
            }
        }
        for (int i = -1; i < size + 20; i++)
        {
            for (int j = -1; j < size + 20; j++)
            {
                GameObject tile;
                if (i < 0 || i > size + 20 || j < 0 || j > size + 20)
                {
                    tile = Instantiate(nonwalkable, new Vector3(i, -j, 0), Quaternion.identity) as GameObject;
                    
                }
                else
                {
                    if (board[i, j])
                    {
                        tile = Instantiate(walkable, new Vector3(i, -j, 0), Quaternion.identity) as GameObject;
                    }
                    else
                    {
                        tile = Instantiate(nonwalkable, new Vector3(i, -j, 0), Quaternion.identity) as GameObject;
                    }
                }
                tile.transform.parent = parent.transform;
            }
        }
        int roomlocation = (int)
                (currentSeed % (double)primeFinder.GetPrimeAtIndex(71) / primeFinder.GetPrimeAtIndex(71) * rooms.Length);
        //rooms[roomlocation];
        GameObject character = GameObject.Find("MChar01");
        character.transform.position = new Vector3(rooms[roomlocation].roomx, -rooms[roomlocation].roomy, 0);
    }

    //Makes a more interestin seed out of the given number
    private static long MakeSeed(long seed)
    {
        if (seed < 0)
            seed -= 7 * 3468667;
        else
            seed += 7 * 3468667;
        switch (seed % 10)
        {
            //all numbers are primes, taken from: https://primes.utm.edu/lists/small/small.html#10
            case 0:
                seed *= 3367900313;
                break;
            case 1:
                seed *= 5915587277;
                break;
            case 2:
                seed *= 1500450271;
                break;
            case 3:
                seed *= 3267000013;
                break;
            case 4:
                seed *= 5754853343;
                break;
            case 5:
                seed *= 4093082899;
                break;
            case 6:
                seed *= 9576890767;
                break;
            case 7:
                seed *= 3628273133;
                break;
            case 8:
                seed *= 2860486313;
                break;
            case 9:
                seed *= 5463458053;
                break;
        }
        return seed;
    }//MakeSeed

    // Update is called once per frame
    void Update () {
	
	}
}

public class Room
{
    public int roomsize, roomwidth, roomheigth, roomx, roomy;

}
