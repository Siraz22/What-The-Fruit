using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
	public static Spawnner Instance {get;set;}
    Multiplier multiplier_script;
	public float Speed=2;
    private int prev_pos = -1;
    private int Number_To_Check;
    Special_Spawns Special_Spawnscript;
	public float intervalBTWSpawns=2f;

    private float countdown = 0f;

	public GameObject[] FruitsAndFasts;
	public Transform[] Spawn_Points;

	private Transform End_Point;
	private float min_time = 1f;
	private float max_time = 2f;

    //public GameObject Player_ref;

    private int Spawn_Num;
    public int Topmost_spawn_number=1;
    public int Lowest_spawn_number=3;

    public void ResetPlatforms()
    {


        if(Topmost_spawn_number!=1&&Lowest_spawn_number!=3)
        {
            Topmost_spawn_number = 1;
            Lowest_spawn_number = 3;
        }
    }

	void Awake()
	{
        multiplier_script = GameObject.FindObjectOfType<Multiplier>();
		Instance = this;
        Special_Spawnscript = GameObject.FindObjectOfType<Special_Spawns>();
		End_Point = GameObject.FindGameObjectWithTag ("End_Point").GetComponent<Transform> ();
	}

	// Use this for initialization
	void Start ()
	{
		StartCoroutine ("RandomSpawn");
	}

    /*
	IEnumerator RandomSpawn()
	{
        //alternately spwns good and bad food
        Spawn_Num = Random.Range(1,2);

        while (true) 
		{
			yield return new WaitForSeconds (Random.Range(min_time,max_time));

            int pos3 = Random.Range(Topmost_spawn_number, Lowest_spawn_number);
            int pos1 = Random.Range(Topmost_spawn_number, Lowest_spawn_number);
            int pos2 = Random.Range(Topmost_spawn_number, Lowest_spawn_number);

            if (Spawn_Num == 1 && pos1!=pos2)
            {
                Instantiate(FruitsAndFasts[Random.Range(0, 7)], Spawn_Points[pos1].position, Spawn_Points[2].rotation);
                Instantiate(FruitsAndFasts[Random.Range(8, 14)], Spawn_Points[pos2].position, Spawn_Points[2].rotation);


                if (multiplier_script.multiplier > 2 && pos3 != pos1 && pos3!= pos2 )
                {
                    Instantiate(FruitsAndFasts[Random.Range(0, 7)], Spawn_Points[pos3].position, Spawn_Points[2].rotation);
                }

                Spawn_Num = 2;
            }
            else if(Spawn_Num ==2 && pos1 != pos2)
            {
                Instantiate(FruitsAndFasts[Random.Range(0, 7)], Spawn_Points[pos1].position, Spawn_Points[2].rotation);
                Instantiate(FruitsAndFasts[Random.Range(8, 14)], Spawn_Points[pos2].position, Spawn_Points[2].rotation);

                if (multiplier_script.multiplier > 2 && pos3 != pos1 && pos3 != pos2)
                {
                    Instantiate(FruitsAndFasts[Random.Range(0, 7)], Spawn_Points[pos3].position, Spawn_Points[2].rotation);
                }

                Spawn_Num = 1;
            }

        }
        // wait for seconds ke baad
    }
    */

    IEnumerator RandomSpawn()
    {

        while (true)
        {

            // yield return new WaitForSeconds(Random.Range(min_time, max_time));
			yield return new WaitForSeconds(intervalBTWSpawns);

            int fruit_pos = Random.Range(Topmost_spawn_number, Lowest_spawn_number+1);
            
          
            if(fruit_pos==prev_pos)
            {
                //Debug.Log("Got Same position,");
                while(fruit_pos==prev_pos)
                {
                    //Debug.Log("Flipping");
                    fruit_pos = Random.Range(Topmost_spawn_number, Lowest_spawn_number);
                }
              //  Debug.Log("Got it!");
            }
            
            
                
                for (int i = Topmost_spawn_number; i <= Lowest_spawn_number; ++i)
                {
                    if (i != fruit_pos)
                    {       
                        Instantiate(FruitsAndFasts[Random.Range(0, 7)], Spawn_Points[i].position, Spawn_Points[2].rotation);
                    }
                    else
                        Instantiate(FruitsAndFasts[Random.Range(8, 14)], Spawn_Points[i].position, Spawn_Points[2].rotation);
                }
                prev_pos = fruit_pos;
                
            // wait for seconds ke baad
        }
    }

    // Update is called once per frame
    void Update () 
	{
        countdown += Time.deltaTime;

        if(countdown>=30f)
        {
            Number_To_Check = Random.Range(50, 70);
            StopCoroutine("RandomSpawn");
            Special_Spawnscript.Check_Which_Special_CouroutineToStart(Number_To_Check);
            countdown = 0f;
        }
        
	}
}