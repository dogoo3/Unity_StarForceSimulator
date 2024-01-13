using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class OCID
{
    public string ocid;
}

[System.Serializable]
public class EquipmentInfo
{
    public string date;
    public string character_gender;
    public string character_class;

    public ItemEquipment[] item_equipment;

    public Title title;

    public DragonMechanicEquip[] dragon_equipment;
    public DragonMechanicEquip[] mechanic_equipment;
}

[System.Serializable]
public class ItemEquipment
{
    public string item_equipment_part;
    public string item_equipment_slot;
    public string item_name;
    public string item_icon;
    public string item_description;
    public string item_shape_name;
    public string item_shape_icon;
    public string item_gender;
    public ItemTotalOption item_total_option;
    public ItemBaseOption item_base_option;
    public string potential_option_grade;
    public string additional_potential_option_grade;
    public string potential_option_1;
    public string potential_option_2;
    public string potential_option_3;
    public string additional_potential_option_1;
    public string additional_potential_option_2;
    public string additional_potential_option_3;
    public string equipment_level_increase;
    public ItemExceptionalOption item_exceptional_option;
    public ItemAddOption item_add_option;
    public string growth_exp;
    public string growth_level;
    public string scroll_upgrade;
    public string cuttable_count;
    public string golden_hammer_flag;
    public string scroll_resilience_count;
    public string scroll_upgradeable_count;
    public string soul_name;
    public string soul_option;
    public ItemStarForceOption item_etc_option;
    public string starforce;
    public string starforce_scroll_flag;
    public ItemStarForceOption item_starforce_option;
    public string special_ring_level;
    public string date_expire;
}

[System.Serializable]
public class Title
{
    public string title_name;
    public string title_icon;
    public string title_description;
    public string date_expire;
    public string date_option_expire;
}

[System.Serializable]
public class DragonMechanicEquip
{
    public string item_equipment_part;
    public string item_equipment_slot;
    public string item_name;
    public string item_icon;
    public string item_description;
    public string item_shape_name;
    public string item_shape_icon;
    public string item_gender;
    public ItemTotalOption item_total_option;
    public ItemBaseOption item_base_option;
    public string equipment_level_increase;
    public ItemExceptionalOption item_exceptional_option;
    public ItemAddOption item_add_option;
    public string growth_exp;
    public string growth_level;
    public string scroll_upgrade;
    public string cuttable_count;
    public string golden_hammer_flag;
    public string scroll_resilience_count;
    public string scroll_upgradeable_count;
    public string soul_name;
    public string soul_option;
    public ItemStarForceOption item_etc_option;
    public string starforce;
    public string starforce_scroll_flag;
    public ItemStarForceOption item_starforce_option;
    public string special_ring_level;
    public string date_expire;
}

[System.Serializable]
public class ItemTotalOption
{
    public string str;
    public string dex;
    public string _int;
    public string luk;
    public string max_hp;
    public string max_mp;
    public string attack_power;
    public string magic_power;
    public string armor;
    public string speed;
    public string jump;
    public string boss_damage;
    public string ignore_monster_armor;
    public string all_stat;
    public string damage;
    public string equipment_level_decrease;
    public string max_hp_rate;
    public string max_mp_rate;
}
[System.Serializable]
public class ItemBaseOption
{
    public string str;
    public string dex;
    public string _int;
    public string luk;
    public string max_hp;
    public string max_mp;
    public string attack_power;
    public string magic_power;
    public string armor;
    public string speed;
    public string jump;
    public string boss_damage;
    public string ignore_monster_armor;
    public string all_stat;
    public string max_hp_rate;
    public string max_mp_rate;
    public string base_equipment_level;
}

[System.Serializable]
public class ItemExceptionalOption
{
    public string str;
    public string dex;
    public string _int;
    public string luk;
    public string max_hp;
    public string max_mp;
    public string attack_power;
    public string magic_power;
}
[System.Serializable]
public class ItemAddOption
{
    public string str;
    public string dex;
    public string _int;
    public string luk;
    public string max_hp;
    public string max_mp;
    public string attack_power;
    public string magic_power;
    public string armor;
    public string speed;
    public string jump;
    public string boss_damage;
    public string damage;
    public string all_stat;
    public string equipment_level_decrease;
}

[System.Serializable]
public class ItemStarForceOption
{
    public string str;
    public string dex;
    public string _int;
    public string luk;
    public string max_hp;
    public string max_mp;
    public string attack_power;
    public string magic_power;
    public string armor;
    public string speed;
    public string jump;
}

[System.Serializable]
public class ErrorMessage
{
    public Error error;
}

[System.Serializable]
public class Error
{
    public string name;
    public string message;
}

// 아이템 데이터 저장정보
public class ItemInfo
{
    private string itemName;
    private string itemURL;
    private int starforce;
    private int level;
    private int maxStarforce;

    public ItemInfo(string itemName, string itemURL, string starforce, string level)
    {
        this.itemName = itemName;
        this.itemURL = itemURL;
        this.starforce = int.Parse(starforce);
        this.level = int.Parse(level);
        if (95 < this.level)
        {
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 3;
            }
            else
            {
                maxStarforce = 5;
            }
        }
        else if (95 <= this.level && this.level < 108)
        {
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 5;
            }
            else
            {
                maxStarforce = 8;
            }
        }
        else if (108 <= this.level && this.level < 118)
        {
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 8;
            }
            else
            {
                maxStarforce = 10;
            }
        }
        else if (118 <= this.level && this.level < 128)
        {
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 10;
            }
            else
            {
                maxStarforce = 15;
            }
        }
        else if (128 <= this.level && this.level < 138)
        {
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 12;
            }
            else
            {
                maxStarforce = 20;
            }
        }
        else
        { 
            if (this.itemName.Substring(0, 4) == "타일런트")
            {
                maxStarforce = 15;
            }
            else
            {
                maxStarforce = 25;
            }
        }
    }

    public string GetItemURL()
    {
        return itemURL;
    }
}