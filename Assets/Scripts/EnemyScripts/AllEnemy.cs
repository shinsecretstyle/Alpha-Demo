using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllEnemy : MonoBehaviour
{
    //Enemy Setting class 
    //MaxHP
    //Speed
    //ATK
    //CD

    //NormalEnemy Setting
    public static class NormalEnemy
    {

        public static int MaxHP = 12;
        public static int Speed = 90;
        public static int ATK = 2;
        public static float CD = 2f;
    }


    //MKnightEnemy Setting
    public static class MKnightEnemy
    {

        public static int MaxHP = 20;
        public static int Speed = 70;
        public static int ATK = 3;
        public static float CD = 3f;
    }


    //DestructKnightEnemy Setting
    public static class DestructKnightEnemy
    {
        public static int MaxHP = 30;
        public static int Speed = 60;
        public static int ATK = 8;
        public static float CD = 4f;
    }

    //DogEnemy Setting
    public static class DogEnemy
    {
        public static int MaxHP = 8;
        public static int Speed = 120;
        public static int ATK = 1;
        public static float CD = 1f;
    }

    //HeavyKnightEnemy Setting
    public static class HeavyKnightEnemy
    {
        public static int MaxHP = 50;
        public static int Speed = 60;
        public static int ATK = 10;
        public static float CD = 3f;
    }


    //BossEnemy Setting
    public static class BossEnemy
    {
        public static int MaxHP = 500;
        public static int Speed = 20;
        public static int ATK = 15;
        public static float CD = 4f;
    }

    //DragonEnemy Setting
    public static class DragonEnemy
    {
        public static int MaxHP = 20;
        public static int Speed = 60;
        public static int ATK = 10;
        public static float CD = 2f;
    }
}
