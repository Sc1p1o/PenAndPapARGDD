using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using GlobalEnums;
using UnityEngine;
using UnityEngine.Networking;
using Newtonsoft.Json;
using UnityEditor.Rendering;
using Utils.DB_Classes;
using Attribute = Utils.DB_Classes.Attribute;

namespace Utils
{
    public class DBConnector : MonoBehaviour
    {
        private static readonly string[] attribute_strings =
        {
            "strength", "dexterity", "constitution", "intelligence", "wisdom", "charisma"
        };

        private static string[] skill_strings =
        {
            "athletics", "acrobatics", "arcana", "sleight_of_hand", "history", "investigation", "nature", "religion",
            "animal_handling", "insight", "medicine", "perception", "survival", "deception", "intimidation", "performance",
            "persuasion"
        };
        
        public static event Action OnStatsUpdated;
        
        private static string _url = "http://127.0.0.1:8000/api/stats/?character_id=%230000";

        private static bool _isInitialized;
        
        private static bool _savingToDB;
        
        
        // Stats
        private static string _characterId;
        private static bool _isInspired;
        private static string _characterName;
        private static string _characterClass;
        private static string _characterRace;
        private static string _characterBackground;
        private static string _characterSubClass;
        private static int _baseLevel;
        private static string _characterAlignment;
        private static List<Condition> _conditions = new List<Condition>();
        private static string _characterLink;
        private static int _proficiencyBonus;
        
        
        private static int _speed;
        private static int _initiativeAdjustment;
        private static int _proficiencyBonusAdjustment;
        private static int _exhaustionLevel;
        private static int _deathSaveSuccesses;
        private static int _deathSaveFailures;
        private static string _characterGender;
        
        
        // Attributes
        private static int _strengthAttribute;
        private static int _strengthAttributeAdjustment;
        private static int _dexterityAttribute;
        private static int _dexterityAttributeAdjustment;
        private static int _intelligenceAttribute;
        private static int _intelligenceAttributeAdjustment;
        private static int _constitutionAttribute;
        private static int _constitutionAttributeAdjustment;
        private static int _wisdomAttribute;
        private static int _wisdomAttributeAdjustment;
        private static int _charismaAttribute;
        private static int _charismaAttributeAdjustment;
        
        // AC
        private static int _baseAc;
        private static int _acAdjustment;

        // Health Points
        private static int _healthpointsMax;
        private static int _healthpointsTemporary;
        private static int _healthpointsCurrent;
        private static int _nonLethalDamage;
        
        // Saving Throw Proficiencies
        private static bool _isStrengthSavingThrowProficiency;
        private static int _strengthSavingThrowAdjustment;
        private static bool _isDexteritySavingThrowProficiency;
        private static int _dexteritySavingThrowAdjustment;
        private static bool _isIntelligenceSavingThrowProficiency;
        private static int _intelligenceSavingThrowAdjustment;
        private static bool _isConstitutionSavingThrowProficiency;
        private static int _constitutionSavingThrowAdjustment;
        private static bool _isWisdomSavingThrowProficiency;
        private static int _wisdomSavingThrowAdjustment;
        private static bool _isCharismaSavingThrowProficiency;
        private static int _charismaSavingThrowAdjustment;
        
        // Skills
        private static bool _isAthleticsSkillProficient;
        private static bool _isAthleticsSkillExpertise;
        private static int _athleticsSkillAdjustment;
        
        private static bool _isAcrobaticsSkillProficient;
        private static bool _isAcrobaticsSkillExpertise;
        private static int _acrobaticsSkillAdjustment;
        
        private static bool _isArcanaSkillProficient;
        private static bool _isArcanaSkillExpertise;
        private static int _arcanaSkillAdjustment;
        
        private static bool _isSleightOfHandSkillProficient;
        private static bool _isSleightOfHandSkillExpertise;
        private static int _sleightOfHandSkillAdjustment;
        
        private static bool _isHistorySkillProficient;
        private static bool _isHistorySkillExpertise;
        private static int _historySkillAdjustment;
        
        private static bool _isInvestigationSkillProficient;
        private static bool _isInvestigationSkillExpertise;
        private static int _investigationSkillAdjustment;
        
        private static bool _isNatureSkillProficient;
        private static bool _isNatureSkillExpertise;
        private static int _natureSkillAdjustment;
        
        private static bool _isReligionSkillProficient;
        private static bool _isReligionSkillExpertise;
        private static int _religionSkillAdjustment;
        
        private static bool _isAnimalHandlingSkillProficient;
        private static bool _isAnimalHandlingSkillExpertise;
        private static int _animalHandlingSkillAdjustment;
        
        private static bool _isInsightSkillProficient;
        private static bool _isInsightSkillExpertise;
        private static int _insightSkillAdjustment;
        
        private static bool _isMedicineSkillProficient;
        private static bool _isMedicineSkillExpertise;
        private static int _medicineSkillAdjustment;
        
        private static bool _isPerceptionSkillProficient;
        private static bool _isPerceptionSkillExpertise;
        private static int _perceptionSkillAdjustment;
        
        private static bool _isSurvivalSkillProficient;
        private static bool _isSurvivalSkillExpertise;
        private static int _survivalSkillAdjustment;
        
        private static bool _isDeceptionSkillProficient;
        private static bool _isDeceptionSkillExpertise;
        private static int _deceptionSkillAdjustment;
        
        private static bool _isIntimidationSkillProficient;
        private static bool _isIntimidationSkillExpertise;
        private static int _intimidationSkillAdjustment;
        
        private static bool _isPerformanceSkillProficient;
        private static bool _isPerformanceSkillExpertise;
        private static int _performanceSkillAdjustment;
        
        private static bool _isPersuasionSkillProficient;
        private static bool _isPersuasionSkillExpertise;
        private static int _persuasionSkillAdjustment;
        
        private static bool _isStealthSkillProficient;
        private static bool _isStealthSkillExpertise;
        private static int _stealthSkillAdjustment;
        
        // Armor Proficiencies
        private static bool _isLightArmorProficient;
        private static bool _isMediumArmorProficient;
        private static bool _isHeavyArmorProficient;
        private static bool _isShieldProficient;
        
        // Weapons Proficiencies
        private static bool _isSimpleWeaponsProficient;
        private static bool _isMartialWeaponsProficient;
        private static bool _isImprovisedWeaponProficient;
        
        private IEnumerator LoadFromDB()
        {
            //TODO DB Connection

            Debug.Log("Loading from DB");
            
            UnityWebRequest request = UnityWebRequest.Get(_url);
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful");
                string jsonRequest = request.downloadHandler.text;
                
                var data = JsonConvert.DeserializeObject<Root>(jsonRequest);
                if (data != null && data.attributes != null)
                {
                    // Zugriff auf die Statistiken
                    ConnectDataFromDB(data);
                }
            }
            else
            {
                Debug.Log("Request failed");
            }
            
            Debug.Log("Loading from DB finished");

        }

        private void ConnectDataFromDB(Root data)
        {
            SetStats(data.stats[0]);
            SetAttributes(data.attributes);
            SetAc(data.ac[0]);
            SetSavingThrows(data.savingThrowProficiencies);
            SetSkills(data.skills);
            SetHitPoints(data.hitPoints[0]);
            
            OnStatsUpdated?.Invoke();
        }

        public static void LoadCharacterData(string characterId)
        {
            OnStatsUpdated?.Invoke();
        }

        private static void SetStats(Stat stats)
        {
            _characterId = stats.characterId;
            _characterName = stats.characterName;
            _isInspired = stats.characterIsInspired;
            _characterClass = stats.characterClass;
            _characterRace = stats.characterRace;
            _characterBackground = stats.characterBackground;
            _characterSubClass = stats.characterSubclass;
            _baseLevel = stats.characterLevel;
            _characterAlignment = stats.characterAlignment;
            _conditions = ExtractConditions(stats.characterConditions);
            _characterLink = stats.characterUpdateLink;
            _proficiencyBonus = stats.characterProficiencyBonus;
            
            _initiativeAdjustment = stats.initiativeAdjustment;
            _speed = stats.characterSpeed;
            _proficiencyBonusAdjustment = stats.characterProficiencyBonusAdjustment;
            _deathSaveFailures = stats.characterDeathSaveFailed;
            _deathSaveSuccesses = stats.characterDeathSaveSuccess;
            _exhaustionLevel = stats.characterExhaustion;
            _characterGender = stats.characterGender;
        }

        private void SetAttributes(List<Attribute> attributes)
        {
            foreach (var attribute in attributes)
            {
                SetIntValue(attribute.attributeName + "_attribute", attribute.attributeValue);
                SetIntValue(attribute.attributeName + "_attribute_adjustment", attribute.attributeAdjustment);
            }
        }

        private void SetAc(Ac acData)
        {
            _baseAc = acData.acBase;
            _acAdjustment = acData.acModifier;
        }

        private void SetSavingThrows(List<SavingThrowProficiencies> savingThrowList)
        {
            foreach (var savingThrow in savingThrowList)
            {
                SetBoolValue(savingThrow.savingThrowName, savingThrow.savingThrowIsProficient);
                SetIntValue(savingThrow.savingThrowName + "_save_adjustment", savingThrow.savingThrowAdjustment);
            }
        }

        private void SetSkills(List<Skills> skillList)
        {
            foreach (var skill in skillList)
            {   
                SetBoolValue(skill.skillName, skill.skillIsProficient);
                SetBoolValue(skill.skillName + " expertise", skill.skillIsExpertise);
            }
        }

        private void SetHitPoints(HitPoints hitPointData)
        {
            _healthpointsMax = hitPointData.maximum;
            _healthpointsCurrent = hitPointData.current;
            _healthpointsTemporary = hitPointData.temporary;
            _nonLethalDamage = hitPointData.nonLethalDamage;
        }

        private static List<Condition> ExtractConditions(string conditions)
        {
            if (string.IsNullOrEmpty(conditions)) return null;
            
            List<Condition> conditionList = new List<Condition>();
            List<string> conditionStrings = conditions.Split(',').ToList();
            
            foreach (string conditionString in conditionStrings)
            {
                Enum.TryParse(conditionString, out Condition conditionEnum);
                conditionList.Add(conditionEnum);
            }
            
            return conditionList;
        }
        
        public void Initialize()
        {
            if (_isInitialized)
            {
                Debug.Log("StatsValuesDB is already initialized.");
                return;
            }
            _isInitialized = true;
            Debug.Log("StatsValuesDB has been initialized.");
            OnStatsUpdated += SyncWithDB;

            StartCoroutine(LoadFromDB());

        }

        public static bool GetIsProficiency(string proficiencyName)
        {
            proficiencyName = proficiencyName.Replace("_", " ");
            switch (proficiencyName.ToLower())
            {
                case "acrobatics":
                    return _isAcrobaticsSkillProficient;
                case "athletics":
                    return _isAthleticsSkillProficient;
                case "sleight of hands":
                    return _isSleightOfHandSkillProficient;
                case "sleight of hand":
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
            statName = statName.Replace("_", " ");
            switch (statName.ToLower())
            {
                case "strength attribute":
                    return _strengthAttribute + _strengthAttributeAdjustment;
                case "dexterity attribute":
                    return _dexterityAttribute + _dexterityAttributeAdjustment;
                case "intelligence attribute":
                    return _intelligenceAttribute + _intelligenceAttributeAdjustment;
                case "constitution attribute":
                    return _constitutionAttribute + _constitutionAttributeAdjustment;
                case "wisdom attribute":
                    return _wisdomAttribute + _wisdomAttributeAdjustment;
                case "charisma attribute":
                    return _charismaAttribute + _charismaAttributeAdjustment;
                
                
                case "proficiency bonus:":
                    return _proficiencyBonus + _proficiencyBonusAdjustment;
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
                    return _baseAc + _acAdjustment;
                case "initiative":
                    return _dexterityAttribute + _initiativeAdjustment + _dexterityAttributeAdjustment;
                case "level":
                    return _baseLevel;
                
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
                    _initiativeAdjustment = value;
                    return true;
                case "level":
                    _baseLevel = value;
                    return true;
                
                // Set Attribute Values
                case "strength_attribute":
                    _strengthAttribute = value;
                    return true;
                case "strength_attribute_adjustment":
                    _strengthAttributeAdjustment = value;
                    return true;
                case "strength_save_adjustment":
                    _strengthSavingThrowAdjustment = value;
                    return true;
                
                case "dexterity_attribute":
                    _dexterityAttribute = value;
                    return true;
                case "dexterity_attribute_adjustment":
                    _dexterityAttributeAdjustment = value;
                    return true;
                case "dexterity_save_adjustment":
                    _dexteritySavingThrowAdjustment = value;
                    return true;
                
                case "intelligence_attribute":
                    _intelligenceAttribute = value;
                    return true;
                case "intelligence_attribute_adjustment":
                    _intelligenceAttributeAdjustment = value;
                    return true;
                case "intelligence_save_adjustment":
                    _intelligenceSavingThrowAdjustment = value;
                    return true;
                
                case "constitution_attribute":
                    _constitutionAttribute = value;
                    return true;
                case "constitution_attribute_adjustment":
                    _constitutionAttributeAdjustment = value;
                    return true;
                case "constitution_save_adjustment":
                    _constitutionSavingThrowAdjustment = value;
                    return true;
                
                case "wisdom_attribute":
                    _wisdomAttribute = value;
                    return true;
                case "wisdom_attribute_adjustment":
                    _wisdomAttributeAdjustment = value;
                    return true;
                case "wisdom_save_adjustment":
                    _wisdomSavingThrowAdjustment = value;
                    return true;
                
                case "charisma_attribute":
                    _charismaAttribute = value;
                    return true;
                case "charisma_attribute_adjustment":
                    _charismaAttributeAdjustment = value;
                    return true;
                case "charisma_save_adjustment":
                    _charismaSavingThrowAdjustment = value;
                    return true;
                
                default:
                    Debug.LogWarning($"{statName} is not a valid stat.");
                    return false;
            }
        }

        public static bool SetBoolValue(string statName, bool value)
        {
            statName = statName.Replace("_", " ");
            switch (statName.ToLower())
            {
                case "acrobatics":
                    _isAcrobaticsSkillProficient = value;
                    return true;
                case "acrobatics expertise":
                    _isAcrobaticsSkillExpertise = value;
                    return true;
                
                case "athletics":
                    _isAthleticsSkillProficient = value;
                    return true;
                case "athletics expertise":
                    _isAthleticsSkillExpertise = value;
                    return true;
                
                case "sleight of hands":
                    _isSleightOfHandSkillProficient = value;
                    return true;
                case "sleight of hands expertise":
                    _isSleightOfHandSkillExpertise = value;
                    return true;
                
                case "sleight of hand":
                    _isSleightOfHandSkillProficient = value;
                    return true;
                case "sleight of hand expertise":
                    _isSleightOfHandSkillExpertise = value;
                    return true;
                
                case "stealth":
                    _isStealthSkillProficient = value;
                    return true;
                case "stealth expertise":
                    _isStealthSkillExpertise = value;
                    return true;
                
                case "arcana":
                    _isArcanaSkillProficient = value;
                    return true;
                case "arcana expertise":
                    _isArcanaSkillExpertise = value;
                    return true;
                
                case "history":
                    _isHistorySkillProficient = value;
                    return true;
                case "history expertise":
                    _isHistorySkillExpertise = value;
                    return true;
                
                case "investigation":
                    _isInvestigationSkillProficient = value;
                    return true;
                case "investigation expertise":
                    _isInvestigationSkillExpertise = value;
                    return true;
                
                case "nature":
                    _isNatureSkillProficient = value;
                    return true;
                case "nature expertise":
                    _isNatureSkillExpertise = value;
                    return true;
                
                case "religion":
                    _isReligionSkillProficient = value;
                    return true;
                case "religion expertise":
                    _isReligionSkillExpertise = value;
                    return true;
                
                case "animal handling":
                    _isAnimalHandlingSkillProficient = value;
                    return true;
                case "animal handling expertise":
                    _isAnimalHandlingSkillExpertise = value;
                    return true;
                
                case "insight":
                    _isInsightSkillProficient = value;
                    return true;
                case "insight expertise":
                    _isInsightSkillExpertise = value;
                    return true;
                
                case "medicine":
                    _isMedicineSkillProficient = value;
                    return true;
                case "medicine expertise":
                    _isMedicineSkillExpertise = value;
                    return true;
                
                case "perception":
                    _isPerceptionSkillProficient = value;
                    return true;
                case "perception expertise":
                    _isPerceptionSkillExpertise = value;
                    return true;
                
                case "survival":
                    _isSurvivalSkillProficient = value;
                    return true;
                case "survival expertise":
                    _isSurvivalSkillExpertise = value;
                    return true;
                
                case "deception":
                    _isDeceptionSkillProficient = value;
                    return true;
                case "deception expertise":
                    _isDeceptionSkillExpertise = value;
                    return true;
                
                case "intimidation":
                    _isIntimidationSkillProficient = value;
                    return true;
                case "intimidation expertise":
                    _isIntimidationSkillExpertise = value;
                    return true;
                
                case "performance":
                    _isPerformanceSkillProficient = value;
                    return true;
                case "performance expertise":
                    _isPerformanceSkillExpertise = value;
                    return true;
                
                case "persuasion":
                    _isPersuasionSkillProficient = value;
                    return true;
                case "persuasion expertise":
                    _isPersuasionSkillExpertise = value;
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

        private void SyncWithDB()
        {
            if (!_savingToDB)
            {
                _savingToDB = true;
                StartCoroutine(SaveToDB());
            }
        }

        private static IEnumerator SaveToDB()
        {
            Debug.Log("Saving to DB");

            Root serializedRoot = new Root();
            
            serializedRoot.stats = new List<Stat>();
            serializedRoot.attributes = new List<Attribute>();
            serializedRoot.ac = new List<Ac>();
            serializedRoot.savingThrowProficiencies = new List<SavingThrowProficiencies>();
            serializedRoot.skills = new List<Skills>();
            serializedRoot.hitPoints = new List<HitPoints>();
            
            serializedRoot.stats.Add(SerializeStats(new Stat(), serializedRoot));
            foreach (string attribute in attribute_strings)
            {
                serializedRoot.attributes.Add(SerializeAttributes(attribute, serializedRoot));
            }
            serializedRoot.ac.Add(SerializeAc(new Ac(), serializedRoot));

            foreach (string attribute in attribute_strings)
            {
                serializedRoot.savingThrowProficiencies.Add(SerializeSavingThrowProficiencies(attribute, serializedRoot));
            }

            foreach (string skill in skill_strings)
            {
                serializedRoot.skills.Add(SerializeSkills(skill, serializedRoot));
            }
            
            serializedRoot.hitPoints.Add(SerializeHitPoints(new HitPoints(), serializedRoot));
            
            UnityWebRequest request = UnityWebRequest.Put(_url, JsonConvert.SerializeObject(serializedRoot));
            request.SetRequestHeader("Content-Type", "application/json");
            Debug.Log(JsonConvert.SerializeObject(serializedRoot));
            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Request successful");

            }
            else
            {
                Debug.Log("Request failed");
            }
            
            _savingToDB = false;
            Debug.Log("Saving To DB finished");

        }

        private static Stat SerializeStats(Stat serializedStats, Root root)
        {
            serializedStats.characterId = _characterId;
            serializedStats.characterIsInspired = _isInspired;
            serializedStats.characterName = _characterName;
            serializedStats.characterClass = _characterClass;
            serializedStats.characterRace = _characterRace;
            serializedStats.characterBackground = _characterBackground;
            serializedStats.characterSubclass = _characterSubClass;
            serializedStats.characterLevel = _baseLevel;
            serializedStats.characterAlignment = _characterAlignment;
            serializedStats.characterConditions = TurnConditionToString(_conditions);
            serializedStats.characterUpdateLink = _characterLink;
            serializedStats.characterProficiencyBonus = _proficiencyBonus;
            serializedStats.characterGender = _characterGender;
            serializedStats.characterDeathSaveSuccess = _deathSaveSuccesses;
            serializedStats.characterDeathSaveFailed = _deathSaveFailures;
            serializedStats.characterExhaustion = _exhaustionLevel;
            serializedStats.characterSpeed = _speed;
            serializedStats.initiativeAdjustment = _initiativeAdjustment;
            serializedStats.characterProficiencyBonusAdjustment = _proficiencyBonusAdjustment;
            return serializedStats;
        }

        private static Attribute SerializeAttributes(string attribute, Root root)
        {
            Attribute serializedAttribute = new Attribute();
            serializedAttribute.attributeName = attribute;
            serializedAttribute.attributeValue = GetStatValue(attribute + "_attribute");
            return serializedAttribute;
        }

        private static Ac SerializeAc(Ac serializedAc, Root root)
        {
            serializedAc.acModifier = _acAdjustment;
            serializedAc.acBase = _baseAc;
            serializedAc.acCharacter = _characterId;
            return serializedAc;
        }

        private static SavingThrowProficiencies SerializeSavingThrowProficiencies(string savingThrow, Root root)
        {
            SavingThrowProficiencies serializedSavingThrow = new SavingThrowProficiencies();
            serializedSavingThrow.savingThrowName = savingThrow;
            serializedSavingThrow.savingThrowIsProficient = GetIsProficiency(savingThrow);
            serializedSavingThrow.savingThrowAdjustment = 0;
            return serializedSavingThrow;
        }

        private static Skills SerializeSkills(string skill, Root root)
        {
            Skills serializedSkill = new Skills();
            serializedSkill.skillName = skill;
            serializedSkill.skillIsProficient = GetIsProficiency(skill);
            serializedSkill.skillIsExpertise = false;
            serializedSkill.skillValue = 0;
            return serializedSkill;
        }

        private static HitPoints SerializeHitPoints(HitPoints serializedHitPoints, Root root)
        {
            serializedHitPoints.nonLethalDamage = _nonLethalDamage;
            serializedHitPoints.temporary = _healthpointsTemporary;
            serializedHitPoints.current = _healthpointsCurrent;
            serializedHitPoints.maximum = _healthpointsMax;
            serializedHitPoints.hitPointsCharacter = _characterId;
            return serializedHitPoints;
        }

        private static string TurnConditionToString(List<Condition> conditions)
        {
            string conditionString = "";
            foreach (Condition condition in conditions)
            {
                conditionString += condition + " ";
            }
            return conditionString;
        }
    }
}
