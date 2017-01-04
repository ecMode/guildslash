using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class BaseItem
{
	private static Random random = new Random();
	public enum Modifiers
	{
		NORMAL = 0,
		MAGICAL = 1,
		MYSTICAL = 2,
		ANGELICAL = 3,
		RARE = 4,
		MYTHICAL = 5,
		ARCANE = 6,
		EPIC = 7,
		RELIC = 8,
		ARTIFACT = 9
	}

	public enum Stats
	{
		ENHANCED_EFFECT,
		STRENGTH,
		DEXTERITY,
		INTELLIGENCE,
		STAMINA,
		MAGIC_FIND,
		CRITICAL_STRIKE,
		LIFE_REGEN,
		MANA_REGEN,
		MAX_LIFE,
		MAX_MANA,
		LIFE_PER_ATTACK,
		MANA_PER_ATTACK,
		LIFE_PER_KILL,
		MANA_PER_KILL
	}

    List<int> modifierWeight = new List<int>() {
        95, // Normal 
        80, // Magical
        60, // Angelical
        40, // Rare
        30, // Mythical
        20, // Arcane
        10  // Epic
    };
	private int Weighted()
	{
		int range = 0;
		for (int i = 0; i < modifierWeight.Count; i++)
			range += modifierWeight[i];

		int rand = random.Next (0, range);
		int top = 0;

		for (int i = 0; i < modifierWeight.Count; i++)
		{
			top += modifierWeight[i];
			if (rand < top)
				return i;
		}
        return 0;
	}

    public void RandomizeStats()
    {
        modifier = (Modifiers)Weighted();
        ItemStats = RollStats();
        ItemStatValues = RollStatValues();
    }

	public BaseItem(int level){
        if (level < 5)
            LevelRequirement = 0;
        else
		    LevelRequirement = (int)Math.Ceiling(level / 5d) * 5;
    }

	public BaseItem(){
		modifier = (Modifiers)Weighted();
		RollStats ();
	}

	private List<Stats> itemStats;
	public List<Stats> ItemStats {
		get { return itemStats; }
		set {itemStats = value; }
    }

    private List<int> itemStatValues;
    public List<int> ItemStatValues
    {
        get { return itemStatValues; }
        set { itemStatValues = value; }
    }

    private Modifiers modifier;
	public Modifiers Modifier{
		get { return modifier; }
		set { modifier = value; }
	}

	private int levelRequirement;
	public int LevelRequirement {
		get { return levelRequirement; }
		set { levelRequirement = value; }
	}

	public int GetStatValue(Stats stat){
        if (ItemStats == null || !ItemStats.Contains(stat))
            return 0;
		return ItemStatValues[itemStats.IndexOf(stat)];
	}

	public List<Stats> RollStats()
	{
		List<Stats> stats = new List<Stats> ();
		int modRange = Enum.GetNames (typeof(Modifiers)).Length;
		while (stats.Count < (int)Modifier) 
		{
			int statsIndex = random.Next (0, Enum.GetNames (typeof(Stats)).Length);
			if (!stats.Contains((Stats)statsIndex))
				stats.Add((Stats)statsIndex);
		}
		return stats;
	}

	protected List<int> RollStatValues()
	{
		List<int> statValues = new List<int> ();
        if (itemStats == null)
            return statValues;
		int statValue;
		foreach (Stats stat in itemStats) {
			if (stat == Stats.STRENGTH || stat == Stats.DEXTERITY || stat == Stats.INTELLIGENCE || stat == Stats.STAMINA)
				statValue = RollAttributeStatValue();
			else if (stat == Stats.ENHANCED_EFFECT)
				statValue = RollEnhancedEffectStatValue();
			else 
				statValue = RollAccessoryStatValue();
			statValues.Add (statValue);
		}
		return statValues;
	}

	private int RollAttributeStatValue()
	{
		return random.Next(1, (int)Math.Ceiling((LevelRequirement + 1)/5d) * 5);
	}

	private int RollEnhancedEffectStatValue()
	{
		return random.Next(1, 40 + ((int)Math.Ceiling((LevelRequirement + 1) / 5d) * 20));
	}

	private int RollAccessoryStatValue()
	{
		return random.Next(1, (int)Math.Ceiling((LevelRequirement + 1) / 5d) * 5);
	}
}

