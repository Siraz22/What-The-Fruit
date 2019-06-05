using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Spawner_new : MonoBehaviour
{
    public static Spawner_new Instance { get; set; }
    public Transform[] spawnPoints;
    public GameObject[] Fruits, Junks, SpecialFruits;
    public Multiplier multiplierscript;
    public int minPlatformNo = 1;
    public int maxPlatformNo = 3;
    int multiplier = 1;
    [Header("Debug times")]
    float CompleteRandomSpawnTimeInterval = 1.2f;
    int y = 2;




    void Start() {
        Instance = this;
        minPlatformNo = 1;
        maxPlatformNo = 3;
        multiplierscript = Multiplier.Instance.GetComponent<Multiplier>();
        //StartCoroutine(WeightedRandomSpawnSelector()) ;
    }


    void Update()
    {
        multiplier = multiplierscript.multiplier_value;
    }
    //5 platforms ke aane ke baad hi yeh system ko call krna , us se pehle random spawning hi krna
    public IEnumerator SpawninGaps(int[] platformNumbers, float timeInterval, bool AreTheJunksRandom , bool areTheFruitsRandom, int multiplierCurrent) // YEH JUNK KI BHASASD MEIN AANE WALA EK AKELA FRUIT HOGA
    {
        //instantiate everywhere except at ith platform no., spawn a goodfood at x , then after time interval, spawn everywhere except ...
        for (int i = 0; i < platformNumbers.Length; i++)
        {
            int c=0, d=0;
            //platfrom numbers is the array of number of platforms
            if (multiplier <= 3)
            {
                c = Random.Range(0, multiplier);
                d = Random.Range(0, multiplier);
            }
            if(multiplier>3)
            {
                c = Random.Range(multiplier-2 , multiplier);
                d = Random.Range(multiplier-2, multiplier);

            }
            //------------------- this is for spawning only one type of junk in pattern


            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                if (j != platformNumbers[i])
                {
                    if (AreTheJunksRandom)
                    {
                        if (multiplier <= 3)
                        {
                            GameObject var = (GameObject)Instantiate(Junks[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                            var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);
                        }
                        else
                        {
                            GameObject var = (GameObject)Instantiate(Junks[Random.Range(multiplier-2, multiplier)], spawnPoints[j].position, Quaternion.identity);
                            var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);
                        }
                      
                    }
                    if (!AreTheJunksRandom)
                    {
                        GameObject var = (GameObject) Instantiate(Junks[c], spawnPoints[j].position, Quaternion.identity);
                        var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);
                    }
                }
            }
            if (areTheFruitsRandom)
            {
                if (multiplier <= 3)
                {
                    GameObject var = (GameObject)Instantiate(Fruits[Random.Range(0, multiplier)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
                    var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);
                    
                }
                if (multiplier > 3)
                {
                    GameObject var = (GameObject)Instantiate(Fruits[Random.Range(multiplier - 2, multiplier)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
                    var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);

                }
               
            }
            if (!areTheFruitsRandom)
            {
                GameObject var = (GameObject) Instantiate(Fruits[c], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
                var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent);
            }


            yield return new WaitForSeconds(timeInterval);
        }
 
        StartCoroutine(WeightedRandomSpawnSelector());
        Debug.Log("weighted spawn selector from enumerator");
        //ab saara kaam nipat chuka hai ab doosra pattern decide karo
    }
    public IEnumerator SpawnAFruitAtPlatform(int[] platformNumbers, float timeInterval, bool areTheFruitsRandom,int multiplierCurrent)
    {

        for (int i = 0; i < platformNumbers.Length; i++)
        {
            int c=0;
            if (multiplier <= 3)
            {
                c = Random.Range(0, multiplier);
            }
            else
            {
                c = Random.Range(multiplier-2, multiplier);
            }
            //------------------- this is for spawning only one type of junk in pattern


            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                if (j == platformNumbers[i])
                {
                    if (areTheFruitsRandom)
                    {
                        Instantiate(Fruits[Random.Range(multiplier - 2, multiplier)], spawnPoints[j].position, Quaternion.identity);
                    }
                    if (!areTheFruitsRandom)
                    {
                        //it will spawn only one type of fruit throughout
                        Instantiate(Fruits[c], spawnPoints[j].position, Quaternion.identity);
                    }
                }
            }

            yield return new WaitForSeconds(timeInterval);
        }
        
        StartCoroutine(WeightedRandomSpawnSelector());
        //ab saara kaam nipat chuka hai ab doosra pattern decide karo
    }
    public IEnumerator SpawnAJunkAtPlatform(int[] platformNumbers, float timeInterval, bool areThejunksRandom, int multiplierCurrent)
    {

        for (int i = 0; i < platformNumbers.Length; i++)
        {
            int c = Random.Range(0, Junks.Length);
            //------------------- this is for spawning only one type of junk in pattern


            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                if (j == platformNumbers[i])
                {
                    if (areThejunksRandom)
                    {
                        Instantiate(Junks[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                    }
                    if (!areThejunksRandom)
                    {
                        Instantiate(Junks[c], spawnPoints[j].position, Quaternion.identity);
                    }
                }
            }
            Instantiate(Fruits[Random.Range(0, multiplier)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
            yield return new WaitForSeconds(timeInterval);
        }
       
        StartCoroutine(WeightedRandomSpawnSelector());
        //ab saara kaam nipat chuka hai ab doosra pattern decide karo
    }
    public IEnumerator SpawnRandomAtPlatform(int[] platformNumbers, float timeInterval,int multiplierCurrent)
    {

        for (int i = 0; i < platformNumbers.Length; i++)
        {

            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                if (j == platformNumbers[i])
                {
                    int a = Random.Range(1, 3);
                    if (a == 1)
                    {
                        Instantiate(Junks[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                    }
                    if (a == 2)
                    {
                        Instantiate(Fruits[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                    }
                }
            }
           // Instantiate(Fruits[Random.Range(0, Fruits.Length)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
            yield return new WaitForSeconds(timeInterval);
        }
      
        StartCoroutine(WeightedRandomSpawnSelector());
        //ab saara kaam nipat chuka hai ab doosra pattern decide karo
    }
    public IEnumerator SpawnRandomJunkAtPlatform(int[] platformNumbers, float timeInterval, int multiplierCurrent)
    {

        for (int i = 0; i < platformNumbers.Length; i++)
        {

            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                if (j == platformNumbers[i])
                {
                    int a = Random.Range(1, 3);
                    if (a == 1)
                    {
                        GameObject var = (GameObject)Instantiate(Junks[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                        var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent+6);
                    }
                    if (a == 2)
                    {
                        GameObject var = (GameObject)Instantiate(Junks[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                        var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent+6);
                    }
                }
            }
            // Instantiate(Fruits[Random.Range(0, Fruits.Length)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
            yield return new WaitForSeconds(timeInterval - 0.4f);
        }

        StartCoroutine(WeightedRandomSpawnSelector());
        //ab saara kaam nipat chuka hai ab doosra pattern decide karo
    }
    public IEnumerator SpawnBonusSpecialFruitSystem(int NoOfLayers,float timeInterval,int multiplierCurrent)
    {

        for (int i = 0; i < 7; i++)// 7 layers coming
        {

            for (int j = minPlatformNo; j <= maxPlatformNo; j++)
            {

                GameObject var = (GameObject)Instantiate(Fruits[Random.Range(0, multiplier)], spawnPoints[j].position, Quaternion.identity);
                var.GetComponent<Food_Movement>().SetSpeed(multiplierCurrent+3);
            }
            // Instantiate(Fruits[Random.Range(0, Fruits.Length)], spawnPoints[platformNumbers[i]].position, Quaternion.identity);
            yield return new WaitForSeconds(timeInterval);
        }

        yield return new WaitForSeconds(0f);
        StartCoroutine(WeightedRandomSpawnSelector());
    }


    //-----------------------    Functions to call to start ienumerators    ------------------



    public void CompleteRandomAtPlatform(float timeintervalBetweenSpawns,int multiplierCurrent)
    {
        //this will go on for 15 seconds
        int x = (int)(15 / timeintervalBetweenSpawns);
        List<int> a = new List<int>();
        for (int i = 0; i < x; i++)
        {
            a.Add(Random.Range(minPlatformNo, maxPlatformNo+1));
        }
        int[] b = a.ToArray();
        StartCoroutine(SpawnRandomAtPlatform(b, timeintervalBetweenSpawns, multiplierCurrent));

    } // this will run for 15 seconds only.
    public void CompleteRandomJunkAtPlatform(float timeintervalBetweenSpawns, int multiplierCurrent)
    {
        //this will go on for 15 seconds
        int x = (int)(15 / timeintervalBetweenSpawns);
        List<int> a = new List<int>();
        for (int i = 0; i < x; i++)
        {
            a.Add(Random.Range(minPlatformNo, maxPlatformNo + 1));
        }
        int[] b = a.ToArray();
        StartCoroutine(SpawnRandomJunkAtPlatform(b, timeintervalBetweenSpawns, multiplierCurrent));

    } // this will run for 15 seconds only.
    public void SpawnInGapsRandomJunkRandomFruit(float timeIntervalBetweenSpawns,int multiplierCurrent) // this will run for 15 seconds only.the fruits are going to be random anyways , but the junk is definable
    {
        int x = (int)(10 / timeIntervalBetweenSpawns);
        List<int> platformPoints = new List<int>();
        for (int i = 0; i < x; i++)
        {
            platformPoints.Add(Random.Range(minPlatformNo, maxPlatformNo + 1));
        }
        int[] points = platformPoints.ToArray();

        StartCoroutine(SpawninGaps(points, timeIntervalBetweenSpawns, true,true, multiplierCurrent));

    }
    public void SpawnInGapsLoopingPatternJunksArentRandomFruitsAreRandom(float timeintervalBetweenSpawns,int multiplierCurrent)
    {
        int[] forthree = {3,2,1,2,3,2,1,2};
        int[] forfive = { 0, 1, 2, 3, 4, 3, 2, 1, 0};
        if(maxPlatformNo == 3)
            StartCoroutine(SpawninGaps(forthree, timeintervalBetweenSpawns, false, true, multiplierCurrent));
        if(maxPlatformNo == 4)
            StartCoroutine(SpawninGaps(forfive, timeintervalBetweenSpawns, false, true, multiplierCurrent));
    }//15sec
    public void SpawnInGapsLoopingPatternJunksAreRandomFruitsAreNotRandom(float timeintervalBetweenSpawns,int multiplierCurrent)
    {
     
        int[] forthree = { 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1 };
        int[] forfive = { 0, 1, 2, 3, 4, 3, 2, 1, 0 };
        if (maxPlatformNo == 3)
            StartCoroutine(SpawninGaps(forthree, timeintervalBetweenSpawns, true, false, multiplierCurrent));
        if (maxPlatformNo == 4)
            StartCoroutine(SpawninGaps(forfive, timeintervalBetweenSpawns, true, false, multiplierCurrent));
    }//15sec
    public void SpawnInGapsLoopingPatternCompleteRandom(float timeintervalBetweenSpawns , int multiplierCurrent)
    {
        
        int[] forthree = { 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1 };
        int[] forfive = { 0, 1, 2, 3, 4, 3, 2, 1, 0 };
        if (maxPlatformNo == 3)
            StartCoroutine(SpawninGaps(forthree, timeintervalBetweenSpawns, true, true, multiplierCurrent));
        if (maxPlatformNo == 4)
            StartCoroutine(SpawninGaps(forfive, timeintervalBetweenSpawns, true, true, multiplierCurrent));
        
    }//15sec
    public void SpawnInGapsBadFruitsOnly(float timeintervalBetweenSpawns, int multiplierCurrent)
    {

        int[] forthree = { 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1, 2, 3, 2, 1 };
        int[] forfive = { 0, 1, 2, 3, 4, 3, 2, 1, 0 };
        if (maxPlatformNo == 3)
            StartCoroutine(SpawninGaps(forthree, timeintervalBetweenSpawns, true, true, multiplierCurrent));
        if (maxPlatformNo == 4)
            StartCoroutine(SpawninGaps(forfive, timeintervalBetweenSpawns, true, true, multiplierCurrent));

    }//15sec
    public void SpecialFruitSpawn(int noOfLayers , float timeInterval , int multipliercurrent)
    {
        StartCoroutine(SpawnBonusSpecialFruitSystem(noOfLayers, timeInterval, multipliercurrent));
    }


    // ------------------------------ Random spawn selector  --------------------


    public IEnumerator WeightedRandomSpawnSelector()
    {
        yield return new WaitForSeconds(1f);
        int multiplierCurrent = multiplierscript.multiplier_value;
        //Idhar speed change krne ka hai
        int x = Random.Range(2,11);
        // x should not be equal to 1
        if(x==1)
        {
            float time = CompleteRandomSpawnTimeInterval + (multiplier - 1) / 8;
            CompleteRandomAtPlatform(time,multiplierCurrent);
        }
        if (x >=2 && x <= 9)
        {
            float time = CompleteRandomSpawnTimeInterval + (multiplier - 1) / 8;
            SpawnInGapsRandomJunkRandomFruit((time + 0.6f), multiplierCurrent);
        }
        if (x == 10)
        {
            float time = CompleteRandomSpawnTimeInterval + (multiplier - 1) / 8;
            SpawnInGapsLoopingPatternJunksArentRandomFruitsAreRandom(time, multiplierCurrent);
        }
        if (x == 14)
        {
            SpawnInGapsLoopingPatternJunksAreRandomFruitsAreNotRandom(1f, multiplierCurrent);
        }
        if (x == 12)
        {
            SpawnInGapsLoopingPatternCompleteRandom(1f, multiplierCurrent);
        }
        if(x==13)
        {
            SpecialFruitSpawn(15, 1f, multiplierCurrent);
        }
        if (x == 11)
        {
            float time = CompleteRandomSpawnTimeInterval + (multiplier - 1) / 8;
            CompleteRandomJunkAtPlatform(time, multiplierCurrent);
        }

        yield return null;
    }   // the weighting will be done later

    public void RANDOMSPAWNSELECTOR()
    {
        StartCoroutine("WeightedRandomSpawnSelector");
    }
    
}
