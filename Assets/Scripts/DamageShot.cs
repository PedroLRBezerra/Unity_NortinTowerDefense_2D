using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DamageShot : Singleton<DamageShot>
{

   private double [][] MultDmgShotEnemy ;

   void Awake (){
      this.MultDmgShotEnemy = new double[6][];
        insert();
   }

   private void insert(){
       // 0 - Basic ;; 1 -  Updated ;; 2 - Efficiency Filter ;; 3 - DubiousWebSiteAlert
       double [] Virus      = {2,1,1,1};
       double [] Spyware    = {0.5,1,3,1};
       double [] RansomWare = {1,1,1,1};
       double [] Worm       = {1,1,1,1};
       double [] AdWare     = {1,1,1,2};
       double [] Horse      = {1,3,1,1};

       this.MultDmgShotEnemy[0]=Virus;
       this.MultDmgShotEnemy[1]=Spyware;
       this.MultDmgShotEnemy[2]=RansomWare;
       this.MultDmgShotEnemy[3]=Worm;
       this.MultDmgShotEnemy[4]=AdWare;
       this.MultDmgShotEnemy[5]=Horse;
   }

   public double getMultDmg(int Enemy, int Shot){
       return  this.MultDmgShotEnemy[Enemy][Shot];
   }
}
