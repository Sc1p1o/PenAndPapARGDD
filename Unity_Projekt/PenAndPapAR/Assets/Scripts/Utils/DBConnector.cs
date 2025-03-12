using System;
using System.Collections.Generic;
using GlobalEnums;
using UnityEngine;
using UnityEngine.UI;

namespace Utils
{
    public class DBConnector : MonoBehaviour
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
        
        private static int _initiative;

        private static int _speed;

        private static int _healthpointsMax;
        private static int _healthpointsTemporary;
        private static int _healthpointsCurrent;
        private static int _nonLethalDamage;

        private static int _baseAc;

        private static int _baseLevel;

        private static int _exhaustionLevel;

        private static string _characterName;
        private static string _characterRace;
        private static string _characterClass;
        private static string _characterGender;
        private static string _characterSubClass;
        private static int _characterLevel;
        private static string _characterBackground;
        private static string _characterAlignment;
        
        // Saving Throw Proficiencies
        private static bool _isStrengthSavingThrowProficiency;
        private static bool _isDexteritySavingThrowProficiency;
        private static bool _isIntelligenceSavingThrowProficiency;
        private static bool _isConstitutionSavingThrowProficiency;
        private static bool _isWisdomSavingThrowProficiency;
        private static bool _isCharismaSavingThrowProficiency;

        private static bool _isAthleticsSkillProficient;
        private static bool _isAcrobaticsSkillProficient;
        private static bool _isArcanaSkillProficient;
        private static bool _isSleightOfHandSkillProficient;
        private static bool _isHistorySkillProficient;
        private static bool _isInvestigationSkillProficient;
        private static bool _isNatureSkillProficient;
        private static bool _isReligionSkillProficient;
        private static bool _isAnimalHandlingSkillProficient;
        private static bool _isInsightSkillProficient;
        private static bool _isMedicineSkillProficient;
        private static bool _isPerceptionSkillProficient;
        private static bool _isSurvivalSkillProficient;
        private static bool _isDeceptionSkillProficient;
        private static bool _isIntimidationSkillProficient;
        private static bool _isPerformanceSkillProficient;
        private static bool _isPersuasionSkillProficient;
        private static bool _isStealthSkillProficient;
        
        // Armor Proficiencies
        private static bool _isLightArmorProficient = true;
        private static bool _isMediumArmorProficient = true;
        private static bool _isHeavyArmorProficient = true;
        private static bool _isShieldProficient = true;
        
        // Weapons Proficiencies
        private static bool _isSimpleWeaponsProficient = true;
        private static bool _isMartialWeaponsProficient = true;
        private static bool _isImprovisedWeaponProficient = true;
        
        private static int _deathSaveSuccesses;
        private static int _deathSaveFailures;
        
        private static List<Condition> _conditions = new List<Condition>();
        
        static void LoadFromDB()
        {
            //TODO DB Connection

            Debug.Log("Loading from DB");
            /**
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
            
            _exhaustionLevel = 4;
            
            _deathSaveSuccesses = 0;
            _deathSaveFailures = 0;
            _speed = 30;

            _healthpointsTemporary = 10;
            _healthpointsCurrent = 60;
            _healthpointsMax = 70;
            _nonLethalDamage = 0;

            _baseAc = 10;

            _initiative = 2;
            
            _characterName = "Test";
            _characterRace = "Drow";
            _characterClass = "Sorcerer";
            _characterGender = "Female";
            
            _characterSubClass = "Draconic";
            
            _characterAlignment = "Chaotic Evil";
            _characterBackground = "Acolyte";
            
            _characterLevel = 11;
            
            _characterName = "Faelyndiira";

            _conditions.Add(Condition.Frightened);
            _conditions.Add(Condition.Grappled);
            */

        }
        
        public static void Initialize()
        {
            if (_isInitialized)
            {
                Debug.Log("StatsValuesDB is already initialized.");
                return;
            }
            _isInitialized = true;
            Debug.Log("StatsValuesDB has been initialized.");
            

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
            switch (proficiencyName.ToLower())
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
                
                // Armor Proficiencies
                case "light":
                    return _isLightArmorProficient;
                case "medium":
                    return _isMediumArmorProficient;
                case "heavy":
                    return _isHeavyArmorProficient;
                case "shield":
                    return _isShieldProficient;
                
                // Weapon Proficiencies
                case "simple":
                    return _isSimpleWeaponsProficient;
                case "martial":
                    return _isMartialWeaponsProficient;
                case "improvised":
                    return _isImprovisedWeaponProficient;
                    
                // Standard-Fallback für ungültige Namen
                default:
                    Debug.LogWarning($"Proficiency name '{proficiencyName}' not recognized.");
                    return false;
            }
        }

        public static int GetStatValue(string statName)
        {
            switch (statName.ToLower())
            {
                case "strength_attribute":
                    return _strengthAttribute;
                case "dexterity_attribute":
                    return _dexterityAttribute;
                case "intelligence_attribute":
                    return _intelligenceAttribute;
                case "constitution_attribute":
                    return _constitutionAttribute;
                case "wisdom_attribute":
                    return _wisdomAttribute;
                case "charisma_attribute":
                    return _charismaAttribute;
                
                
                case "proficiency bonus:":
                    return _proficiencyBonus;
                case "exhaustion":
                    return _exhaustionLevel;
                case "failed death saves":
                    return _deathSaveFailures;
                case "succeeded death saves":
                    return _deathSaveSuccesses;
                case "speed":
                    return _speed;
                case "temporal hp":
                    return _healthpointsTemporary;
                case "current hp":
                    return _healthpointsCurrent;
                case "max health":
                    return _healthpointsMax;
                case "non lethal dmg":
                    return _nonLethalDamage;
                case "armor class":
                    return _baseAc;
                case "initiative":
                    return _initiative;
                case "level":
                    return _characterLevel;
                
                default:
                    Debug.LogWarning($"Proficiency name '{statName}' not recognized.");
                    return 0;
            }
        }

        public static string GetStatString(string statName)
        {
            switch (statName.ToLower())
            {
                case "charactername":
                    return _characterName;
                case "characterrace":
                    return _characterRace;
                case "characterclass":
                    return _characterClass;
                case "charactergender":
                    return _characterGender;
                case "subclass":
                    return _characterSubClass;
                case "characteralignment":
                    return _characterAlignment;
                case "characterbackground":
                    return _characterBackground;
                
                default:
                    Debug.LogWarning($"Proficiency name '{statName}' not recognized.");
                    return "";
            }
        }
        
        public static List<Condition> GetConditions() => _conditions;
        
        public static bool RemoveCondition(string conditionName)
        {
            Enum.TryParse(conditionName, out Condition conditionEnum);

            if (_conditions.Remove(conditionEnum))
            {
                Debug.Log($"Condition {conditionEnum} successfully removed.");
                return true;
            }

            Debug.LogWarning($"Condition {conditionEnum} not found.");
            return false;
        }

        public static bool SetIntValue(string statName, int value)
        {
            switch (statName.ToLower())
            {
                case "proficiency bonus:":
                    _proficiencyBonus = value;
                    return true;
                case "exhaustion":
                    _exhaustionLevel = value;
                    return true;
                case "failed death saves":
                    _deathSaveFailures = value;
                    return true;
                case "succeeded death saves":
                    _deathSaveSuccesses = value;
                    return true;
                case "speed":
                    _speed = value;
                    return true;
                case "temporal hp":
                    _healthpointsTemporary = value;
                    return true;
                case "current hp":
                    _healthpointsCurrent = value;
                    return true;
                case "max health":
                    _healthpointsMax = value;
                    return true;
                case "non lethal dmg":
                    _nonLethalDamage = value;
                    return true;
                case "armor class":
                    _baseAc = value;
                    return true;
                case "initiative":
                    _initiative = value;
                    return true;
                case "level":
                    _characterLevel = value;
                    return true;
                
                case "strength_attribute":
                    _strengthAttribute = value;
                    return true;
                case "dexterity_attribute":
                    _dexterityAttribute = value;
                    return true;
                case "intelligence_attribute":
                    _intelligenceAttribute = value;
                    return true;
                case "constitution_attribute":
                    _constitutionAttribute = value;
                    return true;
                case "wisdom_attribute":
                    _wisdomAttribute = value;
                    return true;
                case "charisma_attribute":
                    _charismaAttribute = value;
                    return true;
                
                default:
                    Debug.LogWarning($"{statName} is not a valid stat.");
                    return false;
            }
        }

        public static bool SetBoolValue(string statName, bool value)
        {
            switch (statName.ToLower())
            {
                case "acrobatics":
                    _isAcrobaticsSkillProficient = value;
                    return true;
                case "athletics":
                    _isAthleticsSkillProficient = value;
                    return true;
                case "sleight of hands":
                    _isSleightOfHandSkillProficient = value;
                    return true;
                case "stealth":
                    _isStealthSkillProficient = value;
                    return true;
                case "arcana":
                    _isArcanaSkillProficient = value;
                    return true;
                case "history":
                    _isHistorySkillProficient = value;
                    return true;
                case "investigation":
                    _isInvestigationSkillProficient = value;
                    return true;
                case "nature":
                    _isNatureSkillProficient = value;
                    return true;
                case "religion":
                    _isReligionSkillProficient = value;
                    return true;
                case "animal handling":
                    _isAnimalHandlingSkillProficient = value;
                    return true;
                case "insight":
                    _isInsightSkillProficient = value;
                    return true;
                case "medicine":
                    _isMedicineSkillProficient = value;
                    return true;
                case "perception":
                    _isPerceptionSkillProficient = value;
                    return true;
                case "survival":
                    _isSurvivalSkillProficient = value;
                    return true;
                case "deception":
                    _isDeceptionSkillProficient = value;
                    return true;
                case "intimidation":
                    _isIntimidationSkillProficient = value;
                    return true;
                case "performance":
                    _isPerformanceSkillProficient = value;
                    return true;
                case "persuasion":
                    _isPersuasionSkillProficient = value;
                    return true;

                // Saving Throws
                case "strength":
                    _isStrengthSavingThrowProficiency = value;
                    return true;
                case "dexterity":
                    _isDexteritySavingThrowProficiency = value;
                    return true;
                case "intelligence":
                    _isIntelligenceSavingThrowProficiency = value;
                    return true;
                case "constitution":
                    _isConstitutionSavingThrowProficiency = value;
                    return true;
                case "wisdom":
                    _isWisdomSavingThrowProficiency = value;
                    return true;
                case "charisma":
                    _isCharismaSavingThrowProficiency = value;
                    return true;

                // Armor Proficiencies
                case "light":
                    _isLightArmorProficient = value;
                    return true;
                case "medium":
                    _isMediumArmorProficient = value;
                    return true;
                case "heavy":
                    _isHeavyArmorProficient = value;
                    return true;
                case "shield":
                    _isShieldProficient = value;
                    return true;

                // Weapon Proficiencies
                case "simple":
                    _isSimpleWeaponsProficient = value;
                    return true;
                case "martial":
                    _isMartialWeaponsProficient = value;
                    return true;
                case "improvised":
                    _isImprovisedWeaponProficient = value;
                    return true;
                
                default:
                    Debug.LogWarning($"{statName} is not a valid Proficiency.");
                    return false;
            }
        }

        public static void UpdateValues()
        {
            Debug.Log("Update Triggered");
            OnStatsUpdated?.Invoke();
        }
    }
}
