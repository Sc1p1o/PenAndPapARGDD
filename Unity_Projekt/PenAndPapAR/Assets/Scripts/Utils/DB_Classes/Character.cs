using System.Collections.Generic;
using Newtonsoft.Json;

namespace Utils.DB_Classes
{
    public class Stat
    {
        [JsonProperty("characert_id")]
        public string characterId { get; set; }
        
        [JsonProperty("character_is_inspired")]
        public bool characterIsInspired { get; set; }
        
        [JsonProperty("character_name")]
        public string characterName { get; set; }
        
        [JsonProperty("character_class")]
        public string characterClass { get; set; }
        
        [JsonProperty("character_race")]
        public string characterRace { get; set; }
        
        [JsonProperty("character_background")]
        public string characterBackground { get; set; }
        
        [JsonProperty("character_subclasses")]
        public string characterSubclass { get; set; }
        
        [JsonProperty("character_level")]
        public int characterLevel { get; set; }
        
        [JsonProperty("character_alignment")]
        public string characterAlignment { get; set; }
        
        [JsonProperty("character_conditions")]
        public string characterConditions { get; set; }
        
        [JsonProperty("character_update_link")]
        public string characterUpdateLink { get; set; }
        
        [JsonProperty("character_proficiency_bonus")]
        public int characterProficiencyBonus { get; set; }
        
        
        [JsonProperty("character_initiative_adjustment")]
        public int initiativeAdjustment { get; set; }
        
        [JsonProperty("character_speed")]
        public int characterSpeed { get; set; }
        
        [JsonProperty("character_proficiency_bonus_adjustment")]
        public int characterProficiencyBonusAdjustment { get; set; }
        
        [JsonProperty("character_death_save_success")]
        public int characterDeathSaveSuccess { get; set; }
        
        [JsonProperty("character_death_save_failure")]
        public int characterDeathSaveFailed { get; set; }
        
        [JsonProperty("character_exhaustion")]
        public int characterExhaustion { get; set; }
        
        [JsonProperty("character_gender")]
        public string characterGender { get; set; }
        
    }
    
    public class Attribute
    {
        [JsonProperty("id")]
        public int id { get; set; }

        [JsonProperty("attribute_name")]
        public string attributeName { get; set; }

        [JsonProperty("attribute_value")]
        public int attributeValue { get; set; }

        [JsonProperty("attribute_adjustment")]
        public int attributeAdjustment { get; set; }

        [JsonProperty("attribute_character")]
        public string attributeCharacter { get; set; }
    }

    public class Ac
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("ac_base")]
        public int acBase { get; set; }
        
        [JsonProperty("ac_modified")]
        public int acModifier { get; set; }
        
        [JsonProperty("ac_character")]
        public string acCharacter { get; set; }
    }

    public class SavingThrowProficiencies
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("saving_throw_name")]
        public string savingThrowName { get; set; }
        
        [JsonProperty("saving_throw_adjustment")]
        public int savingThrowAdjustment { get; set; }
        
        [JsonProperty("saving_throw_is_proficient")]
        public bool savingThrowIsProficient { get; set; }
        
        [JsonProperty("saving_throw_proficiency_character")]
        public string savingThrowCharacter { get; set; }
    }
    
    public class Skills
    {
        [JsonProperty("id")]
        public int id { get; set; }
        
        [JsonProperty("skill_name")]
        public string skillName { get; set; }
        
        [JsonProperty("skill_adjustment")]
        public int skillValue { get; set; }
        
        [JsonProperty("skill_is_proficient")]
        public bool skillIsProficient { get; set; }
        
        [JsonProperty("skill_is_expertise")]
        public bool skillIsExpertise { get; set; }
        
        [JsonProperty("skill_character")]
        public string skillCharacter { get; set; }
    }

    public class HitPoints
    {
        [JsonProperty("hit_points_current")]
        public int current { get; set; }
        
        [JsonProperty("hit_points_max")]
        public int maximum { get; set; }
        
        [JsonProperty("hit_points_temp")]
        public int temporary { get; set; }
        
        [JsonProperty("non_lethal_damage")]
        public int nonLethalDamage { get; set; }
        
        [JsonProperty("hit_points_character")]
        public string hitPointsCharacter { get; set; }
    }
    
    

    public class Root
    {
        [JsonProperty("stats")]
        public List<Stat> stats { get; set; }
        
        [JsonProperty("attributes")]
        public List<Attribute> attributes { get; set; }
        
        [JsonProperty("ac")]
        public List<Ac> ac { get; set; }
        
        [JsonProperty("saving_throw_proficiencies")]
        public List<SavingThrowProficiencies> savingThrowProficiencies { get; set; }
        
        [JsonProperty("skills")]
        public List<Skills> skills { get; set; }
        
        [JsonProperty("hit_points")]
        public List<HitPoints> hitPoints { get; set; }
    }
}

