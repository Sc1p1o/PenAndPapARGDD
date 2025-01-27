using UnityEngine;

namespace Utils
{
    public static class StatsValuesDB
    {
        private static int _strengthAttribute;
        private static int _dexterityAttribute;
        private static int _intelligenceAttribute;
        private static int _constitutionAttribute;
        private static int _wisdomAttribute;
        private static int _charismaAttribute;

        private static int _proficiencyBonus;

        private static int _speed;

        private static int _healthpointsMax;
        private static int _healthpointsTemporary;
        private static int _healthpointsCurrent;
        private static int _nonLethalDamage;

        private static int _baseAc;

        private static int _baseLevel;

        private static string _characterName;
        private static string _characterRace;
        private static string _characterClass;
        private static string _characterGender;
        private static string _characterSubClass;
        
        
        static void LoadFromDB()
        {
            //TODO DB Connection
            
            _strengthAttribute = 13;
            _dexterityAttribute = 15;
            _intelligenceAttribute = 10;
            _constitutionAttribute = 12;
            _wisdomAttribute = 10;
            _charismaAttribute = 10;
            
            _proficiencyBonus = 2;
            _speed = 30;
            _healthpointsMax = 100;
            _healthpointsTemporary = 0;
            _healthpointsCurrent = 100;
            _nonLethalDamage = 1;
            _baseAc = 10;
            _baseLevel = 5;
            
            _characterName = "Faelyndiira Nirinath";
            _characterRace = "Drow";
            _characterClass = "Sorcerer";
            _characterGender = "Female";
            _characterSubClass = "Draconic";
        }
        static void UpdateValues()
        {
            
        }
    }
}
