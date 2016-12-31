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

    List<int> items = new List<int>() { 95, 80, 60, 40, 30, 20, 10 };
	private int Weighted()
	{
		int range = 0;
		for (int i = 0; i < items.Count; i++)
			range += items[i];

		int rand = random.Next (0, range);
		int top = 0;

		for (int i = 0; i < items.Count; i++)
		{
			top += items [i];
			if (rand < top)
				return i;
		}
        return 0;
	}


	public BaseItem(int level){
		levelRequirement = level;
		modifier = (Modifiers)Weighted();
		ItemStats = RollStats ();
		ItemStatValues = RollStatValues ();

	}

	public BaseItem(){
		modifier = (Modifiers)Weighted();
		RollStats ();
	}

	private Dictionary<Stats, int> statsMap;
	public Dictionary<Stats, int> StatsMap {
		get { return statsMap; }
		set { statsMap = value; }
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
        if (!itemStats.Contains(stat))
            return 0;
		return ItemStatValues[(int)stat + 1];
	}

	public List<Stats> RollStats()
	{
		List<Stats> stats = new List<Stats> ();
		int modRange = Enum.GetNames (typeof(Modifiers)).Length;
		for (int i = 0; i < (int)Modifier; i++) {
			int statsIndex = random.Next (0, Enum.GetNames (typeof(Stats)).Length);
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
				statValue = RollAttributeStat ();
			else if (stat == Stats.ENHANCED_EFFECT)
				statValue = RollEnhancedEffectStat();
			else 
				statValue = RollAccessoryStat();
			statValues.Add (statValue);
		}
		return statValues;
	}

	private int RollAttributeStat()
	{
		return random.Next(0, (int)Math.Ceiling(levelRequirement/5d)*5);
	}

	private int RollEnhancedEffectStat()
	{
		return random.Next(0, LevelRequirement * 20);
	}

	private int RollAccessoryStat()
	{
		return random.Next(0, LevelRequirement * 20);
	}
}

