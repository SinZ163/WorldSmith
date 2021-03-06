﻿using KVLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldSmith.DataClasses
{
    public enum ModifierPropertyType
    {
        MODIFIER_PROPERTY_PREATTACK_BONUS_DAMAGE,
        MODIFIER_PROPERTY_PREATTACK_BONUS_DAMAGE_POST_CRIT,
        MODIFIER_PROPERTY_BASEATTACK_BONUSDAMAGE,
        MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_PHYSICAL,
        MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_MAGICAL,
        MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_COMPOSITE,
        MODIFIER_PROPERTY_PROCATTACK_BONUS_DAMAGE_PURE,
        MODIFIER_PROPERTY_PROCATTACK_FEEDBACK,
        MODIFIER_PROPERTY_POST_ATTACK,
        MODIFIER_PROPERTY_INVISIBILITY_LEVEL,
        MODIFIER_PROPERTY_PERSISTENT_INVISIBILITY,
        MODIFIER_PROPERTY_MOVESPEED_BONUS_CONSTANT,
        MODIFIER_PROPERTY_MOVESPEED_BASE_OVERRIDE,
        MODIFIER_PROPERTY_MOVESPEED_BONUS_PERCENTAGE,
        MODIFIER_PROPERTY_MOVESPEED_BONUS_PERCENTAGE_UNIQUE,
        MODIFIER_PROPERTY_MOVESPEED_BONUS_UNIQUE,
        MODIFIER_PROPERTY_MOVESPEED_ABSOLUTE,
        MODIFIER_PROPERTY_MOVESPEED_LIMIT,
        MODIFIER_PROPERTY_MOVESPEED_MAX,
        MODIFIER_PROPERTY_ATTACKSPEED_BONUS_CONSTANT,
        MODIFIER_PROPERTY_ATTACKSPEED_BONUS_CONSTANT_POWER_TREADS,
        MODIFIER_PROPERTY_ATTACKSPEED_BONUS_CONSTANT_SECONDARY,
        MODIFIER_PROPERTY_BASE_ATTACK_TIME_CONSTANT,
        MODIFIER_PROPERTY_DAMAGEOUTGOING_PERCENTAGE,
        MODIFIER_PROPERTY_DAMAGEOUTGOING_PERCENTAGE_ILLUSION,
        MODIFIER_PROPERTY_BASEDAMAGEOUTGOING_PERCENTAGE,
        MODIFIER_PROPERTY_INCOMING_DAMAGE_PERCENTAGE,
        MODIFIER_PROPERTY_INCOMING_PHYSICAL_DAMAGE_PERCENTAGE,
        MODIFIER_PROPERTY_INCOMING_SPELL_DAMAGE_CONSTANT,
        MODIFIER_PROPERTY_EVASION_CONSTANT,
        MODIFIER_PROPERTY_AVOID_CONSTANT,
        MODIFIER_PROPERTY_AVOID_SPELL,
        MODIFIER_PROPERTY_MISS_PERCENTAGE,
        MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS,
        MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS_ILLUSIONS,
        MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS_UNIQUE,
        MODIFIER_PROPERTY_PHYSICAL_ARMOR_BONUS_UNIQUE_ACTIVE,
        MODIFIER_PROPERTY_MAGICAL_RESISTANCE_BONUS,
        MODIFIER_PROPERTY_MAGICAL_RESISTANCE_ITEM_UNIQUE,
        MODIFIER_PROPERTY_MAGICAL_RESISTANCE_DECREPIFY_UNIQUE,
        MODIFIER_PROPERTY_BASE_MANA_REGEN,
        MODIFIER_PROPERTY_MANA_REGEN_CONSTANT,
        MODIFIER_PROPERTY_MANA_REGEN_CONSTANT_UNIQUE,
        MODIFIER_PROPERTY_MANA_REGEN_PERCENTAGE,
        MODIFIER_PROPERTY_MANA_REGEN_TOTAL_PERCENTAGE,
        MODIFIER_PROPERTY_HEALTH_REGEN_CONSTANT,
        MODIFIER_PROPERTY_HEALTH_REGEN_PERCENTAGE,
        MODIFIER_PROPERTY_HEALTH_BONUS,
        MODIFIER_PROPERTY_MANA_BONUS,
        MODIFIER_PROPERTY_EXTRA_STRENGTH_BONUS,
        MODIFIER_PROPERTY_EXTRA_HEALTH_BONUS,
        MODIFIER_PROPERTY_EXTRA_MANA_BONUS,
        MODIFIER_PROPERTY_STATS_STRENGTH_BONUS,
        MODIFIER_PROPERTY_STATS_AGILITY_BONUS,
        MODIFIER_PROPERTY_STATS_INTELLECT_BONUS,
        MODIFIER_PROPERTY_ATTACK_RANGE_BONUS,
        MODIFIER_PROPERTY_REINCARNATION,
        MODIFIER_PROPERTY_RESPAWNTIME,
        MODIFIER_PROPERTY_DEATHGOLDCOST,
        MODIFIER_PROPERTY_PREATTACK_CRITICALSTRIKE,
        MODIFIER_PROPERTY_PHYSICAL_CONSTANT_BLOCK,
        MODIFIER_PROPERTY_TOTAL_CONSTANT_BLOCK_UNAVOIDABLE_PRE_ARMOR,
        MODIFIER_PROPERTY_TOTAL_CONSTANT_BLOCK,
        MODIFIER_PROPERTY_OVERRIDE_ANIMATION,
        MODIFIER_PROPERTY_OVERRIDE_ANIMATION_WEIGHT,
        MODIFIER_PROPERTY_OVERRIDE_ANIMATION_RATE,
        MODIFIER_PROPERTY_ABSORB_SPELL,
        MODIFIER_PROPERTY_DISABLE_AUTOATTACK,
        MODIFIER_PROPERTY_BONUS_DAY_VISION,
        MODIFIER_PROPERTY_BONUS_NIGHT_VISION,
        MODIFIER_PROPERTY_BONUS_VISION_PERCENTAGE,
        MODIFIER_PROPERTY_MIN_HEALTH,
        MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_PHYSICAL,
        MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_MAGICAL,
        MODIFIER_PROPERTY_ABSOLUTE_NO_DAMAGE_PURE,
        MODIFIER_PROPERTY_IS_ILLUSION,
        MODIFIER_PROPERTY_TURN_RATE_PERCENTAGE,
        MODIFIER_PROPERTY_DISABLE_HEALING,
        MODIFIER_PROPERTY_TOOLTIP,
        MODIFIER_PROPERTY_MODEL_CHANGE,
        MODIFIER_PROPERTY_MODEL_SCALE,
        MODIFIER_PROPERTY_IS_SCEPTER,
        MODIFIER_PROPERTY_TRANSLATE_ACTIVITY_MODIFIERS,
        MODIFIER_PROPERTY_TRANSLATE_ATTACK_SOUND,
        MODIFIER_PROPERTY_LIFETIME_FRACTION,
        MODIFIER_PROPERTY_PROVIDES_FOW_POSITION,
        MODIFIER_PROPERTY_COOLDOWN_REDUCTION_CONSTANT,
        MODIFIER_PROPERTY_FORCE_DRAW_MINIMAP,
    }

    public class ModifierProperty
    {
        public ModifierPropertyType PropertyType
        {
            get;
            set;
        }

        public NumberValue Value
        {
            get;
            set;
        }

        public KeyValue ToKV()
        {
            KeyValue kv = new KeyValue(PropertyType.ToString());
            kv += Value.Value;
            return kv;
        }

    }
}
