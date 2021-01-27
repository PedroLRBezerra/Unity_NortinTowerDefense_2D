using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Waves
{
    public static int[][] GetWaves(int level){
        switch (level)
        {
            case 1:
                return GetWavesLevel01();
            break;

            case 2 :
                return GetWavesLevel02();

            default:
                return null;    
            break;
        }
        return null;
    }

    private static int[][] GetWavesLevel01(){
          int [][] enemysInWave = new int[3][];

        int[] w0 = {9,0,0,0,0,0,0,0,0,0,0};
        int[] w1 = {19,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] w2 = {30,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};

        enemysInWave[0]=w0;
        enemysInWave[1]=w1;
        enemysInWave[2]=w2;

         return enemysInWave;
    }

       private static int[][] GetWavesLevel02(){
          int [][] enemysInWave = new int[5][];

        int[] w0 = {21,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0};
        int[] w1 = {24,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0,1,0,0};
        int[] w2 = {34,0,0,0,1,0,0,0,1,0,0,0,1,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,0,0,0,0,0,1,1};
        int[] w3 = {31,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,0};
        int[] w4 = {35,1,1,1,1,1,0,0,1,1,1,0,0,1,1,1,1,1,0,0,0,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0};

        enemysInWave[0]=w0;
        enemysInWave[1]=w1;
        enemysInWave[2]=w2;
        enemysInWave[3]=w3;
        enemysInWave[4]=w4;

         return enemysInWave;
    }

    public static float [] getWavesRespawnTime(int level){
         switch (level)
        {
            case 1:
                return getWavesRespawnTimeLevel01();
            break;
            case 2:
                return getWavesRespawnTimeLevel02();
            break;

            default:
                return null;    
            break;
        }
        return null;
    }

    private static float [] getWavesRespawnTimeLevel01(){
        float [] lvl1={1.1f,0.8f,0.5f};
        return lvl1;
    }

      private static float [] getWavesRespawnTimeLevel02(){
        float [] lvl2={1.1f,0.8f,0.4f,0.4f,0.4f};
        return lvl2;
    }
}
