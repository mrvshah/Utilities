namespace Utilities.AppStartupValidation
{
	///<summary>
	/// Defines the contract for all validators
	///</summary>
	public interface IValidator
	{
		///<summary>
		/// Enables validation by custom validator
		///</summary>
		void Validate();
	}
}