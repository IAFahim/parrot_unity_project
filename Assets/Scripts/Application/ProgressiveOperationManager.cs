///<copyright> Secret Dimension Inc. 2025, All rights reserved <copyright>
using System;
using System.Collections.Generic;

namespace SecretDimension
{
	// Credit to Aesthetician Labs 
	// Modified from source available here: https://github.com/aestheticianlabs/com.aela.utilities.scene-transition/blob/main/ProgressiveOperationManager.cs

	///<summary>
	/// Handles progressive operations and updates progress
	///</summary>
	public class ProgressiveOperationManager
	{
		private readonly List<Operation> operations = new List<Operation>();

		public IReadOnlyList<Operation> Operations => operations;

		/// <summary>
		/// Starts a new progressive operation and returns the handle
		/// </summary>
		/// <returns></returns>
		public Operation StartOperation()
		{
			var handle = new Operation();
			operations.Add(handle);
			return handle;
		}

		/// <summary>
		/// Stops tracking the provided operation
		/// </summary>
		/// <param name="handle"></param>
		public void Release(Operation handle)
		{
			operations.Remove(handle);
		}

		public void Clear() => operations.Clear();

		public class Operation : IDisposable
		{
			public float Progress;
			public bool IsComplete => Progress >= 1f;

			public void Dispose()
			{
				Progress = 1f;
			}
		}
	}
}
