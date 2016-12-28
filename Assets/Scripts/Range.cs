/// <summary>The Range class.</summary>
/// <typeparam name="T">Generic parameter.</typeparam>
public class Range<T> where T : System.IComparable<T>
{
    public Range(int min, int max)
    {
        Minimum = min;
        Maximum = max;
    }

    public Range(int min, double max)
    {
        Minimum = min;
        Maximum = (int)max;
    }
    /// <summary>Minimum value of the range.</summary>
    public int Minimum { get; set; }

    /// <summary>Maximum value of the range.</summary>
    public int Maximum { get; set; }

    /// <summary>Presents the Range in readable format.</summary>
    /// <returns>String representation of the Range</returns>
    public override string ToString()
    {
        return string.Format("[{0} - {1}]", this.Minimum, this.Maximum);
    }

    public Range<int> addRange(Range<int> range)
    {
        return new Range<int>(this.Minimum + range.Minimum, this.Maximum + range.Maximum);
    }

    /// <summary>Determines if the range is valid.</summary>
    /// <returns>True if range is valid, else false</returns>
    public bool IsValid()
    {
        return this.Minimum.CompareTo(this.Maximum) <= 0;
    }

    public int nextInt()
    {
        System.Random rand = new System.Random();
        return rand.Next(this.Minimum, this.Maximum);
    }
}