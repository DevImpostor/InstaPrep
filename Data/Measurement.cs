namespace InstaPrep.Data
{
    public abstract class MeasurementType
    {
        public virtual string? Name { get; set; }
        public virtual bool IsVolume { get; set; }
        public virtual bool IsWeight { get; set; }
        public virtual bool IsOtherMeasurement { get; set; }

    }
}
