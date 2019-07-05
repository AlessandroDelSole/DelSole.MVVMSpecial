namespace DelSole.MVVMSpecial.Behaviors
{
    /// <summary>
    /// Define a property that all validator behaviors must expose for validation to be considered passed
    /// </summary>
    public interface IValidatorBehavior
    {
        /// <summary>
        /// Return whether the specified object has passed validation
        /// </summary>
        bool IsValid { get; set; }
    }
}
