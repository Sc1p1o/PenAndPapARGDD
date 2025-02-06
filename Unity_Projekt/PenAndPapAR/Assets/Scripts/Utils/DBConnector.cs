using System;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public static class DBConnector
    {
        public static event Action OnStatsUpdated;

        private static bool _isInitialized;

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
        
        private static bool _isStrengthSavingThrowProficiency;
        private static bool _isDexteritySavingThrowProficiency;
        private static bool _isIntelligenceSavingThrowProficiency = false;
        private static bool _isConstitutionSavingThrowProficiency = false;
        private static bool _isWisdomSavingThrowProficiency = false;
        private static bool _isCharismaSavingThrowProficiency = false;

        private static bool _isAthleticsSkillProficient = false;
        private static bool _isAcrobaticsSkillProficient;
        private static bool _isArcanaSkillProficient = false;
        private static bool _isSleightOfHandSkillProficient = false;
        private static bool _isHistorySkillProficient = false;
        private static bool _isInvestigationSkillProficient = false;
        private static bool _isNatureSkillProficient = false;
        private static bool _isReligionSkillProficient = false;
        private static bool _isAnimalHandlingSkillProficient = false;
        private static bool _isInsightSkillProficient = false;
        private static bool _isMedicineSkillProficient = false;
        private static bool _isPerceptionSkillProficient = false;
        private static bool _isSurvivalSkillProficient = false;
        private static bool _isDeceptionSkillProficient = false;
        private static bool _isIntimidationSkillProficient = false;
        private static bool _isPerformanceSkillProficient = false;
        private static bool _isPersuasionSkillProficient = false;
        private static bool _isStealthSkillProficient = false;
        
        static void LoadFromDB()
        {
            //TODO DB Connection
            
            _strengthAttribute = 18;
            _dexterityAttribute = 15;
            _intelligenceAttribute = 10;
            _constitutionAttribute = 9;
            _wisdomAttribute = 10;
            _charismaAttribute = 7;
            
            _isStrengthSavingThrowProficiency = true;
            _isDexteritySavingThrowProficiency = true;
            _isAcrobaticsSkillProficient = true;
            
            _proficiencyBonus = 4;
        }
        
        public static void Initialize()
        {
            if (_isInitialized)
            {
                Debug.Log("StatsValuesDB is already initialized.");
                return;
            }
            LoadFromDB();
            _isInitialized = true; // Verhindert erneute Initialisierung
            Debug.Log("StatsValuesDB has been initialized.");
            OnStatsUpdated?.Invoke();

        }

        static void UpdateValues()
        {
            OnStatsUpdated?.Invoke();

        }
        
        public static int[] GetAttributes() => new[]
        {
            _strengthAttribute,
            _dexterityAttribute,
            _intelligenceAttribute,
            _constitutionAttribute,
            _wisdomAttribute,
            _charismaAttribute
        };

        public static bool GetIsProficiency(string proficiencyName)
        {
            switch (proficiencyName.ToLower()+"x")
            {
                case "acrobatics":
                    return _isAcrobaticsSkillProficient;
                case "athletics":
                    return _isAthleticsSkillProficient;
                case "sleight of hands":
                    return _isSleightOfHandSkillProficient;
                case "stealth":
                    return _isStealthSkillProficient;
                case "arcana":
                    return _isArcanaSkillProficient;
                case "history":
                    return _isHistorySkillProficient;
                case "investigation":
                    return _isInvestigationSkillProficient;
                case "nature":
                    return _isNatureSkillProficient;
                case "religion":
                    return _isReligionSkillProficient;
                case "animal handling":
                    return _isAnimalHandlingSkillProficient;
                case "insight":
                    return _isInsightSkillProficient;
                case "medicine":
                    return _isMedicineSkillProficient;
                case "perception":
                    return _isPerceptionSkillProficient;
                case "survival":
                    return _isSurvivalSkillProficient;
                case "deception":
                    return _isDeceptionSkillProficient;
                case "intimidation":
                    return _isIntimidationSkillProficient;
                case "performance":
                    return _isPerformanceSkillProficient;
                case "persuasion":
                    return _isPersuasionSkillProficient;

                // Saving Throws
                case "strength":
                    return _isStrengthSavingThrowProficiency;
                case "dexterity":
                    return _isDexteritySavingThrowProficiency;
                case "intelligence":
                    return _isIntelligenceSavingThrowProficiency;
                case "constitution":
                    return _isConstitutionSavingThrowProficiency;
                case "wisdom":
                    return _isWisdomSavingThrowProficiency;
                case "charisma":
                    return _isCharismaSavingThrowProficiency;

                // Standard-Fallback für ungültige Namen
                default:
                    Debug.LogWarning($"Proficiency name '{proficiencyName}' not recognized.");
                    return true;
            }
        }

        public static int GetStatValue(string statName)
        {
            switch (statName.ToLower())
            {
                case "proficiency bonus:":
                    return _proficiencyBonus;
                
                default:
                    Debug.LogWarning($"Proficiency name '{statName}' not recognized.");
                    return 0;
            }
        }
    }
}
